

CREATE VIEW [dbo].[Vwagreementaccounts] AS SELECT AA.Accountcode,AA.Accountnumber,AA.Agreementcode,ID.Identifiersno,ID.Identifieruid,LCI.Isparent 
FROM Customeragreementaccount AA
LEFT JOIN Lnkaccountandidentifiers LCI ON LCI.Accountcode=AA.Accountcode
INNER JOIN Identifiers ID ON LCI.Identifiercode =ID.identifiertype 
