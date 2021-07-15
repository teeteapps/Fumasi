CREATE PROCEDURE [dbo].[Usp_GetListModel]
@Type int
AS
BEGIN
SET NOCOUNT ON;
If(@Type = 0)
Select m.Roledescription as Text, m.Rolecode as Value From Staffroles m;
If(@Type = 1)
Select m.Stationname as Text, m.Stationcode as Value From Stations m;
END