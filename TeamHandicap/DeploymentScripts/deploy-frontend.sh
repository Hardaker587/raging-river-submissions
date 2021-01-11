#!/bin/bash

# Build frontend
cd ../restaurants-nuxt-app
sudo npm install
sudo pm2 stop restaurants-app
sudo npm run build
sudo pm2 restart restaurants-app
echo 'Frontend deploy done!'
