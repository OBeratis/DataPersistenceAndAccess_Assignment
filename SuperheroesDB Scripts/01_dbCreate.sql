/*******************************************************************************
   SuperheroesDb - Version 1.0
   Script: 01_dbCreate.sql
   Description: Creates and populates the SuperheroesDb database.
   DB Server: SqlServer
   Author: Odysseus Beratis
********************************************************************************/

/*******************************************************************************
   Drop database if it exists
********************************************************************************/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'SuperheroesDb')
BEGIN
	ALTER DATABASE [SuperheroesDb] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [SuperheroesDb] SET ONLINE;
	DROP DATABASE [SuperheroesDb];
END

GO

/*******************************************************************************
   Create database
********************************************************************************/
CREATE DATABASE [SuperheroesDb];
GO

USE [SuperheroesDb];
GO
