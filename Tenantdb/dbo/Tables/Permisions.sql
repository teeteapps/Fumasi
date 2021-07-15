CREATE TABLE [dbo].[Permisions] (
    [Idxno]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Permisioncode] BIGINT        NOT NULL,
    [Permisionname] VARCHAR (100) NOT NULL,
    [Permisiondesc] VARCHAR (100) NOT NULL,
    [Systemdate]    DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Permisioncode] ASC)
);

