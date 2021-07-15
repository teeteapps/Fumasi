CREATE PROCEDURE [dbo].[Usp_EditnewCustomers]
	@Customercode BIGINT,
	@Firstname VARCHAR(100),
	@Lastname VARCHAR(100),
	@Emailaddress VARCHAR(100),
	@Phonenumber VARCHAR(15),
	@Customertype INT,
	@Phoneprefix VARCHAR(10),
	@Stationcode BIGINT,
	@Canaccessprtal BIT,
	@Datemodified DateTime,
	@Modifiedby  BIGINT
AS
BEGIN
   BEGIN
	DECLARE 
			@RespStat int = 0,
			@RespMsg varchar(150) = ''
			BEGIN
	
		BEGIN TRY	
		--Validate
		
		BEGIN TRANSACTION;
		UPDATE Customers SET Firstname=@Firstname,Lastname=@Lastname,Emailaddress=@Emailaddress,Phoneprefix=@Phoneprefix,Phonenumber=@Phonenumber,Customertype=@Customertype,Station=@Stationcode,Canaccessprtal=@Canaccessprtal,Datemodified=@Datemodified,Modifiedby=@Modifiedby WHERE Customercode=@Customercode

		Set @RespMsg ='Data Updated Successfully.'
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
