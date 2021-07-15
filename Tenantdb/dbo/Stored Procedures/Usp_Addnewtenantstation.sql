CREATE PROCEDURE [dbo].[Usp_Addnewtenantstation]
	@Tenantcode BIGINT,
	@Stationname VARCHAR(100),
	@Stationref VARCHAR(100),
	@Stationaddress VARCHAR(100),
	@Lng Decimal(18,2),
	@Lat Decimal(18,2),
	@Datecreated DateTime,
	@Datemodified DateTime,
	@Createdby  VARCHAR(100),
	@Modifiedby  VARCHAR(100)
AS
BEGIN
   BEGIN
	DECLARE 
			@Stationshiftcount INT = 1,
			@Stationcode BIGINT=0,
			@Shiftcode BIGINT=0,
			@Shiftname VARCHAR(10)='0-0',
			@Shiftstarttime Time='00:00',
			@Shiftendtime Time='11:59',
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate
		  IF EXISTS(SELECT Stationname FROM Stations Where Stationname=@Stationname)
			BEGIN
				Select 1 as RespStatus, 'Station Name Already Exists!' as RespMessage;
			return;
			END

		Declare @RunNoTable TABLE (RunNo Varchar(20))
		INSERT INTO @RunNoTable Exec Usp_GenerateRunNo 'SDD'  
		Select @Stationcode = RunNo From @RunNoTable
		
		BEGIN TRANSACTION;
		INSERT INTO Stations(Stationcode,Tenantcode,Stationname,Stationreference,Stationaddress,Lng,Lat,Datecreated,Datemodified,Createdby,Modifiedby) 
		VALUES(@Stationcode,@Tenantcode,@Stationname,@Stationref,@Stationaddress,@Lng,@Lat,@Datecreated,@Datemodified,@Createdby,@Modifiedby)
		WHILE @Stationshiftcount <= 2
		BEGIN
		INSERT INTO @RunNoTable Exec Usp_GenerateRunNo 'SHD'  
		Select @Shiftcode = RunNo From @RunNoTable
			BEGIN
				INSERT INTO Stationshifts(Shiftcode,Stationcode,Shiftname,Shiftstarttime,Shiftendtime,Datecreated,Datemodified,Createdby,Modifiedby)
				VALUES(@Shiftcode,@Stationcode,@Shiftname,@Shiftstarttime,@Shiftendtime,@Datecreated,@Datemodified,@Createdby,@Modifiedby)
			END
			--INSERT INTO Stationshifts(Shiftcode,Stationcode,Shiftname,Shiftstarttime,Shiftendtime,Datecreated,Datemodified,Createdby,Modifiedby)
			--VALUES(@Shiftcode,@Stationcode,'0-1','12:00','11:59',@Datecreated,@Datemodified,@Createdby,@Modifiedby)

			SET @Shiftname = '0-1';
			SET @Shiftstarttime='12:00';
			SET @Shiftendtime='11:59'
			SET @Stationshiftcount = @Stationshiftcount + 1;
		END;
		Set @RespMsg ='Data Saved Successfully.'
		Set @RespStat =0; 
		COMMIT TRANSACTION;
		Select @RespStat as RespStatus, @RespMsg as RespMessage,@Stationcode AS Data1;

		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION
		PRINT ''
		PRINT 'Error ' + error_message();
		Select 2 as RespStatus, '0 - Error(s) Occurred' + error_message() as RespMessage
		END CATCH
		Select @RespStat as RespStatus, @RespMsg as RespMessage;
		RETURN; 
		END;
	END
END
