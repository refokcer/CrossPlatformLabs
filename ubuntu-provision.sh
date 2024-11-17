sudo apt update

sudo apt install -y dotnet-sdk-8.0

dotnet --version

cd /vagrant/Lab4

dotnet nuget add source http://10.0.2.2:5555/v3/index.json -n Baget
dotnet tool install --global AKarandashov --version 1.0.1 --add-source http://10.0.2.2:5555/v3/index.json

cd /vagrant
dotnet run --project Lab4 run Lab1 -I /vagrant/Lab1/Files/INPUT.txt -o /vagrant/Lab1/Files/OUTPUT.txt