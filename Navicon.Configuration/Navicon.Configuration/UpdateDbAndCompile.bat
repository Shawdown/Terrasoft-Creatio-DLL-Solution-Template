CALL :GET_ABSOLUTE_PATH "%~dp0..\..\"
SET WEB_APP_DIR=%RETVAL%

:: 1. Закидываем изменения пакетов в БД. 
ECHO Updating DB... [1/2]
..\..\DesktopBin\WorkspaceConsole\Terrasoft.Tools.WorkspaceConsole.exe --operation=LoadPackagesToDb --workspaceName=Default --webApplicationPath=%WEB_APP_DIR% --confRuntimeParentDirectory=%WEB_APP_DIR% --autoExit=true

:: 2. Компилируем.
ECHO Compiling... [2/2]
..\..\DesktopBin\WorkspaceConsole\Terrasoft.Tools.WorkspaceConsole.exe --operation=BuildWorkspace --workspaceName=Default --webApplicationPath=%WEB_APP_DIR% --confRuntimeParentDirectory=%WEB_APP_DIR% --autoExit=true

:: ========== FUNCTIONS ==========
EXIT /B

:GET_ABSOLUTE_PATH
  SET RETVAL=%~f1
  EXIT /B