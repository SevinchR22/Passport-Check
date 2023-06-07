using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PassportCheck
{
    class Passport:IPassport
    {
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }

        public string GetPassportNumber()
        {
            return PassportNumber;
        }

        public string GetNationality()
        {
            return Nationality;
        }

        public bool IsValid()
        {
            return true;
        }
    }
}
