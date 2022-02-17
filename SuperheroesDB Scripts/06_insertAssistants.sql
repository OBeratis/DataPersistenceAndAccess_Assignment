/*******************************************************************************
   SuperheroesDb - Version 1.0
   Script: 06_insertAssistants.sql
   Description: Insert on table Assistant in the SuperheroesDb database.
   DB Server: SqlServer
   Author: Odysseus Beratis
********************************************************************************/

/*******************************************************************************
   Use SuperheroesDb
********************************************************************************/
USE [SuperheroesDb];
GO

INSERT INTO [dbo].[Assistant] ([Name]) VALUES (N'Hulk');
INSERT INTO [dbo].[Assistant] ([Name]) VALUES (N'Atom');
INSERT INTO [dbo].[Assistant] ([Name]) VALUES (N'Photon');