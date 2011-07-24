@echo Uninstalling database...
@del uninstall.log
@..\tools\nant\bin\NAnt.exe uninstall -l:uninstall.log
@echo Completed. For details please see 'uninstall.log'.