IF [%1] == [run] (
	goto :justrun
)
ELSE (
	goto :make
)

goto :end

:make
msbuild MyLogical.WinUI\mylogical.winui.csproj /verbosity:minimal
@pause

:justrun
@start .\mylogical.winui\bin\debug\mylogical.exe
@cls

:end