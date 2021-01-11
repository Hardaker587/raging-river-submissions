#!/bin/bash

# Build backend

cd ../Restaurants.Users.Api
sudo systemctl stop restaurants-api.service
sudo dotnet publish --configuration Release -o /var/aspnetcore/Restaurants.Users.Api
sudo systemctl start restaurants-api.service
echo 'Backend deploy done!'



