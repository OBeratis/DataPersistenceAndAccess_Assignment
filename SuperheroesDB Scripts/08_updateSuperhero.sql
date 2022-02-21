/*******************************************************************************
   SuperheroesDb - Version 1.0
   Script: 08_updateSuperhero.sql
   Description: Update Table Superhero in the SuperheroesDb database.
   DB Server: SqlServer
   Author: Odysseus Beratis
********************************************************************************/

/*******************************************************************************
   Use SuperheroesDb
********************************************************************************/
USE [SuperheroesDb];
GO

UPDATE [dbo].[Superhero] SET Name='ThorX' WHERE Name='Thor';