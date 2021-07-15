CREATE TABLE [dbo].[Staffroles] (
    [Idxno]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [Rolecode]        BIGINT        NOT NULL,
    [Rolename]        VARCHAR (100) NOT NULL,
    [Roledescription] VARCHAR (100) NOT NULL,
    [Datecreated]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datemodified]    DATETIME      DEFAULT (getdate()) NOT NULL,
    [Systemdate]      DATETIME      DEFAULT (getdate()) NOT NULL,
    [Createdby]       VARCHAR (100) NOT NULL,
    [Modifiedby]      VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Rolecode] ASC)
);

