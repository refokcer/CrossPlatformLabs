# -*- mode: ruby -*-
# vi: set ft=ruby :

# All Vagrant configuration is done below. The "2" in Vagrant.configure
# configures the configuration version (we support older styles for
# backwards compatibility). Please don't change it unless you know what
# you're doing.
Vagrant.configure("2") do |config|
  # Define Ubuntu VM
  config.vm.define "ubuntu" do |ubuntu|
    ubuntu.vm.box = "ubuntu/jammy64"
    ubuntu.vm.hostname = "ubuntu-vm"
    ubuntu.vm.network "forwarded_port", guest: 5555, host: 5000
    ubuntu.vm.network "private_network", type: "static", ip: "192.168.56.10"
    ubuntu.vm.provider "virtualbox" do |vb|
      vb.memory = "2024"
      vb.cpus = 2
    end
    ubuntu.vm.provision "shell", path: "ubuntu-provision.sh"
  end

  # Define Windows VM
  config.vm.define "windows" do |windows|
    windows.vm.box = "gusztavvargadr/windows-10"
    windows.vm.hostname = "windows-vm"
    windows.vm.network "private_network", type: "static", ip: "192.168.56.20"
    windows.vm.network "forwarded_port", guest: 5555, host: 6000
    windows.vm.provider "virtualbox" do |vb|
      vb.memory = "6096"
      vb.cpus = 4
      vb.customize ["modifyvm", :id, "--nictype1", "82540EM"]
      vb.customize ["modifyvm", :id, "--nictype2", "82540EM"]
    end
    windows.vm.provision "shell", path: "windows-provision.sh"
  end
end