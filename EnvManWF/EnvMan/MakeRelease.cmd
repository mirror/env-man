mkdir Release
xcopy ..\Readme.txt Release /Y
xcopy ..\license.txt Release /Y
ilmerge /out:Release\EnvMan.exe EnvMan\bin\Release\EnvMan.exe EnvMan\bin\Release\EnvManager.dll
del Release\EnvMan.pdb /Q
