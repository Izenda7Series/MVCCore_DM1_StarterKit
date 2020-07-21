#! /bin/bash

MVCConnectionString=$(sed -e 's/[]\/$*.^[]/\\&/g;s/ /\\ /g' <<< "$1")
IzendaConnectionString=$(sed -e 's/[]\/$*.^[]/\\&/g;s/ /\\ /g' <<< "$2")

echo Update connection strings in config file

echo MVC database connection string: $1
echo Izenda database connection string: $2

sed -i "s/MVC_DB/$MVCConnectionString/g" ./appsettings.json
sed -i "s/IZENDA_DB/$IzendaConnectionString/g" ./izendadb.config

dotnet MVCCoreStarterKit.dll