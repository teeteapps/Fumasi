CREATE PROCEDURE [dbo].[Usp_GetListModel]
@Type int
AS
BEGIN
SET NOCOUNT ON;
If(@Type = 0)
Select m.Roledescription as Text, m.Rolecode as Value From Staffroles m;
If(@Type = 1)
Select p.Prefixname as Text, p.Prefixcode as Value From Phoneprefix p;
If(@Type = 2)
Select m.Stationname as Text, m.Stationcode as Value From Stations m;
If(@Type = 3)
Select m.Identifieruid as Text, m.Identifiercode as Value From Identifiers m;
If(@Type = 4)
Select m.Typename as Text, m.Typecode as Value From Identifiertype m;
END
