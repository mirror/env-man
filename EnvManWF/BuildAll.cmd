msbuild EnvMan2008.sln /p:Configuration=Release
msbuild EnvMan2008.sln /p:Configuration=Debug
cd EnvMan.Tests
NUnit.exe EnvMan.Tests.nunit
cd ..
