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

--ALTER TABLE [dbo].[Superhero] ADD CONSTRAINT [FK_PowerId]
--    FOREIGN KEY ([PowerId]) REFERENCES [dbo].[Power] ([PowerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
--GO
--CREATE INDEX [IFK_PowerId] ON [dbo].[Superhero] ([PowerId]);
--GO

CREATE TABLE [dbo].[Attributes]
(
    [AttributeId] INT IDENTITY(1,1) NOT NULL,
	[SuperheroId] INT FOREIGN KEY REFERENCES [dbo].[Superhero](SuperheroId),
	[PowerId] INT FOREIGN KEY REFERENCES [dbo].[Power](PowerId),
    CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED ([AttributeId])
);
GO

