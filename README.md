# Gym 

## Описание

Gym - это WPF приложение для управления клиентами, тренерами, оборудованием и тренировками в фитнес-клубе. Приложение поддерживает многопользовательский доступ с различными уровнями прав (администраторы, тренеры, менеджеры) и предоставляет функции добавления, редактирования и удаления данных, а также генерации отчетов.

## Функциональность

### Клиенты
- Добавление, редактирование и удаление данных о клиентах (ФИО, контактная информация, абонемент, тренер).
- Запись клиентов на тренировки к конкретным тренерам.
- Ввод информации о посещаемости клиентов (дата и время тренировки).
- Поиск клиентов по различным критериям.

### Тренеры
- Добавление, редактирование и удаление данных о тренерах (ФИО, специализация, расписание).
- Просмотр и управление своими клиентами и их тренировками.

### Оборудование
- Добавление, редактирование и удаление данных о тренажерах (название, описание, доступность).
- Поиск оборудования по различным критериям.

### Тренировки
- Запись клиентов на тренировки.
- Отслеживание посещаемости клиентов.
- Генерация отчетов по клиентам, тренерам, тренажерам.

### Отчеты
- Список клиентов с абонементами.
- Популярные тренеры.
- Загруженность зала по дням недели.
- Статистика посещаемости клиентов.

### Пользователи
- Администраторы могут добавлять/удалять/редактировать клиентов, тренеров, тренажеры, настраивать систему, просматривать все отчеты.
- Тренеры могут просматривать своих клиентов, записывать их на тренировки, вносить данные о посещаемости, просматривать отчеты по своим клиентам.
- Менеджеры могут просматривать информацию о клиентах, тренерах, тренажерах, генерировать отчеты, управлять абонементами.

## Используемые технологии

- ![C#](https://img.shields.io/badge/-C%23-239120?logo=c-sharp&logoColor=white&style=for-the-badge)  - Основной язык программирования.
- ![WPF](https://img.shields.io/badge/-WPF-5C2D91?logo=windows&logoColor=white&style=for-the-badge)  - Windows Presentation Foundation для создания графического интерфейса.
- ![.NET](https://img.shields.io/badge/-.NET-512BD4?logo=dotnet&logoColor=white&style=for-the-badge)  - Использование .NET Framework 4.8.
- ![MSSQL](https://img.shields.io/badge/-MSSQL-CC2927?logo=microsoft-sql-server&logoColor=white&style=for-the-badge)  - База данных для хранения информации.
- ![MVVM](https://img.shields.io/badge/-MVVM-007ACC?logo=visual-studio&logoColor=white&style=for-the-badge)  - Model-View-ViewModel для структурирования кода.

## База данных

![](https://github.com/gjotov/Gym/blob/master/Diagrams/Database%20Scheme.png)

### Структура базы данных

База данных **MSSQL Server** содержит следующие таблицы:

- **Clients**: информация о клиентах (Id, Name, ContactInfo, Membership, TrainerId)
- **Trainers**: информация о тренерах (Id, Name, Specialization, Schedule)
- **Equipment**: информация о тренажерах (Id, Name, Description, IsAvailable)
- **Sessions**: информация о тренировках (Id, ClientId, TrainerId, SessionDate)

### Пример SQL скриптов

```sql
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
```
## Снимки экрана

Снимки экрана доступны [по этой ссылке.](https://drive.google.com/drive/folders/1o2JlKVG3aKm5f6_i4pXT_iaSu9DUGSQI?usp=sharing)
