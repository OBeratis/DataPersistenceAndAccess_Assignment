/*******************************************************************************
   SuperheroesDb - Version 1.0
   Script: 05_insertSuperheroes.sql
   Description: Insert on table Superhero in the SuperheroesDb database.
   DB Server: SqlServer
   Author: Odysseus Beratis
********************************************************************************/

/*******************************************************************************
   Use SuperheroesDb
********************************************************************************/
USE [SuperheroesDb];
GO

INSERT INTO [dbo].[Superhero] ([Name]) VALUES (N'Superman');
INSERT INTO [dbo].[Superhero] ([Name]) VALUES (N'Thor');
INSERT INTO [dbo].[Superhero] ([Name]) VALUES (N'WonderWoman');
