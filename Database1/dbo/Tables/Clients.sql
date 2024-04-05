CREATE TABLE [dbo].[Clients] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (MAX) NOT NULL,
    [LastName]        NVARCHAR (MAX) NOT NULL,
    [MobileNumber]    NVARCHAR (MAX) NOT NULL,
    [IDNumber]        NVARCHAR (MAX) NOT NULL,
    [PhysicalAddress] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC)
);

