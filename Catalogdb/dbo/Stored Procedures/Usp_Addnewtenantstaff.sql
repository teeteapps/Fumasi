CREATE PROCEDURE [dbo].[Usp_Addnewtenantstaff]
	@Tenantcode BIGINT,
	@Firstname VARCHAR(100),
	@Lastname VARCHAR(100),
	@Emailaddress VARCHAR(100),
	@Phonenumber VARCHAR(15),
	@Staffpass VARCHAR(100),
	@Staffpin VARCHAR(100),
	@Topuplimittype VARCHAR(50),
	@Topuplimitvalue Decimal(18,2),
	@Stationcode BIGINT,
	@Rolecode BIGINT,
	@Datecreated DateTime,
	@Datemodified DateTime,
	@Createdby  VARCHAR(100),
	@Modifiedby  VARCHAR(100)

AS
BEGIN
   BEGIN
	DECLARE 
			@Staffcode BIGINT=0,
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate
		  IF EXISTS(SELECT Emailaddress FROM Tenantstaffs Where Emailaddress=@Emailaddress)
			BEGIN
				Select 1 as RespStatus, 'Email Already Exists!' as RespMessage;
			return;
			END
			 IF EXISTS(SELECT Phonenumber FROM Tenantstaffs Where Phonenumber=@Phonenumber)
			BEGIN
				Select 1 as RespStatus, 'Phone Number Already Exists!' as RespMessage;
			return;
			END

		Declare @RunNoTable TABLE (RunNo Varchar(20))
		INSERT INTO @RunNoTable Exec Usp_GenerateRunNo 'TSF'  
		Select @Staffcode = RunNo From @RunNoTable
		
		BEGIN TRANSACTION;
		INSERT INTO Tenantstaffs(Staffcode,Tenantcode,Firstname,Lastname,Emailaddress,Phonenumber,Staffpass,Staffpin,Topuplimittype,Topuplimitvalue,Stationcode,Rolecode,Datecreated,Datemodified,Createdby,Modifiedby) 
		VALUES(@Staffcode,@Tenantcode,@Firstname,@Lastname,@Emailaddress,@Phonenumber,@Staffpass,@Staffpin,@Topuplimittype,@Topuplimitvalue,@Stationcode,@Rolecode,@Datecreated,@Datemodified,@Createdby,@Modifiedby)

		Set @RespMsg ='Data Saved Successfully.'
		Set @RespStat =0; 
		COMMIT TRANSACTION;
		Select @RespStat as RespStatus, @RespMsg as RespMessage,@Emailaddress AS Data1,@Firstname+' '+@Lastname as Data2,@Staffpass as Data3, @Staffpin as Data5;

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
