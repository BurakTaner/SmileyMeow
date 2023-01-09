#! /bin/bash
clear
killpids=$(pgrep -f "dotnet run --project")
fuser 3000/tcp -k
kill $killpids
sleep 1
clear
echo -e "All of the programs has been killed, thank you for using my application"
