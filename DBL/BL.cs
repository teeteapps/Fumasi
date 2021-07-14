using DBL.UOW;
using System;

namespace DBL
{
    public class BL
    {
        private UnitofWork db;
        private string _connString;
        //Passwordgenerator pass = new Passwordgenerator();
        //EncryptDecrypt sec = new EncryptDecrypt();
        public BL(string connString)
        {
            this._connString = connString;
            db = new UnitofWork(connString);
        }
    }
}
