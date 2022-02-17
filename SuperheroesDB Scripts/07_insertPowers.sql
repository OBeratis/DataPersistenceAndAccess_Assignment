/*******************************************************************************
   SuperheroesDb - Version 1.0
   Script: 07_insertPowers.sql
   Description: Populate Table Power in the SuperheroesDb database.
   DB Server: SqlServer
   Author: Odysseus Beratis
********************************************************************************/

/*******************************************************************************
   Use SuperheroesDb
********************************************************************************/
USE [SuperheroesDb];
GO

INSERT INTO [dbo].[Power] ([Name]) VALUES (N'Speed');
INSERT INTO [dbo].[Power] ([Name]) VALUES (N'Telekinesis');
INSERT INTO [dbo].[Power] ([Name]) VALUES (N'Strength');
INSERT INTO [dbo].[Power] ([Name]) VALUES (N'Flight');