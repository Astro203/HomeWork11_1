using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_1
{
    class Manager : Consultant
    {
        public Manager(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumberOfPassport)
            : base(FirstName, LastName, MiddleName, NumberTel, SerialAndNumberOfPassport)
        {
            
        }
    }
}
