rem Build Objects
candle -out obj\%1\EnvManSetup.wixobj EnvManSetup.wxs
candle -out obj\%1\Files.wixobj Files.wxs

rem Build Msi
light obj\%1\*.wixobj -out bin\%1\EnvManSetup.msi

