CREATE TABLE [dbo].[Phoneprefix] (
    [Idxno]       BIGINT       IDENTITY (1, 1) NOT NULL,
    [Prefixcode]  VARCHAR (10) NOT NULL,
    [Prefixname]  VARCHAR (10) NOT NULL,
    [Datecreated] DATETIME     DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Prefixcode] ASC),
    UNIQUE NONCLUSTERED ([Prefixname] ASC)
);

