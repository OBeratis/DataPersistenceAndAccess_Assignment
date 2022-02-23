/*******************************************************************************
   SuperheroesDb - Version 1.0
   Script: 03_relationshipSuperheroAssistant.sql
   Description: Create relationships in the SuperheroesDb database.
   DB Server: SqlServer
   Author: Odysseus Beratis
********************************************************************************/

/*******************************************************************************
   Use SuperheroesDb
********************************************************************************/
USE [SuperheroesDb];
GO

ALTER TABLE [dbo].[Superhero] ADD CONSTRAINT [FK_AssistantId]
    FOREIGN KEY ([AssistantId]) REFERENCES [dbo].[Assistant] ([AssistantId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
CREATE INDEX [IFK_AssistantId] ON [dbo].[Superhero] ([AssistantId]);
GO
