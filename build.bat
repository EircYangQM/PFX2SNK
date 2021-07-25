"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\amd64\MSBuild.exe" PFX2SNK.csproj -t:Rebuild -p:Configuration=Release -noLogo
mkdir publish
copy bin\Release\* publish