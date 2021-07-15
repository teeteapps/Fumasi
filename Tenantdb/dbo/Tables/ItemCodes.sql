CREATE TABLE [dbo].[ItemCodes] (
    [Id]       BIGINT       IDENTITY (1, 1) NOT NULL,
    [ItemCode] VARCHAR (5)  NOT NULL,
    [Descr]    VARCHAR (20) NOT NULL,
    CONSTRAINT [pk_ItemCodes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [uk_ItemCodes_ItemCode] UNIQUE NONCLUSTERED ([ItemCode] ASC)
);

