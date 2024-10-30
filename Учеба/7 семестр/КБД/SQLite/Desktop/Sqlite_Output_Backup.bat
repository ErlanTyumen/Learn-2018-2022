@echo off
cd C:\SQLite
sqlite3 < C:\commands.txt 
sqlite3 C:\Logs.db "INSERT INTO Logs VALUES('Hotels.db','Backup_output',strftime('%%Y-%%m-%%d %%H:%%M:%%f') , julianday('now'), strftime('%%s','now'));"