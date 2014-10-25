CREATE TABLE [dbo].[ClothingArticle] (
    [Tag]          NVARCHAR (50)   NOT NULL,
    [Name]         NVARCHAR (200)  NULL,
    [PurchaseDate] DATE            NULL,
    [Picture]      VARBINARY (MAX) NULL,
    [IdState]      INT             NOT NULL,
    CONSTRAINT [PK_ClothingArticle] PRIMARY KEY CLUSTERED ([Tag] ASC),
    CONSTRAINT [FK_ClothingArticle_ClothingArticleState] FOREIGN KEY ([IdState]) REFERENCES [dbo].[ClothingArticleState] ([Id]) ON UPDATE CASCADE
);

