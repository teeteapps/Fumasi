CREATE TABLE [dbo].[Customeragreementaccount] (
    [Idxno]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Accountcode]   BIGINT        NOT NULL,
    [Accountnumber] BIGINT        NOT NULL,
    [Agreementcode] BIGINT        NOT NULL,
    [Hasdrivercode] BIT           DEFAULT ((0)) NOT NULL,
    [Isactive]      BIT           DEFAULT ((1)) NOT NULL,
    [Isdelete]      BIT           DEFAULT ((0)) NOT NULL,
    [Datecreated]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datemodified]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [Systemdate]    DATETIME      DEFAULT (getdate()) NOT NULL,
    [Createdby]     VARCHAR (100) NOT NULL,
    [Modifiedby]    VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Accountcode] ASC),
    UNIQUE NONCLUSTERED ([Accountnumber] ASC)
);

