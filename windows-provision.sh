@powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))"
set PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin
choco install dotnet-sdk -y
choco install dotnet-runtime --version=8.0.0 -y

set PATH=%PATH%;C:\Program Files\dotnet
setx PATH "%PATH%;C:\Program Files\dotnet"

dotnet --version

dotnet nuget add source http://10.0.2.2:5555/v3/index.json -n Baget
dotnet tool install --global AKarandashov --version 1.0.1

dotnet run --project Lab4 run Lab1 -I C:/vagrant/Lab1/Files/INPUT.txt -o C:/vagrant/Lab1/Files/OUTPUT.txt