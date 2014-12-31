@echo On
set debug=%1

REM Set Variables:
set config="%Configuration%"
if %config% == "" (
   set config=Release
)
set version="%PackageVersion%"

REM Restore:
if "%debug%"=="1" pause
src\AspnetWebApi2Helpers\.nuget\nuget.exe install "src\AspnetWebApi2Helpers\AspnetWebApi2Helpers.Serialization\packages.config" -OutputDirectory "src\AspnetWebApi2Helpers\packages" -NonInteractive
if "%debug%"=="1" pause
if not "%errorlevel%"=="0" exit

REM Build:
if "%debug%"=="1" pause
mkdir "releases\%PackageVersion%\AspnetWebApi2Helpers.Serialization\portable-net45+wp80+win8+wpa81"
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild "src\AspnetWebApi2Helpers\AspnetWebApi2Helpers.Serialization\AspnetWebApi2Helpers.Serialization.csproj" /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=releases\%PackageVersion%\AspnetWebApi2Helpers.Serialization\portable-net45+wp80+win8+wpa81\msbuild.log /verbosity:normal /nr:false
if "%debug%"=="1" pause
if not "%errorlevel%"=="0" exit

REM Package:
if "%debug%"=="1" pause
src\AspnetWebApi2Helpers\.nuget\nuget.exe pack "src\AspnetWebApi2Helpers\AspnetWebApi2Helpers.Serialization\AspnetWebApi2Helpers.Serialization.csproj" -symbols -o "releases\%PackageVersion%\AspnetWebApi2Helpers.Serialization\portable-net45+wp80+win8+wpa81" -p Configuration=%config%;PackageVersion=%version%
if "%debug%"=="1" pause
if not "%errorlevel%"=="0" exit
