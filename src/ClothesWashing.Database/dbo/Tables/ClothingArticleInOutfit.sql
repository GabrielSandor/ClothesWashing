CREATE TABLE [dbo].[ClothingArticleInOutfit] (
    [ClothingArticleTag] NVARCHAR (50) NOT NULL,
    [IdOutfit]           INT           NOT NULL,
    CONSTRAINT [PK_ClothingArticleInOutfit] PRIMARY KEY CLUSTERED ([ClothingArticleTag] ASC, [IdOutfit] ASC),
    CONSTRAINT [FK_ClothingArticleInOutfit_ClothingArticle] FOREIGN KEY ([ClothingArticleTag]) REFERENCES [dbo].[ClothingArticle] ([Tag]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_ClothingArticleInOutfit_Outfit] FOREIGN KEY ([IdOutfit]) REFERENCES [dbo].[Outfit] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

