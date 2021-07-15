CREATE TABLE [dbo].[Identifiertype] (
    [Idxno]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [Typecode]   BIGINT        NOT NULL,
    [Typename]   VARCHAR (100) NOT NULL,
    [Systemdate] DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Typecode] ASC)
);

