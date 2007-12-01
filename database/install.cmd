@echo Installing database...
@del Install.log
@..\tools\nant\bin\NAnt.exe install -l:install.log
@echo Completed. For details please see 'install.log'.