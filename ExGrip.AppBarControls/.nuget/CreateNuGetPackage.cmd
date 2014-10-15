del .\Packages\*.* /q
..\..\.nuget\nuget pack ..\ExGrip.AppBarControls.csproj -IncludeReferencedProjects -Prop Configuration=Release -Symbols -OutputDirectory .\Packages

pause