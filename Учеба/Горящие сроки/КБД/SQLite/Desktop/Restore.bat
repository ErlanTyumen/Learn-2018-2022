@echo off
cd C:\SQLite
sqlite3 C:\SQLite\NewHotels.db ".restore C:\SQLite\Backup.db"
sqlite3 C:\Logs.db "INSERT INTO Logs VALUES('NewHotels.db','Restore',strftime('%%Y-%%m-%%d %%H:%%M:%%f') , julianday('now'), strftime('%%s'));"