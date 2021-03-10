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
        tenantstations = 1,
        identifiers = 2,
        identifiertypes = 3

    }
    public enum CartStatus
    {
        AddedtoCart = 1, RemovedfromCart = 2, PurchasedtheItem = 3

    }
}
