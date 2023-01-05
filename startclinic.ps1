Start-Job -Name AnimalAPI -ScriptBlock { & "dotnet" "run" "--project" ".\AnimalAPI" }
Start-Job -Name SmileyMeow -ScriptBlock { & "dotnet" "run" "--project" ".\SmileyMeow" }
Start-Job -Name LocationsNodeAPI -ScriptBlock { & "npm" "--prefix" "LocationsNodeAPI\" "start" }
Start-Sleep 1
cls
Write-Host "ANIMALAPI is listening on https://localhost:7180/swagger/index.html if you want to test it" -ForegroundColor Cyan -BackgroundColor black

Write-Host "SMILEYMEOW is listening on "  " if you want to test it" -ForegroundColor yellow -BackgroundColor black


Write-Host "LOCATIONSAPI is listening on https://localhost:3000 if you want to test it" -ForegroundColor green -BackgroundColor black

Write-host "Endpoints are for nodejs is:" -ForegroundColor green -BackgroundColor black
Write-host "/insertdistricts" -ForegroundColor green -BackgroundColor black
Write-host "/insertcities" -ForegroundColor green -BackgroundColor black
Write-host "/deletedistricts" -ForegroundColor green -BackgroundColor black
Write-host "/deletecities" -ForegroundColor green -BackgroundColor black
Write-host "/getalldistricts" -ForegroundColor green -BackgroundColor black
Write-host "/getlallcities" -ForegroundColor green -BackgroundColor black
Write-host "/getdistrict/id // id: cityId" -ForegroundColor green -BackgroundColor black
