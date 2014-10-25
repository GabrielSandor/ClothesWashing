CREATE TABLE [dbo].[WashingSession] (
    [Id]       INT      IDENTITY (1, 1) NOT NULL,
    [WashDate] DATETIME CONSTRAINT [DF_WashingSession_WashDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_WashingSession] PRIMARY KEY CLUSTERED ([Id] ASC)
);

