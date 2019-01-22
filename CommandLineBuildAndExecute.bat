REM set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v2.0.50727
REM set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v3.5
REM set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
REM set msBuildDir=C:\Program Files (x86)\MSBuild\12.0\Bin
set msBuildDir=%~dp0\ServiceNsw\MSBuild\15.0\Bin

call "%msBuildDir%\msbuild.exe"  ServiceNsw.sln /p:Configuration=Debug /l:FileLogger,Microsoft.Build.Engine;logfile=Manual_MSBuild_ReleaseVersion_LOG.log
set msBuildDir=

call "%~dp0\packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe" %~dp0\ServiceNsw\bin\Debug\ServiceNsw.dll

set /p DUMMY=Hit ENTER to continue...