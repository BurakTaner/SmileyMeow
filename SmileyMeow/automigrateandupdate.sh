#! /bin/bash

MAIN_MENU() {

echo -e " \nWhat do you want?"

read INPUT

case $INPUT in 

migration) ADD_MIGRATION_AND_UPDATE_DATABASE ;;
drop) DROP_DATABASE_AND_REMOVE_MIGRATION ;;
esac
}
ADD_MIGRATION_AND_UPDATE_DATABASE() {

echo -e "\nMigration name"

read MIGRATIONNAME


dotnet ef migrations add "$MIGRATIONNAME"

dotnet ef database update
}

DROP_DATABASE_AND_REMOVE_MIGRATION() {

dotnet ef database drop -f

dotnet ef migrations remove

}


MAIN_MENU
