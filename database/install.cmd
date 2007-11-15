@echo Installing database...
@del Install.log
@nant install -l:install.log
@echo Completed. For details please see 'install.log'.