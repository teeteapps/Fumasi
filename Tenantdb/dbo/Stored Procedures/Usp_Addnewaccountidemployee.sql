CREATE PROCEDURE [dbo].[Usp_Addnewaccountidemployee]
	@Accountcode BIGINT,
	@Firstname VARCHAR(100),
	@Lastname VARCHAR(100),
	@Phonenumber VARCHAR(15),
	@Emailaddress VARCHAR(100),
	@Drivercode VARCHAR(100),
	@Datecreated DateTime,
	@Datemodified DateTime,
	@Createdby  VARCHAR(100),
	@Modifiedby  VARCHAR(100)

AS
BEGIN
   BEGIN
	DECLARE 
			@Employeecode BIGINT=0,
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate
		  IF EXISTS(SELECT Emailaddress FROM Agreementaccountemployee Where Emailaddress=@Emailaddress)
			BEGIN
				Select 1 as RespStatus, 'Email Address Already Exists!' as RespMessage;
			return;
			END
			IF EXISTS(SELECT Phonenumber FROM Agreementaccountemployee Where Phonenumber=@Phonenumber)
			BEGIN
				Select 1 as RespStatus, 'Phone Number Already Exists!' as RespMessage;
			return;
			END
			 

		Declare @RunNoTable TABLE (RunNo Varchar(20))
		INSERT INTO @RunNoTable Exec Usp_GenerateRunNo 'AAE'  
		Select @Employeecode = RunNo From @RunNoTable
		
		BEGIN TRANSACTION;
		INSERT INTO Agreementaccountemployee(Employeecode,Accountcode,Firstname,Lastname,Phonenumber,Emailaddress,Drivercode,Datecreated,Datemodified,Createdby,Modifiedby) 
		VALUES(@Employeecode,@Accountcode,@Firstname,@Lastname,@Phonenumber,@Emailaddress,@Drivercode,@Datecreated,@Datemodified,@Createdby,@Modifiedby)

		Set @RespMsg ='Employee Added Successfully.'
		Set @RespStat =0; 
		COMMIT TRANSACTION;
		Select @RespStat as RespStatus, @RespMsg as RespMessage,@Drivercode as Data1,@Firstname+' '+@Lastname as Data2,@Emailaddress as Data3;

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
