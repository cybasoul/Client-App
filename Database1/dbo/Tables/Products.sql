CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductName] NVARCHAR (MAX) NOT NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [QTY]         INT            NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

