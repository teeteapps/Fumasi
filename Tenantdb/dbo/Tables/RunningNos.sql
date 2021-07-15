CREATE TABLE [dbo].[RunningNos] (
    [Id]        BIGINT      IDENTITY (1, 1) NOT NULL,
    [RunningNo] BIGINT      NOT NULL,
    [ItemCode]  VARCHAR (5) NOT NULL,
    CONSTRAINT [pk_RunningNos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_RunningNos_ItemCode] FOREIGN KEY ([ItemCode]) REFERENCES [dbo].[ItemCodes] ([ItemCode]),
    CONSTRAINT [uk_RunningNos_ItemCode] UNIQUE NONCLUSTERED ([ItemCode] ASC)
);

