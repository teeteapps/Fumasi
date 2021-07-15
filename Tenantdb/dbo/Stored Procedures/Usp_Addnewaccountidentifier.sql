CREATE PROCEDURE [dbo].[Usp_Addnewaccountidentifier]
	@Accountcode BIGINT,
	@Identifiertype BIGINT,
	@Identifiersno VARCHAR(50),
	@Identifieruid VARCHAR(50),
	@Datecreated DateTime,
	@Datemodified DateTime,
	@Createdby  VARCHAR(100),
	@Modifiedby  VARCHAR(100)

AS
BEGIN
   BEGIN
	DECLARE 
			@Identifiercode BIGINT=0,
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate
		  IF EXISTS(SELECT Identifiersno FROM Identifiers Where Identifiersno=@Identifiersno)
			BEGIN
				Select 1 as RespStatus, 'Identifier Already Exists!' as RespMessage;
			return;
			END
			IF EXISTS(SELECT Identifieruid FROM Identifiers Where Identifieruid=@Identifieruid)
			BEGIN
				Select 1 as RespStatus, 'Identifier Already in Use!!' as RespMessage;
			return;
			END
			

		Declare @RunNoTable TABLE (RunNo Varchar(20))
		INSERT INTO @RunNoTable Exec Usp_GenerateRunNo 'ADI'  
		Select @Identifiercode = RunNo From @RunNoTable

		
		BEGIN TRANSACTION;
		INSERT INTO Identifiers(Identifiercode,identifiertype,Identifiersno,Identifieruid,Isassigned,Datecreated,Datemodified,Createdby,Modifiedby) 
		VALUES(@Identifiercode,@Identifiertype,@Identifiersno,@Identifieruid,1,@Datecreated,@Datemodified,@Createdby,@Modifiedby)

		INSERT INTO Lnkaccountandidentifiers(Identifiercode,Accountcode,Isparent,Datecreated,Datemodified,Createdby,Modifiedby)
		VALUES(@Identifiercode,@Accountcode,0,@Datecreated,@Datemodified,@Createdby,@Modifiedby)

		Set @RespMsg ='Identifier Added Successfully.'
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
