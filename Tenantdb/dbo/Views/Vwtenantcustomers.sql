



CREATE VIEW [dbo].[Vwtenantcustomers] AS Select TC.Customercode,TC.Tenantcode,TC.Firstname +' '+ TC.Lastname as Fullname,TC.Phonenumber,TC.Emailaddress,TS.Stationname,CASE WHEN TC.Customertype=100 THEN 'Individual' ELSE 'Corporate' END AS Customertype,TC.Isactive,TC.Isdeleted,CASE WHEN TC.Canaccessprtal=1 THEN 'Yes' ELSE 'No' END AS Canaccessprtal  from Customers TC INNER JOIN Stations TS ON TC.Station=TS.Stationcode
