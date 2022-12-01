for /d /r ".\TemplateSolutions" %%a in (bin) do if exist "%%a" rmdir "%%a" /s /q
for /d /r ".\TemplateSolutions" %%a in (obj) do if exist "%%a" rmdir "%%a" /s /q

rmdir ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary" /s /q
rmdir ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary.Protocol" /s /q
rmdir ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary.Client" /s /q
rmdir ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary.Server" /s /q
rmdir ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary.Package" /s /q

xcopy ".\TemplateSolutions\CS.CustomTypeEditor\CustomControlLibrary\*.*" ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CS.CustomTypeEditor\CustomControlLibrary.Protocol\*.*" ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary.Protocol" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CS.CustomTypeEditor\CustomControlLibrary.Client\*.*" ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary.Client" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CS.CustomTypeEditor\CustomControlLibrary.Server\*.*" ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary.Server" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\CS.CustomTypeEditor\CustomControlLibrary.Package\*.*" ".\Templates\Templates\CS.TypeEditor\CustomControlLibrary.Package" /s /e /c /f /y /i

rmdir ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary" /s /q
rmdir ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary.Protocol" /s /q
rmdir ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary.Client" /s /q
rmdir ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary.Server" /s /q
rmdir ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary.Package" /s /q

xcopy ".\TemplateSolutions\VB.CustomTypeEditor\CustomControlLibrary\*.*" ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\VB.CustomTypeEditor\CustomControlLibrary.Protocol\*.*" ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary.Protocol" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\VB.CustomTypeEditor\CustomControlLibrary.Client\*.*" ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary.Client" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\VB.CustomTypeEditor\CustomControlLibrary.Server\*.*" ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary.Server" /s /e /c /f /y /i
xcopy ".\TemplateSolutions\VB.CustomTypeEditor\CustomControlLibrary.Package\*.*" ".\Templates\Templates\VB.TypeEditor\CustomControlLibrary.Package" /s /e /c /f /y /i

cd Templates
dotnet new uninstall Microsoft.WinForms.Designer.TypeEditorTemplate
dotnet pack
dotnet new install .\bin\Debug\Microsoft.WinForms.Designer.TypeEditorTemplate.1.1.0-prerelease-preview3.nupkg

cd ..
