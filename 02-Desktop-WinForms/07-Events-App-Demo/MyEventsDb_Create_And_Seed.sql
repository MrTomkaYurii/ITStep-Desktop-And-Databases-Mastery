-- ============================================================================
-- MyEvents Database Creation & Seeding Script
-- Platform: Microsoft SQL Server (LocalDB, SQL Express, Azure SQL)
-- Project: Step-WinForms-07-Events-App-Demo (MyEventsWF)
-- ============================================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'MyEventsDb')
BEGIN
    CREATE DATABASE [MyEventsDb];
END
GO

USE [MyEventsDb];
GO

-- 1. ROLES
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Roles] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [name] NVARCHAR(50) NOT NULL CONSTRAINT [UQ_Roles_Name] UNIQUE
    );
END
GO

-- 2. CITIES
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cities]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Cities] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [name] NVARCHAR(100) NOT NULL
    );
END
GO

-- 3. COUNTRIES
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Countries]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Countries] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [name] NVARCHAR(50) NOT NULL CONSTRAINT [UQ_Countries_Name] UNIQUE,
        [city_id] INT NULL CONSTRAINT [FK_Countries_Cities] FOREIGN KEY REFERENCES [dbo].[Cities]([id])
    );
END
GO

-- 4. USERS
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Users] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [first_name] NVARCHAR(50) NOT NULL,
        [second_name] NVARCHAR(50) NOT NULL,
        [email] NVARCHAR(50) NOT NULL CONSTRAINT [UQ_Users_Email] UNIQUE,
        [password] NVARCHAR(50) NOT NULL,
        [role_id] INT NOT NULL CONSTRAINT [FK_Users_Roles] FOREIGN KEY REFERENCES [dbo].[Roles]([id]),
        [country_id] INT NULL CONSTRAINT [FK_Users_Countries] FOREIGN KEY REFERENCES [dbo].[Countries]([id]),
        [city_id] INT NULL CONSTRAINT [FK_Users_Cities] FOREIGN KEY REFERENCES [dbo].[Cities]([id])
    );
END
GO

-- 5. CATEGORIES
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Categories] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [name] NVARCHAR(100) NOT NULL
    );
END
GO

-- 6. GALLERIES
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Galleries]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Galleries] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [name] NVARCHAR(100) NOT NULL CONSTRAINT [UQ_Galleries_Name] UNIQUE
    );
END
GO

-- 7. EVENTS
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Events]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Events] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [name] NVARCHAR(250) NOT NULL CONSTRAINT [UQ_Events_Name] UNIQUE,
        [user_id] INT NULL CONSTRAINT [FK_Events_Users] FOREIGN KEY REFERENCES [dbo].[Users]([id]),
        [country_id] INT NULL CONSTRAINT [FK_Events_Countries] FOREIGN KEY REFERENCES [dbo].[Countries]([id]),
        [city_id] INT NULL CONSTRAINT [FK_Events_Cities] FOREIGN KEY REFERENCES [dbo].[Cities]([id]),
        [gallery_id] INT NULL CONSTRAINT [FK_Events_Galleries] FOREIGN KEY REFERENCES [dbo].[Galleries]([id]),
        [time_of_event] TIME NULL,
        [date_of_event] DATE NULL,
        [address] NCHAR(80) NULL,
        [acceptable_age] INT NULL,
        [cost_of_visit] FLOAT NULL
    );
END
GO

-- 8. CATEGORIES_EVENTS (Many-to-Many)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoriesEvents]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[CategoriesEvents] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [categories_id] INT NOT NULL CONSTRAINT [FK_CategoriesEvents_Categories] FOREIGN KEY REFERENCES [dbo].[Categories]([id]),
        [events_id] INT NOT NULL CONSTRAINT [FK_CategoriesEvents_Events] FOREIGN KEY REFERENCES [dbo].[Events]([id])
    );
END
GO

-- 9. IMAGES
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Images]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Images] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [name] NVARCHAR(300) NOT NULL CONSTRAINT [UQ_Images_Name] UNIQUE,
        [gallery_id] INT NULL CONSTRAINT [FK_Images_Galleries] FOREIGN KEY REFERENCES [dbo].[Galleries]([id]),
        [user_id] INT NULL CONSTRAINT [FK_Images_Users] FOREIGN KEY REFERENCES [dbo].[Users]([id]),
        [ImageBytes] VARBINARY(MAX) NULL
    );
END
GO

-- 10. MESSAGES (Forum)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Messages]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Messages] (
        [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [user_id] INT NULL CONSTRAINT [FK_Messages_Users] FOREIGN KEY REFERENCES [dbo].[Users]([id]),
        [event_id] INT NULL CONSTRAINT [FK_Messages_Events] FOREIGN KEY REFERENCES [dbo].[Events]([id]),
        [message] NVARCHAR(500) NULL
    );
END
GO

-- ============================================================================
-- SEED DATA
-- ============================================================================

-- Seed Roles
IF NOT EXISTS (SELECT 1 FROM [dbo].[Roles])
BEGIN
    SET IDENTITY_INSERT [dbo].[Roles] ON;
    INSERT INTO [dbo].[Roles] ([id], [name]) VALUES
        (1, N'Admin'),
        (2, N'Organizer'),
        (3, N'Participant');
    SET IDENTITY_INSERT [dbo].[Roles] OFF;
END
GO

-- Seed Cities
IF NOT EXISTS (SELECT 1 FROM [dbo].[Cities])
BEGIN
    SET IDENTITY_INSERT [dbo].[Cities] ON;
    INSERT INTO [dbo].[Cities] ([id], [name]) VALUES
        (1, N'Київ'),
        (2, N'Львів'),
        (3, N'Одеса'),
        (4, N'Чернівці'),
        (5, N'Харків');
    SET IDENTITY_INSERT [dbo].[Cities] OFF;
END
GO

-- Seed Countries
IF NOT EXISTS (SELECT 1 FROM [dbo].[Countries])
BEGIN
    SET IDENTITY_INSERT [dbo].[Countries] ON;
    INSERT INTO [dbo].[Countries] ([id], [name], [city_id]) VALUES
        (1, N'Україна', 1),
        (2, N'Польща', NULL);
    SET IDENTITY_INSERT [dbo].[Countries] OFF;
END
GO

-- Seed Users
IF NOT EXISTS (SELECT 1 FROM [dbo].[Users])
BEGIN
    SET IDENTITY_INSERT [dbo].[Users] ON;
    INSERT INTO [dbo].[Users] ([id], [first_name], [second_name], [email], [password], [role_id], [country_id], [city_id]) VALUES
        (1, N'Юрій', N'Томка', N'yurii.tomka@itstep.edu', N'Admin2026!', 1, 1, 4),
        (2, N'Олена', N'Коваленко', N'olena.k@example.com', N'User2026!', 2, 1, 1),
        (3, N'Андрій', N'Мельник', N'andriy.m@example.com', N'User2026!', 3, 1, 2);
    SET IDENTITY_INSERT [dbo].[Users] OFF;
END
GO

-- Seed Categories
IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories])
BEGIN
    SET IDENTITY_INSERT [dbo].[Categories] ON;
    INSERT INTO [dbo].[Categories] ([id], [name]) VALUES
        (1, N'IT & Програмування'),
        (2, N'Дизайн & Арт'),
        (3, N'Бізнес & Стартапи'),
        (4, N'Наука та Інновації'),
        (5, N'Освіта та Воркшопи');
    SET IDENTITY_INSERT [dbo].[Categories] OFF;
END
GO

-- Seed Galleries
IF NOT EXISTS (SELECT 1 FROM [dbo].[Galleries])
BEGIN
    SET IDENTITY_INSERT [dbo].[Galleries] ON;
    INSERT INTO [dbo].[Galleries] ([id], [name]) VALUES
        (1, N'IT STEP Tech Day Photo Gallery'),
        (2, N'Architecture Summit Lviv Gallery'),
        (3, N'Chernivtsi Code & Coffee Gallery');
    SET IDENTITY_INSERT [dbo].[Galleries] OFF;
END
GO

-- Seed Events
IF NOT EXISTS (SELECT 1 FROM [dbo].[Events])
BEGIN
    SET IDENTITY_INSERT [dbo].[Events] ON;
    INSERT INTO [dbo].[Events] ([id], [name], [user_id], [country_id], [city_id], [gallery_id], [time_of_event], [date_of_event], [address], [acceptable_age], [cost_of_visit]) VALUES
        (1, N'.NET 10 & WinForms Modernization Meetup', 1, 1, 1, 1, '18:00:00', '2026-07-15', N'вул. Хрещатик, 22', 16, 0.0),
        (2, N'Lviv Software Architecture Day 2026', 2, 1, 2, 2, '10:00:00', '2026-07-22', N'пл. Ринок, 10', 18, 500.0),
        (3, N'Chernivtsi Code & Coffee Fest', 1, 1, 4, 3, '11:30:00', '2026-07-28', N'вул. Університетська, 28', 14, 150.0),
        (11, N'Grand IT STEP Academy Demo Day 2026', 1, 1, 1, 1, '17:00:00', '2026-07-31', N'вул. Спортивна, 1', 16, 250.0);
    SET IDENTITY_INSERT [dbo].[Events] OFF;
END
GO

-- Seed CategoriesEvents
IF NOT EXISTS (SELECT 1 FROM [dbo].[CategoriesEvents])
BEGIN
    SET IDENTITY_INSERT [dbo].[CategoriesEvents] ON;
    INSERT INTO [dbo].[CategoriesEvents] ([id], [categories_id], [events_id]) VALUES
        (1, 1, 1),
        (2, 5, 1),
        (3, 1, 2),
        (4, 3, 2),
        (5, 1, 3),
        (6, 1, 11),
        (7, 5, 11);
    SET IDENTITY_INSERT [dbo].[CategoriesEvents] OFF;
END
GO

-- Seed Messages
IF NOT EXISTS (SELECT 1 FROM [dbo].[Messages])
BEGIN
    SET IDENTITY_INSERT [dbo].[Messages] ON;
    INSERT INTO [dbo].[Messages] ([id], [user_id], [event_id], [message]) VALUES
        (1, 1, 1, N'Вітаємо всіх учасників мітапу з модернізації на .NET 10!'),
        (2, 2, 1, N'Чи буде онлайн-трансляція для студентів інших філій?'),
        (3, 1, 1, N'Так, запис та стрім будуть доступні в особистому кабінеті.'),
        (4, 3, 11, N'Готуємо фінальні дипломні проекти до презентації на Demo Day!');
    SET IDENTITY_INSERT [dbo].[Messages] OFF;
END
GO

PRINT 'MyEventsDb schema and seed data created successfully.';
