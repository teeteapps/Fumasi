CREATE TABLE [dbo].[Customers] (
    [Idxno]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [Customercode]   BIGINT        NOT NULL,
    [Tenantcode]     BIGINT        NOT NULL,
    [Firstname]      VARCHAR (100) NOT NULL,
    [Lastname]       VARCHAR (100) NOT NULL,
    [Phoneprefix]    VARCHAR (10)  NOT NULL,
    [Phonenumber]    VARCHAR (15)  NULL,
    [Emailaddress]   VARCHAR (100) NULL,
    [Customerpass]   VARCHAR (100) NULL,
    [Station]        BIGINT        NOT NULL,
    [Canaccessprtal] BIT           DEFAULT ((0)) NOT NULL,
    [Customertype]   INT           NOT NULL,
    [Isactive]       BIT           DEFAULT ((1)) NOT NULL,
    [Isdeleted]      BIT           DEFAULT ((0)) NOT NULL,
    [Datecreated]    DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datemodified]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [Systemdate]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [Createdby]      BIGINT        NOT NULL,
    [Modifiedby]     BIGINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Customercode] ASC)
);

