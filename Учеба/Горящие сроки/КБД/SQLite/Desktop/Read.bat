@echo off
cd C:\SQLite
sqlite3 C:\SQLite\NewHotels.db ".read C:\SQLite\Dump.sql"
sqlite3 C:\SQLite\Logs.db "INSERT INTO Logs VALUES('NewHotels.db','Read',strftime('%%Y-%%m-%%d %%H:%%M:%%f') , julianday('now'), strftime('%%s'));"