@echo off
cd C:\SQLite
sqlite3 C:\SQLite\Hotels.db ".backup 'C:\SQLite\Backup.db'"
sqlite3 C:\Logs.db "INSERT INTO Logs VALUES('Hotels.db','Backup',strftime('%%Y-%%m-%%d %%H:%%M:%%f') , julianday('now'), strftime('%%s'));"