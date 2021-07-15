

CREATE VIEW [dbo].[Customerprepaidagreementdata] AS SELECT PA.Agreementcode,PA.Customercode,AA.Accountcode,Count(Accountnumber) as Numberofaccounts,CASE WHEN PA.Agreementtype=0 THEN 'Prepaid-Amount' ELSE 'Prepaid-Litres' END AS Agreementtype,
PA.Agreementdesc,PA.Agreementdoc,PA.Notes,AA.Accountnumber,AA.Hasdrivercode,CASE WHEN AA.Isactive=1 THEN 'Active' ELSE 'Inactive' END AS Isactive,CASE WHEN AA.Isdelete=1 THEN 'Deleted' ELSE 'Not Deleted' END AS Isdelete,ID.Identifiersno,ID.Identifieruid,IT.Typename 
FROM Customerprepaidagreement PA 
LEFT JOIN Customeragreementaccount AA ON PA.Agreementcode=AA.Agreementcode
LEFT JOIN Lnkaccountandidentifiers LCI ON LCI.Accountcode=AA.Accountcode
INNER JOIN Identifiers ID ON ID.Identifiercode=LCI.Identifiercode
INNER JOIN Identifiertype IT ON IT.Typecode=ID.identifiertype
GROUP BY
PA.Agreementcode,PA.Customercode,AA.Accountcode, PA.Agreementtype,
PA.Agreementdesc,PA.Agreementdoc,PA.Notes,AA.Accountnumber,AA.Hasdrivercode,AA.Isactive,AA.Isdelete,ID.Identifiersno,ID.Identifieruid,IT.Typename 
