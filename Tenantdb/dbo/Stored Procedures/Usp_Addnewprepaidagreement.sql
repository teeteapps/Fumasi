CREATE PROCEDURE [dbo].[Usp_Addnewprepaidagreement]
	@Customercode BIGINT,
	@Agreementdesc VARCHAR(100),
	@Agreementtype BIGINT,
	@Agreementdoc VARCHAR(100),
	@Notes VARCHAR(500),
	@Datecreated DateTime,
	@Datemodified DateTime,
	@Createdby  VARCHAR(100),
	@Modifiedby  VARCHAR(100)

AS
BEGIN
   BEGIN
	DECLARE 
			@Agreementcode BIGINT=0,
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate

		Declare @RunNoTable TABLE (RunNo Varchar(20))
		INSERT INTO @RunNoTable Exec Usp_GenerateRunNo 'TPA'  
		Select @Agreementcode = RunNo From @RunNoTable
		
		BEGIN TRANSACTION;
		INSERT INTO Customerprepaidagreement(Agreementcode,Customercode,Agreementdesc,Agreementtype,Agreementdoc,Notes,Datecreated,Datemodified,Createdby,Modifiedby) 
		VALUES(@Agreementcode,@Customercode,@Agreementdesc,@Agreementtype,@Agreementdoc,@Notes,@Datecreated,@Datemodified,@Createdby,@Modifiedby)

		Set @RespMsg ='Data Saved Successfully.'
		Set @RespStat =0; 
		COMMIT TRANSACTION;
		Select @RespStat as RespStatus, @RespMsg as RespMessage,@Agreementcode AS Data1;

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
