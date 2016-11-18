echo off
ECHO 'Start...'

"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" All.sln 
dotnet Server.Runer\bin\Debug\Server.Runer.dll

dotnet Client.TCP\bin\Debug\Client.TCP.dll