@echo off
chcp 65001

CALL :GET_ABSOLUTE_PATH "%~dp0..\..\"
SET CONF_BIN_DIR=%RETVAL%conf\bin\
SETLOCAL EnableDelayedExpansion

:: 1. Находим поддиректорию с самой новой сборкой Terrasoft.Configuration. 
pushd %CONF_BIN_DIR%
set h=0
for /d %%d in (*.*) do (    
    set /a x=!h!-%%~nd  
    if "!x:~0,1!"=="-" set h=%%d    
)
popd

set h=%h: =%
IF "%h%" == "0" GOTO :BIN_IS_EMPTY

:: 2. Копируем самый новый Terrasoft.Configuration.dll в директорию Lib проекта Navicon.Configuration.
copy %CONF_BIN_DIR%!h!\Terrasoft.Configuration.dll %~dp0Lib\Terrasoft.Configuration.dll
echo Copied [%CONF_BIN_DIR%!h!\Terrasoft.Configuration.dll] to [%~dp0Lib\Terrasoft.Configuration.dll].

:: 3. Копируем самый новый Terrasoft.Configuration.ODataEntities.dll в директорию Lib проекта Navicon.Configuration.
copy %CONF_BIN_DIR%!h!\Terrasoft.Configuration.ODataEntities.dll %~dp0Lib\Terrasoft.Configuration.ODataEntities.dll
echo Copied [%CONF_BIN_DIR%!h!\Terrasoft.Configuration.ODataEntities.dll] to [%~dp0Lib\Terrasoft.Configuration.ODataEntities.dll].

:: ========== FUNCTIONS ==========
EXIT /B

:GET_ABSOLUTE_PATH
  SET RETVAL=%~f1
  EXIT /B
  
:BIN_IS_EMPTY
  echo Directory [%CONF_BIN_DIR%] is empty, Terrasoft.Configuration needs to be compiled first.
  EXIT /B