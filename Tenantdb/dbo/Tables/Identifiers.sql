CREATE TABLE [dbo].[Identifiers] (
    [Idxno]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [Identifiercode] BIGINT        NOT NULL,
    [Identifiersno]  VARCHAR (100) NOT NULL,
    [Identifieruid]  VARCHAR (100) NOT NULL,
    [Identifiertype] INT           NOT NULL,
    [Isassigned]     BIT           DEFAULT ((0)) NOT NULL,
    [Isactive]       BIT           DEFAULT ((1)) NOT NULL,
    [Isdelete]       BIT           DEFAULT ((0)) NOT NULL,
    [Datecreated]    DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datemodified]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [Systemdate]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [Createdby]      VARCHAR (100) NOT NULL,
    [Modifiedby]     VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Identifiercode] ASC)
);

