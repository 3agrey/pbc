@echo Reinstalling database...
@del reinstall.log
@..\tools\nant\bin\NAnt.exe reinstall -l:reinstall.log
@echo Completed. For details please see 'reinstall.log'.