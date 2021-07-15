

CREATE VIEW [dbo].[Vwtenantstafflogin] AS SELECt TS.Staffcode,TS.Tenantcode,TS.Rolecode,TS.Firstname+' '+ TS.Lastname AS Fullname,TS.Emailaddress,TS.Phonenumber,TS.Staffpass,TS.Staffpin,TS.Staffstatus,TS.Topuplimittype,TS.Topuplimitvalue,TS.Stationcode,FS.Tenantname,FS.Tenantconnid,FS.Tenantconnkey,FS.Tenantconndata,FS.Tenantstatus FROM Tenantstaffs TS INNER JOIN Fumasitenants FS ON TS.Tenantcode=FS.Tenantcode
