CREATE DATABASE [GymAppDb]
Go
USE [GymAppDb]
CREATE TABLE [User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Login] NVARCHAR(256) NOT NULL,
	[PasswordHash] NVARCHAR(100) NOT NULL,
	[Role] NVARCHAR(50) NOT NULL
)
CREATE TABLE [TrainerInfo] 
(
	[TrainerId] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] INT NOT NULL REFERENCES [User](UserId) ON DELETE CASCADE ON UPDATE NO ACTION,
	[Name] NVARCHAR(500) NOT NULL,
	[Specialization] NVARCHAR(1000) NOT NULL,
	[Schedule] NVARCHAR(200) NOT NULL
)
CREATE TABLE [Aboniment] 
(
	[AbonimentId] INT NOT NULL PRIMARY KEY IDENTITY,
	[PurchaseDate] DATE NOT NULL,
	[DeadlineDate] DATE NOT NULL,
	[Price] MONEY NOT NULL
)
CREATE TABLE [Equipment] 
(
	[EquipmentId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(1000) NOT NULL,
	[Description] NVARCHAR(2000) NULL
)
CREATE TABLE [Client]
(
	[ClientId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(500) NOT NULL,
	[Phone] NVARCHAR(20) NOT NULL,
	[Email] NVARCHAR(1000) NULL,
	[AbonimentId] INT NOT NULL REFERENCES [Aboniment](AbonimentId) ON DELETE CASCADE ON UPDATE NO ACTION,
	[TrainerId] INT NOT NULL REFERENCES [TrainerInfo](TrainerId) ON DELETE NO ACTION ON UPDATE NO ACTION
)
CREATE TABLE [Session]
(
	[SessionId] INT NOT NULL PRIMARY KEY IDENTITY,
	[ClientId] INT NOT NULL REFERENCES [Client](ClientId) ON DELETE NO ACTION ON UPDATE NO ACTION,
	[TrainerId] INT NOT NULL REFERENCES [TrainerInfo] ON DELETE NO ACTION ON UPDATE NO ACTION,
	[SessionStartDateTime] DATETIME NOT NULL,
	[SessionDate] DATE NOT NULL,
	[SessionTime] TIME NOT NULL
)

--default password for admin = password
INSERT INTO [User] values
('admin', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'Admin')