using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PassportCheck
{
    interface IPassport
    {
        string GetPassportNumber();
        string GetNationality();
        bool IsValid();
    }
}
