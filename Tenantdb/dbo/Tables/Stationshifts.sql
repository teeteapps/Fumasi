CREATE TABLE [dbo].[Stationshifts] (
    [Idxno]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [Shiftcode]      BIGINT        NOT NULL,
    [Stationcode]    BIGINT        NOT NULL,
    [Shiftname]      VARCHAR (10)  NOT NULL,
    [Shiftstarttime] TIME (7)      DEFAULT ('00:00') NOT NULL,
    [Shiftendtime]   TIME (7)      DEFAULT ('11:59') NOT NULL,
    [Datecreated]    DATETIME      DEFAULT (getdate()) NOT NULL,
    [Datemodified]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [Systemdate]     DATETIME      DEFAULT (getdate()) NOT NULL,
    [Createdby]      VARCHAR (100) NOT NULL,
    [Modifiedby]     VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Idxno] ASC),
    UNIQUE NONCLUSTERED ([Shiftcode] ASC)
);

