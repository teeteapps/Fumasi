CREATE TABLE [dbo].[Agreementaccountemployee] (
    [Idxno]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [Employeecode] BIGINT        NOT NULL,
    [Accountcode]  BIGINT        NOT NULL,
    [Firstname]    VARCHAR (100) NOT NULL,
    [Lastname]     VARCHAR (100) NOT NULL,
    [Phonenumber]  VARCHAR (15)  NOT NULL,
    [Emailaddress] VARCHAR (100) NOT NULL,
    [Drivercode]   VARCHAR (100) NOT NULL,
    [Isactive]     BIT           DEFAULT ((1)) NOT NULL,
    [Isdelete]     BIT           DEFAULT ((0)) NOT NULL,
    [Datecreated]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datemodified] DATETIME      DEFAULT (getdate()) NOT NULL,
    [Systemdate]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [Createdby]    VARCHAR (100) NOT NULL,
    [Modifiedby]   VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Employeecode] ASC)
);

