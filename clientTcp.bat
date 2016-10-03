echo off
ECHO 'Start...'

"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" Card.Game.sln 
start Server.Runner\bin\Debug\Server.Runner.exe

start Client.TCP\bin\Debug\Client.TCP.exe