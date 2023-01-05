cls
Get-Job | select Id | Remove-Job -Force

write-host "All of the programs has been killed, thank you for using my application"
