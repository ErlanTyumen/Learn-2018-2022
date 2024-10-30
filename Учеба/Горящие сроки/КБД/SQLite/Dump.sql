PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Branches] (
   [HotelId] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
   [Name] varchar(50) NOT NULL COLLATE NOCASE,
   [Address] varchar(50) NOT NULL COLLATE NOCASE,
   [PhoneNumber] varchar(50) NOT NULL COLLATE NOCASE,
   [DirectorId] int,
   CONSTRAINT [FK_Branches_Staff] FOREIGN KEY ([DirectorId])
      REFERENCES [Employees]([EmployeeId]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
INSERT INTO Branches VALUES(2,'Заря','Перекопская 25','22896',NULL);
INSERT INTO Branches VALUES(3,'Ладья','Свердлова 97','23678',NULL);
INSERT INTO Branches VALUES(4,'Плутон','Маяковского 10','21332',NULL);
CREATE TABLE [Clients] (
   [ClientId] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
   [SecondName] nchar(20) COLLATE NOCASE,
   [Name] nchar(20) COLLATE NOCASE,
   [DOB] date COLLATE NOCASE
);
INSERT INTO Clients VALUES(85,'Иванов','Иван','2021-02-24 00:00:00');
INSERT INTO Clients VALUES(87,'Ивашко','Генадий','2017-06-22 00:00:00');
INSERT INTO Clients VALUES(88,'Самойлов','Илья','2021-03-09 00:00:00');
INSERT INTO Clients VALUES(89,'Окопов','Влад','2021-03-08 00:00:00');
CREATE TABLE [Employees] (
   [EmployeeId] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
   [BranchId] int,
   [Name] varchar(50) NOT NULL COLLATE NOCASE,
   [SecondName] varchar(50) COLLATE NOCASE,
   [PhoneNumber] varchar(50) COLLATE NOCASE,
   [PositionId] int,
   CONSTRAINT [FK_Staff_Branches] FOREIGN KEY ([BranchId])
      REFERENCES [Branches]([HotelId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
   CONSTRAINT [FK_Staff_Position] FOREIGN KEY ([PositionId])
      REFERENCES [Positions]([PositionId]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
INSERT INTO Employees VALUES(19,3,'Евгений','Ступин','+78964567895',2);
INSERT INTO Employees VALUES(20,4,'Иван ','Иванов','+78956121254',4);
INSERT INTO Employees VALUES(21,2,'Сергей','Сергеев','+79854568954',4);
INSERT INTO Employees VALUES(22,3,'Владимир','Крупин','+78954564512',4);
INSERT INTO Employees VALUES(25,2,'Никита','Рядов','+78456988456',3);
INSERT INTO Employees VALUES(26,3,'Константин','Рябов','+74441267895',3);
INSERT INTO Employees VALUES(31,4,'Иван','Петрович','+78005553535',2);
INSERT INTO Employees VALUES(33,4,'Дмитрий','Середкин','+78005553538',2);
INSERT INTO Employees VALUES(35,4,'Георгий','Смолин','+78954126426',1);
INSERT INTO Employees VALUES(36,2,'ewew','ewrwr','ewewrer',1);
INSERT INTO Employees VALUES(37,4,'Игорь','Токач','89932227615',2);
CREATE TABLE [Orders] (
   [OrderId] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
   [RoomId] int,
   [ClientId] int NOT NULL,
   [Arrival] date COLLATE NOCASE,
   [Departure] date COLLATE NOCASE,
   [Sum] money,
   [IsActive] bit NOT NULL,
   [DateOfBooking] date COLLATE NOCASE,
   CONSTRAINT [FK_Order_RoomCondition] FOREIGN KEY ([RoomId])
      REFERENCES [Rooms]([RoomId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
   CONSTRAINT [FK_Order_Client] FOREIGN KEY ([ClientId])
      REFERENCES [Clients]([ClientId]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
INSERT INTO Orders VALUES(77,9,85,'2021-02-24 00:00:00','2021-03-27 00:00:00',155000,1,NULL);
INSERT INTO Orders VALUES(79,6,87,'2021-02-22 00:00:00','2021-03-27 00:00:00',132000,1,NULL);
INSERT INTO Orders VALUES(80,2,89,'2021-03-01 00:00:00','2021-03-20 00:00:00',28500,1,NULL);
INSERT INTO Orders VALUES(81,5,89,'2021-03-21 00:00:00','2021-03-31 00:00:00',30000,1,NULL);
INSERT INTO Orders VALUES(83,1,88,'2021-06-08 00:00:00','2021-06-09 00:00:00',222,0,'2021-06-07 00:00:00');
CREATE TABLE [Positions] (
   [PositionId] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
   [Position] varchar(50) COLLATE NOCASE
);
INSERT INTO Positions VALUES(1,'Директор');
INSERT INTO Positions VALUES(2,'Дежурный по комнатам');
INSERT INTO Positions VALUES(3,'Ресепшн');
INSERT INTO Positions VALUES(4,'Охрана');
CREATE TABLE [RoomCategories] (
   [CategoryId] int NOT NULL,
   [Category] varchar(50) COLLATE NOCASE,
   [NumberOfSeats] int NOT NULL,
   [NumberOfRooms] int NOT NULL,
   [PriceForDay] money NOT NULL,
   PRIMARY KEY ([CategoryId])
);
INSERT INTO RoomCategories VALUES(1,'Эконом(1)',1,1,1500);
INSERT INTO RoomCategories VALUES(2,'Эконом(2)',2,1,2250);
INSERT INTO RoomCategories VALUES(3,'Стандарт(1)',1,2,3000);
INSERT INTO RoomCategories VALUES(4,'Стандарт(2)',2,2,4000);
INSERT INTO RoomCategories VALUES(5,'Стандарт(3)',3,2,4750);
INSERT INTO RoomCategories VALUES(6,'Люкс(1)',1,3,5000);
INSERT INTO RoomCategories VALUES(7,'Люкс(2)',2,4,6250);
CREATE TABLE [Rooms] (
   [RoomId] int NOT NULL,
   [BranchId] int,
   [EmployeeId] int,
   [CategoryId] int,
   PRIMARY KEY ([RoomId]),
   CONSTRAINT [FK_RoomCondition_RoomCategories] FOREIGN KEY ([CategoryId])
      REFERENCES [RoomCategories]([CategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
   CONSTRAINT [FK_RoomCondition_Branches] FOREIGN KEY ([BranchId])
      REFERENCES [Branches]([HotelId]) ON DELETE NO ACTION ON UPDATE NO ACTION,
   CONSTRAINT [FK_RoomCondition_Staff] FOREIGN KEY ([EmployeeId])
      REFERENCES [Employees]([EmployeeId]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
INSERT INTO Rooms VALUES(1,2,NULL,1);
INSERT INTO Rooms VALUES(2,3,NULL,1);
INSERT INTO Rooms VALUES(3,2,NULL,2);
INSERT INTO Rooms VALUES(4,3,19,2);
INSERT INTO Rooms VALUES(5,3,NULL,3);
INSERT INTO Rooms VALUES(6,4,33,4);
INSERT INTO Rooms VALUES(7,3,NULL,4);
INSERT INTO Rooms VALUES(8,3,19,5);
INSERT INTO Rooms VALUES(9,4,37,6);
INSERT INTO Rooms VALUES(10,4,31,7);
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('Branches',4);
INSERT INTO sqlite_sequence VALUES('Clients',89);
INSERT INTO sqlite_sequence VALUES('Employees',37);
INSERT INTO sqlite_sequence VALUES('Orders',83);
INSERT INTO sqlite_sequence VALUES('Positions',4);
COMMIT;
