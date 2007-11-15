@echo Reinstalling database...
@del reinstall.log
@nant reinstall -l:reinstall.log
@echo Completed. For details please see 'reinstall.log'.