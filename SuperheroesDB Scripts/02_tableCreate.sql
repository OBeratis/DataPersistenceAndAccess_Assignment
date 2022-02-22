/*******************************************************************************
   SuperheroesDb - Version 1.0
   Script: 02_tableCreate.sql
   Description: Creates main tables in the SuperheroesDb database.
   DB Server: SqlServer
   Author: Odysseus Beratis
********************************************************************************/

/*******************************************************************************
   Use SuperheroesDb
********************************************************************************/
USE [SuperheroesDb];
GO

/*******************************************************************************
   Create Tables
********************************************************************************/

CREATE TABLE [dbo].[Superhero]
(
    [SuperheroId] INT NOT NULL IDENTITY,
	[AssistantId] INT NULL,
	[PowerId] INT NULL,
    [Name] NVARCHAR(50),
    [Alias] NVARCHAR(20),
	[Origin] NVARCHAR (30)
    CONSTRAINT [PK_Superhero] PRIMARY KEY CLUSTERED ([SuperheroId])
);
GO

CREATE TABLE [dbo].[Assistant]
(
    [AssistantId] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(50)
    CONSTRAINT [PK_Assistant] PRIMARY KEY CLUSTERED ([AssistantId])
);
GO

CREATE TABLE [dbo].[Power]
(
    [PowerId] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(50),
	[Description] NVARCHAR(100)
    CONSTRAINT [PK_Power] PRIMARY KEY CLUSTERED ([PowerId])
);
GO



