set WORKSPACE=.

set LUBAN_DLL=%WORKSPACE%\Luban\Luban.dll
set CONF_ROOT=%WORKSPACE%

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-bin ^
    -d bin  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputCodeDir=..\Assets\Scripts\Config\Gen ^
    -x outputDataDir=..\Assets\Bundles\ConfigDatas

pause