/*******************************************************************************
   SuperheroesDb - Version 1.0
   Script: 04_relationshipSuperheroPower.sql
   Description: Create relationships in the SuperheroesDb database.
   DB Server: SqlServer
   Author: Odysseus Beratis
********************************************************************************/

/*******************************************************************************
   Use SuperheroesDb
********************************************************************************/
USE [SuperheroesDb];
GO

DROP TABLE IF EXISTS [dbo].[Attributes];

CREATE TABLE [dbo].[Attributes]
(
	[AttributeId] INT IDENTITY(1,1) NOT NULL,
	[SuperheroId] INT FOREIGN KEY REFERENCES [dbo].[Superhero](SuperheroId),
	[PowerId] INT FOREIGN KEY REFERENCES [dbo].[Power](PowerId),
	CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED ([AttributeId])
);
GO	

INSERT INTO [dbo].[Attributes] ([SuperheroId],[PowerId]) VALUES (1,1)
GO
INSERT INTO [dbo].[Attributes] ([SuperheroId],[PowerId]) VALUES (1,4)
GO

SELECT Superhero.Name AS 'Superhero name', Power.Name AS 'Power name' FROM Attributes
	INNER JOIN Superhero ON Superhero.SuperheroId = Attributes.SuperheroId
	INNER JOIN Power ON Power.PowerId = Attributes.PowerId




