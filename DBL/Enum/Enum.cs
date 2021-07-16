using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Enum
{
    public enum UserLoginStatus { Ok = 0, ChangePassword = 1 }
    public enum ResponseStatus
    {
        Success = 0,
        Warning = 1,
        Error = 2,
        Unknown = 3
    }
    public enum ListModelType
    {
        staffroles = 0,
        phoneprefix = 1,
        tenantstations = 2,
        identifiers = 3,
        identifiertypes = 4,
        limittypes = 5,
        pricelist = 6,
        discountlist = 7,
        Loyaltylist = 8

    }
    public enum CartStatus
    {
        AddedtoCart = 1, RemovedfromCart = 2, PurchasedtheItem = 3

    }
}
