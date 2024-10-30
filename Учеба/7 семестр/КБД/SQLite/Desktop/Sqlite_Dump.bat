@echo off
cd C:\SQLite
sqlite3 C:\SQLite\Hotels.db .dump > C:\SQLite\Dump.sql
sqlite3 C:\SQLite\Logs.db "INSERT INTO Logs VALUES('Hotels.db','Dump',strftime('%%Y-%%m-%%d %%H:%%M:%%f') , julianday('now'), strftime('%%s'));"