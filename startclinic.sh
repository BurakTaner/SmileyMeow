#! /bin/bash
RED="\033[0;31m"
BLUE="\033[0;34m"
GREEN="\033[0;32m"

# dotnet
dotnet run --project AnimalAPI &
dotnet run  --project SmileyMeow & 

# nodejs
npm --prefix LocationsNodeAPI start & 
sleep 12
clear
echo -e "${RED}ANIMALAPI is listening on https://localhost:7180/swagger/index.html if you want to test it"
echo -e "${BLUE}SMILEYMEOW is listening on  https://localhost:7041 if you want to test it"
echo -e "${GREEN}LOCATIONSAPI is listening on  http://localhost:3000 if you want to test it."
echo -e "${GREEN}Endpoints are for nodejs is:"
echo -e "${GREEN}/insertdistricts" 
echo -e "${GREEN}/insertcities"
echo -e "${GREEN}/deletedistricts"
echo -e "${GREEN}/deletecities" 
echo -e "${GREEN}/getalldistricts"
echo -e "${GREEN}/getdistrict/id // id: cityId"
echo -e "${GREEN}/getallcities"
