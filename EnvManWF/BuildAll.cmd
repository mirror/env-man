msbuild EnvMan2010.sln /p:Configuration=Release
msbuild EnvMan2010.sln /p:Configuration=Debug
cd EnvMan.Tests
NUnit.exe EnvMan.Tests.nunit
cd ..
