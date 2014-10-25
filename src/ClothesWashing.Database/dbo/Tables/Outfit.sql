CREATE TABLE [dbo].[Outfit] (
    [Id]       INT      IDENTITY (1, 1) NOT NULL,
    [WearDate] DATETIME CONSTRAINT [DF_Outfit_WearDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Outfit] PRIMARY KEY CLUSTERED ([Id] ASC)
);

