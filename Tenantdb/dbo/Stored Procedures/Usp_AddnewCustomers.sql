CREATE PROCEDURE [dbo].[Usp_AddnewCustomers]
	@Tenantcode BIGINT,
	@Firstname VARCHAR(100),
	@Lastname VARCHAR(100),
	@Emailaddress VARCHAR(100),
	@Phonenumber VARCHAR(15),
	@Customerpass VARCHAR(100),
	@Customertype INT,
	@Phoneprefix VARCHAR(10),
	@Stationcode BIGINT,
	@Canaccessprtal BIT,
	@Datecreated DateTime,
	@Datemodified DateTime,
	@Createdby  BIGINT,
	@Modifiedby  BIGINT

AS
BEGIN
   BEGIN
	DECLARE 
			@Customercode BIGINT=0,
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate
		  IF EXISTS(SELECT Emailaddress FROM Customers Where Emailaddress=@Emailaddress)
			BEGIN
				Select 1 as RespStatus, 'Email Already Exists!' as RespMessage;
			return;
			END
			 IF EXISTS(SELECT Phonenumber FROM Customers Where Phonenumber=@Phonenumber)
			BEGIN
				Select 1 as RespStatus, 'Phone Number Already Exists!' as RespMessage;
			return;
			END

		Declare @RunNoTable TABLE (RunNo Varchar(20))
		INSERT INTO @RunNoTable Exec Usp_GenerateRunNo 'TCD'  
		Select @Customercode = RunNo From @RunNoTable
		
		BEGIN TRANSACTION;
		INSERT INTO Customers(Customercode,Tenantcode,Firstname,Lastname,Emailaddress,Phonenumber,Customerpass,Customertype,Phoneprefix,Station,Canaccessprtal,Datecreated,Datemodified,Createdby,Modifiedby) 
		VALUES(@Customercode,@Tenantcode,@Firstname,@Lastname,@Emailaddress,@Phonenumber,@Customerpass,@Customertype,@Phoneprefix,@Stationcode,@Canaccessprtal,@Datecreated,@Datemodified,@Createdby,@Modifiedby)

		Set @RespMsg ='Data Saved Successfully.'
		Set @RespStat =0; 
		COMMIT TRANSACTION;
		Select @RespStat as RespStatus, @RespMsg as RespMessage,@Emailaddress AS Data1,@Firstname+' '+@Lastname as Data2,@Customerpass as Data3,@Canaccessprtal as Data6,@Customercode as Data7;

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
