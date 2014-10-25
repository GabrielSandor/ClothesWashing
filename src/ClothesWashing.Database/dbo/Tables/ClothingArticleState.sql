CREATE TABLE [dbo].[ClothingArticleState] (
    [Id]                 INT      IDENTITY (1, 1) NOT NULL,
    [IsDirty]            BIT      CONSTRAINT [DF_ClothingArticleState_IsDirty] DEFAULT ((0)) NOT NULL,
    [LastWashDate]       DATETIME NULL,
    [LastWearDate]       DATETIME NULL,
    [WearsSinceLastWash] SMALLINT CONSTRAINT [DF_ClothingArticleState_WearsSinceLastWash] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ClothingArticleState] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_ClothingArticleState] CHECK ([WearsSinceLastWash]>=(0))
);

