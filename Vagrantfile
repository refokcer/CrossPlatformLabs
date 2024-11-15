Vagrant.configure("2") do |config|
    config.vm.box = "ubuntu/focal64"
  
    config.vm.network "forwarded_port", guest: 5555, host: 5555
  
    config.vm.provision "shell", inline: <<-SHELL
      # Установка Docker
      sudo apt-get update
      sudo apt-get install -y docker.io
  
      # Установка Docker Compose
      sudo curl -L "https://github.com/docker/compose/releases/download/1.29.2/docker-compose-\$(uname -s)-\$(uname -m)" -o /usr/local/bin/docker-compose
      sudo chmod +x /usr/local/bin/docker-compose
  
      # Запуск BaGet
      mkdir BaGet
      cd BaGet
      cat <<EOF > docker-compose.yml
      version: '3'
  
      services:
        baget:
          image: loicsharma/baget:latest
          ports:
            - "5555:80"
          environment:
            - Baget__Storage__Type=FileSystem
            - Baget__Storage__Path=/var/baget/packages
            - Baget__Database__Type=Sqlite
            - Baget__Database__ConnectionString=Data Source=/var/baget/baget.db
          volumes:
            - ./data:/var/baget
      EOF
      sudo docker-compose up -d
  
      # Установка .NET SDK
      wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
      sudo dpkg -i packages-microsoft-prod.deb
      sudo apt-get update
      sudo apt-get install -y dotnet-sdk-6.0
  
      # Настройка NuGet
      mkdir /home/vagrant/.nuget
      cat <<EOF > /home/vagrant/.nuget/NuGet.Config
      <?xml version="1.0" encoding="utf-8"?>
      <configuration>
        <packageSources>
          <add key="LocalBaGet" value="http://localhost:5555/v3/index.json" />
        </packageSources>
      </configuration>
      EOF
  
      # Установка инструмента
      dotnet tool install --global AKarandashov --version 1.0.0 --add-source http://localhost:5555/v3/index.json
  
    SHELL
  end
  