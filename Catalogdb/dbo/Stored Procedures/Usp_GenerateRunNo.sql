CREATE PROCEDURE [dbo].[Usp_GenerateRunNo]
	-- Add the parameters for the stored procedure here
	@ItemCode Varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @CurrNo BIGINT

    -- Insert statements for procedure here
	Select top 1 @CurrNo = RunningNo From RunningNos Where ItemCode = @ItemCode
	If (@CurrNo IS NULL)
	Begin
		Set @CurrNo = 100
		Insert Into RunningNos(RunningNo,ItemCode) Values(@CurrNo,@ItemCode)
	End
	Else
	Begin
		Set @CurrNo = @CurrNo + 1
		Update RunningNos Set RunningNo = @CurrNo Where ItemCode = @ItemCode
	End

	SELECT @CurrNo As RunningNo
END