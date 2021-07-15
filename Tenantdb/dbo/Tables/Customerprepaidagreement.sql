CREATE TABLE [dbo].[Customerprepaidagreement] (
    [Idxno]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Agreementcode] BIGINT        NOT NULL,
    [Customercode]  BIGINT        NOT NULL,
    [Agreementtype] BIGINT        NOT NULL,
    [Agreementdesc] VARCHAR (100) NOT NULL,
    [Agreementdoc]  VARCHAR (100) NULL,
    [Notes]         VARCHAR (100) NOT NULL,
    [Datecreated]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datemodified]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [Systemdate]    DATETIME      DEFAULT (getdate()) NOT NULL,
    [Createdby]     VARCHAR (100) NOT NULL,
    [Modifiedby]    VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Agreementcode] ASC)
);

