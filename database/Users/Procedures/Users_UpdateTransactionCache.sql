if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Users_UpdateTransactionCache]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Users_UpdateTransactionCache]
end
go

/********************************************************************************************************
* Users_UpdateTransactionCache
*
* Updates transaction cache of user
********************************************************************************************************/
create procedure [dbo].[Users_UpdateTransactionCache]
(
	@Id int
)
as
begin
	begin transaction

	-- update flag
	update
		[Users]
	set
		[HasTransactionCache] = 1
	where
		[Id] = @Id

	-- instantiate transactions of single transfer
	insert into
		[Transactions]
	(
		[TransferId],
		[Date],
		[Amount]
	)
	select
		t.[Id],
		st.[Date],
		t.[Amount]
	from
		[Transfers] t
			inner join [SingleTransfers] st on
				t.[Id] = st.[Id]
			inner join dbo.fn_Transfers_GetListByUser(@Id) ti on
				t.[Id] = ti.[Id]

	declare @currDate datetime
	declare @endDate datetime

	declare @periodType tinyint
	declare @standardPeriod tinyint
	declare @customPeriod int
	declare @amount money
	
	-- instantiate transactions of periodical transfer
	declare @transferId int
	declare transferCursor cursor local fast_forward for
		select
			t.[Id]
		from
			[Transfers] t
				inner join [PeriodicalTransfers] pt on
					t.[Id] = pt.[Id]
				inner join dbo.fn_Transfers_GetListByUser(@Id) ti on
					t.[Id] = ti.[Id]

	open transferCursor
	fetch next from transferCursor into @transferId
	while @@fetch_status = 0
	begin
		-- get first date of period
		select
			@currDate = [StartDate],
			@endDate = [EndDate],
			@periodType = [PeriodType],
			@standardPeriod = [StandardPeriod],
			@customPeriod = [CustomPeriod],
			@amount = [Amount]
		from 
			[PeriodicalTransfers] pt
				inner join [Transfers] t on pt.Id = t.Id
		where
			pt.[Id] = @transferId
		
		while @currDate <= @endDate
		begin

			-- insert generated transaction
			insert into
				[Transactions]
			(
				[TransferId],
				[Date],
				[Amount]
			)
			select
				t.[Id],
				@currDate,
				@amount
			from
				[Transfers] t
			where
				t.[Id] = @transferId
			
			-- get next transaction date
			set @currDate = 
				case @periodType
					when 1 -- Standard Period
					then
						case @standardPeriod
							when 1 then dateadd(day, 1, @currDate) /* Daily */
							when 2 then dateadd(week, 1, @currDate) /* Weekly */
							when 3 then dateadd(month, 1, @currDate) /* Monthly */
							when 4 then dateadd(year, 1, @currDate) /* Yearly */
						end
					when 2 -- Custom Period
						then dateadd(day, @customPeriod, @currDate)
				end
		end

		fetch next from transferCursor into @transferId
	end
	close transferCursor
	deallocate transferCursor

	-- instantiate transactions of percentage transfer
	declare transferCursor cursor local fast_forward for
		select
			t.[Id]
		from
			[Transfers] t
				inner join [PercentageTransfers] pt on
					t.[Id] = pt.[Id]
				inner join dbo.fn_Transfers_GetListByUser(@Id) ti on
					t.[Id] = ti.[Id]

	open transferCursor
	fetch next from transferCursor into @transferId
	while @@fetch_status = 0
	begin
		declare @period int

		declare @currAmount money
		declare @percentage real

		-- get first date of period
		select
			@currAmount = [Amount],
			@percentage = [Percentage],
			@currDate = [StartDate],
			@period = [Period]
		from 
			[PercentageTransfers] pt
				inner join [Transfers] t on pt.Id = t.Id
		where
			pt.[Id] = @transferId

		-- calculate month base
		declare @base money
		set @base = @currAmount / @period

		while @currAmount > 0
		begin
			-- calculate current month percent
			declare @percent money
			set @percent = @currAmount * (@percentage / 12) / 100

			-- calculate total transaction amount for current month
			declare @total money
			set @total = @base + @percent

			-- insert generated transaction
			insert into
				[Transactions]
			(
				[TransferId],
				[Date],
				[Amount]
			)
			select
				@transferId,
				@currDate,
				@total
			from
				[Transfers] t
			where
				t.[Id] = @transferId

			-- get next transfer period
			set @currDate = dateadd(month, 1, @currDate)
			set @currAmount = @currAmount - @base
		end

		fetch next from transferCursor into @transferId
	end
	close transferCursor
	deallocate transferCursor

	-- instantiate transactions of deposit transfer
	-- currently not supported
	/*
	declare transferCursor cursor local fast_forward for
		select
			t.[Id]
		from
			[Transfers] t
				inner join [DepositTransfers] dt on
					t.[Id] = dt.[Id]
				inner join dbo.fn_Transfers_GetListByUser(@Id) ti on
					t.[Id] = ti.[Id]
	
	open transferCursor
	fetch next from transferCursor into @transferId
	while @@fetch_status = 0
	begin
		-- get first date of period
		select
			@currDate = [StartDate],
			@endDate = [EndDate],
			@periodType = [PeriodType],
			@standardPeriod = [StandardPeriod],
			@customPeriod = [CustomPeriod],
			@amount = [Amount]
		from 
			[DepositTransfers]
		where
			[Id] = @transferId
		
		while @currDate <= @endDate
		begin

			

			-- get next transaction date
			set @currDate = 
				case @periodType
					when 1 -- Standard Period
					then
						case @standardPeriod
							when 1 then dateadd(day, 1, @currDate) /* Daily */
							when 2 then dateadd(week, 1, @currDate) /* Weekly */
							when 3 then dateadd(month, 1, @currDate) /* Monthly */
							when 4 then dateadd(year, 1, @currDate) /* Yearly */
						end
					when 2 -- Custom Period
						then dateadd(day, @customPeriod, @currDate)
				end
		end

		fetch next from transferCursor into @transferId
	end
	close transferCursor
	deallocate transferCursor
	*/

	-- -----------------------------------------------------------------------
	-- Account State Cache
	-- -----------------------------------------------------------------------
	declare @accountId int
	declare accountCursor cursor local fast_forward for
		select
			a.[Id]
		from
			[Accounts] a
		where
			a.[UserId] = @Id

	declare @date datetime
	declare dateCursor cursor local fast_forward for
		select distinct
			[Date]
		from
			[v_Transactions] t
		where
			[UserId] = @Id

	open accountCursor
	fetch next from accountCursor into @accountId
	while @@fetch_status = 0
	begin
		-- begin loop by accounts
		declare @currentBalance money
		select
			@currentBalance = [BeginningBalance]
		from
			[Accounts]
		where
			[Id] = @accountId

		open dateCursor
		fetch next from dateCursor into @date
		while @@fetch_status = 0
		begin
			-- begin loop by dates
			declare @endingBalance money
			declare @income money
			declare @outcome money
			set @income = 0
			set @outcome = 0

			-- get income amounts
			select
				@income = isnull(sum([Amount]), 0)
			from
				[v_Transactions] t
			where
				[TargetAccountId] = @accountId
				and [Date] = @date

			-- get outcome amounts
			select
				@outcome = isnull(sum([Amount]), 0)
			from
				[v_Transactions] t
			where
				[SourceAccountId] = @accountId
				and [Date] = @date

			-- calculate ending balance
			set @endingBalance = @currentBalance + @income - @outcome

			-- save current balance
			insert into
				[AccountStates]
			(
				[AccountId],
				[Date],
				[Balance]
			)
			values
			(
				@accountId,
				@date,
				@endingBalance
			)

			-- set current ending balance as next beginning balance
			set @currentBalance = @endingBalance

			-- end loop by dates
			fetch next from dateCursor into @date
		end
		close dateCursor
		-- end loop by accounts
		fetch next from accountCursor into @accountId
	end
	close accountCursor

	deallocate accountCursor
	deallocate dateCursor

	commit transaction
end
go