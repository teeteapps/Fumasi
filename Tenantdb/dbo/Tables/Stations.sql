CREATE TABLE [dbo].[Stations] (
    [Idxno]            BIGINT          IDENTITY (1, 1) NOT NULL,
    [Stationcode]      BIGINT          NOT NULL,
    [Tenantcode]       BIGINT          NOT NULL,
    [Stationname]      VARCHAR (100)   NOT NULL,
    [Stationaddress]   VARCHAR (100)   NULL,
    [Stationlocation]  VARCHAR (200)   NULL,
    [Stationreference] VARCHAR (100)   NULL,
    [Lng]              DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Lat]              DECIMAL (18, 2) DEFAULT ((0)) NULL,
    [Datecreated]      DATETIME        DEFAULT (getdate()) NOT NULL,
    [Datemodified]     DATETIME        DEFAULT (getdate()) NOT NULL,
    [Systemdate]       DATETIME        DEFAULT (getdate()) NOT NULL,
    [Createdby]        VARCHAR (100)   NOT NULL,
    [Modifiedby]       VARCHAR (100)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Stationcode] ASC)
);

