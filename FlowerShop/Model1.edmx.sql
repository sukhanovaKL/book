
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2021 08:29:48
-- Generated from EDMX file: C:\Users\79393\source\repos\Flower_Shop\FlowerShop\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FlowerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_ClientUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ColleagueUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_ColleagueUser];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_OrderClient];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOrderTovar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderTovarSet] DROP CONSTRAINT [FK_OrderOrderTovar];
GO
IF OBJECT_ID(N'[dbo].[FK_TovarOrderTovar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderTovarSet] DROP CONSTRAINT [FK_TovarOrderTovar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[ColleagueSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ColleagueSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[OrderTovarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderTovarSet];
GO
IF OBJECT_ID(N'[dbo].[TovarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TovarSet];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Colleague_Id] int  NULL,
    [Client_Id] int  NULL
);
GO

-- Creating table 'ColleagueSet'
CREATE TABLE [dbo].[ColleagueSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [surname] nvarchar(max)  NOT NULL,
    [patronymic] nvarchar(max)  NOT NULL,
    [post] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [money] int  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [surname] nvarchar(max)  NOT NULL,
    [patronymic] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [photo] varbinary(max)  NOT NULL,
    [money] int  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [data] nvarchar(max)  NOT NULL,
    [isObrabotan] bit  NULL,
    [price] int  NOT NULL,
    [Client_Id] int  NULL
);
GO

-- Creating table 'OrderTovarSet'
CREATE TABLE [dbo].[OrderTovarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sum] int  NOT NULL,
    [Order_Id] int  NULL,
    [Tovar_Id] int  NULL
);
GO

-- Creating table 'TovarSet'
CREATE TABLE [dbo].[TovarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name_t] nvarchar(max)  NOT NULL,
    [sum] int  NOT NULL,
    [type] nvarchar(max)  NOT NULL,
    [price] int  NOT NULL,
    [photo] varbinary(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ColleagueSet'
ALTER TABLE [dbo].[ColleagueSet]
ADD CONSTRAINT [PK_ColleagueSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderTovarSet'
ALTER TABLE [dbo].[OrderTovarSet]
ADD CONSTRAINT [PK_OrderTovarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TovarSet'
ALTER TABLE [dbo].[TovarSet]
ADD CONSTRAINT [PK_TovarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Colleague_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_ColleagueUser]
    FOREIGN KEY ([Colleague_Id])
    REFERENCES [dbo].[ColleagueSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColleagueUser'
CREATE INDEX [IX_FK_ColleagueUser]
ON [dbo].[Users]
    ([Colleague_Id]);
GO

-- Creating foreign key on [Client_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_ClientUser]
    FOREIGN KEY ([Client_Id])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientUser'
CREATE INDEX [IX_FK_ClientUser]
ON [dbo].[Users]
    ([Client_Id]);
GO

-- Creating foreign key on [Client_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_OrderClient]
    FOREIGN KEY ([Client_Id])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderClient'
CREATE INDEX [IX_FK_OrderClient]
ON [dbo].[OrderSet]
    ([Client_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'OrderTovarSet'
ALTER TABLE [dbo].[OrderTovarSet]
ADD CONSTRAINT [FK_OrderOrderTovar]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[OrderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderTovar'
CREATE INDEX [IX_FK_OrderOrderTovar]
ON [dbo].[OrderTovarSet]
    ([Order_Id]);
GO

-- Creating foreign key on [Tovar_Id] in table 'OrderTovarSet'
ALTER TABLE [dbo].[OrderTovarSet]
ADD CONSTRAINT [FK_TovarOrderTovar]
    FOREIGN KEY ([Tovar_Id])
    REFERENCES [dbo].[TovarSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TovarOrderTovar'
CREATE INDEX [IX_FK_TovarOrderTovar]
ON [dbo].[OrderTovarSet]
    ([Tovar_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------