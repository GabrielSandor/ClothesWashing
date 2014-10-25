CREATE TABLE [dbo].[ClothingArticleInWashingSession] (
    [ClothingArticleTag] NVARCHAR (50) NOT NULL,
    [IdWashingSession]   INT           NOT NULL,
    CONSTRAINT [PK_ClothingArticleInWashingSession] PRIMARY KEY CLUSTERED ([ClothingArticleTag] ASC, [IdWashingSession] ASC),
    CONSTRAINT [FK_ClothingArticleInWashingSession_ClothingArticle] FOREIGN KEY ([ClothingArticleTag]) REFERENCES [dbo].[ClothingArticle] ([Tag]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_ClothingArticleInWashingSession_WashingSession] FOREIGN KEY ([IdWashingSession]) REFERENCES [dbo].[WashingSession] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

