CREATE TABLE [dbo].[Fumasitenants] (
    [Idxno]             BIGINT        IDENTITY (1, 1) NOT NULL,
    [Tenantcode]        BIGINT        DEFAULT ((99)) NOT NULL,
    [Tenantname]        VARCHAR (100) DEFAULT ('Defautl Tenant') NOT NULL,
    [Tenantkey]         VARCHAR (100) DEFAULT ('0000-0000-0000-0000') NOT NULL,
    [Tenantstatus]      INT           DEFAULT ((0)) NOT NULL,
    [Tenantconnid]      VARCHAR (50)  NOT NULL,
    [Tenantconnkey]     VARCHAR (100) NOT NULL,
    [Tenantconndata]    VARCHAR (MAX) NOT NULL,
    [Tenantdatecreated] DATETIME      DEFAULT (getdate()) NOT NULL,
    [Tenantgolivedate]  DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Tenantcode] ASC),
    UNIQUE NONCLUSTERED ([Tenantkey] ASC),
    UNIQUE NONCLUSTERED ([Tenantname] ASC)
);

