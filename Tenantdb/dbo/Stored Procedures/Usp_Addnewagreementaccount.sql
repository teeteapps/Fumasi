CREATE PROCEDURE [dbo].[Usp_Addnewagreementaccount]
	@Agreementcode BIGINT,
	@Identifiercode BIGINT,
	@Hasdrivercode BIT,
	@Datecreated DateTime,
	@Datemodified DateTime,
	@Createdby  VARCHAR(100),
	@Modifiedby  VARCHAR(100)

AS
BEGIN
   BEGIN
	DECLARE 
			@Accountcode BIGINT=0,
			@Accountnumber BIGINT=0,
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate
		  IF EXISTS(SELECT Accountnumber FROM Customeragreementaccount Where Accountnumber=@Accountnumber)
			BEGIN
				Select 1 as RespStatus, 'Account Number Already Exists!' as RespMessage;
			return;
			END
			 IF EXISTS(SELECT Identifiercode FROM Lnkaccountandidentifiers Where Identifiercode=@Identifiercode)
			BEGIN
				Select 1 as RespStatus, 'Identifier Already in Use!' as RespMessage;
			return;
			END

		Declare @RunNoTable TABLE (RunNo Varchar(20))
		INSERT INTO @RunNoTable Exec Usp_GenerateRunNo 'AAD'  
		Select @Accountcode = RunNo From @RunNoTable
		
		BEGIN TRANSACTION;
		INSERT INTO Customeragreementaccount(Accountcode,Accountnumber,Agreementcode,Hasdrivercode,Datecreated,Datemodified,Createdby,Modifiedby) 
		VALUES(@Accountcode,@Accountcode,@Agreementcode,@Hasdrivercode,@Datecreated,@Datemodified,@Createdby,@Modifiedby)

		INSERT INTO Lnkaccountandidentifiers(Identifiercode,Accountcode,Isparent,Datecreated,Datemodified,Createdby,Modifiedby)
		VALUES(@Identifiercode,@Accountcode,0,@Datecreated,@Datemodified,@Createdby,@Modifiedby)

		update Identifiers SET Isassigned=1 WHERE Identifiercode=@Identifiercode

		Set @RespMsg ='Account Created Successfully.'
		Set @RespStat =0; 
		COMMIT TRANSACTION;
		Select @RespStat as RespStatus, @RespMsg as RespMessage;

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
