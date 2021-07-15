CREATE PROCEDURE [dbo].[Usp_VerifyUser]
	@Emailaddress varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	Declare @Code int,
			@RespStat int = 0,
			@RespMsg varchar(150) = 'login success',
			@UserCode BIGINT,
			@Fullname varchar(100),
			@Phonenumber varchar(15),
			@Pwd varchar(150),
			@Pin varchar(150),
			@Rolecode int,
			@Email varchar(100),
			@Tenantcode bigint,
			@Tenantconnid VARCHAR(50),
			@Tenantconnkey VARCHAR(100),
			@Tenantconndata VARCHAR(MAX)

    BEGIN TRY
		----- Get user details
		Select @UserCode = Tenantcode,@Fullname=fullname,@Phonenumber=Phonenumber, @Pwd = Staffpass,@Pin=Staffpin,@Rolecode=Rolecode,@Email=Emailaddress,@Tenantcode=Tenantcode,@Tenantconnid=Tenantconnid,@Tenantconnkey=Tenantconnkey,@Tenantconndata=Tenantconndata From Vwtenantstafflogin Where Emailaddress = @Emailaddress
		If(@UserCode Is Null)
		Begin
			Select  1 as RespStatus, 'Invalid Username and/or Password!' as RespMessage
			Return
		End
		
		--- Create response
		Select  @RespStat as RespStatus, @RespMsg as RespMessage, @UserCode as Data1,@Fullname as Data2,@Phonenumber as Data3, @Pwd as Data4,@Pin as Data5,@Email as Data6,@Rolecode as Data7,@Tenantconnid as Data8,@Tenantconnkey as Data9,@Tenantconndata as Data10,@Tenantcode as Data11

	END TRY
	BEGIN CATCH
		SELECT @RespMsg = ERROR_MESSAGE(), @RespStat = 2;
		Select  @RespStat as RespStatus, @RespMsg as RespMessage
	END CATCH

END
