using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Helpers
{
    public class Randomnumbergenerator
    {
        Random rnd = new Random();
        public long GenerateRandomNo()
        {
            return rnd.Next(10000002, 99999999);
        }
        public long GenerateRandomPass()
        {
            return rnd.Next(10000, 999999);
        }
        public long GenerateRandomPin()
        {
            return rnd.Next(1000, 9999);
        }
    }
}
