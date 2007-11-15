@echo Uninstalling database...
@del uninstall.log
@nant uninstall -l:uninstall.log
@echo Completed. For details please see 'uninstall.log'.