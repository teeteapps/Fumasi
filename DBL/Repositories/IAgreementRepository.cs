using DBL.Entities;
using DBL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Repositories
{
    public interface IAgreementRepository
    {
        #region One Off Agreement
        GenericModel Addnewoneoffagreement(Customeroneoffagreement entity);
        #endregion

        #region Recurrent Agreement
        GenericModel Addnewrecurrentagreement(Customerrecurrentagreement entity);
        #endregion

        #region Prepaid Agreement
        GenericModel Addnewprepaidagreement(Customerprepaidagreement entity);
       IEnumerable<Viewcustomeragreements> Gettenantcustomerprepaidagreementdata(long Customercode);
        #endregion

        #region Agreement Accounts
        GenericModel Addnewagreementaccount(Customeragreementaccount entity);
        IEnumerable<Vwagreementaccounts> Getagreementaccountsdata(long Agreementcode);
        #endregion

        #region Agreement Account and Account Policies
        #region Account Identifiers
         GenericModel Addnewaccountidentifier(Customeragreementaccountidentifiers entity);
        #endregion
        #region Account Employee
        GenericModel Addnewaccountemployee(Customeragreementaccountemployees entity);
        #endregion
        #endregion
    }
}
