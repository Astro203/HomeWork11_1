using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_1
{
    class Consultant : BankClient
    { 
        public Consultant(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumbeOfPassport, int DepartamentID)
            : base(FirstName, LastName, MiddleName, NumberTel, SerialAndNumbeOfPassport, DepartamentID)
        {
            
        }
        public void EditInfo(string NumberTel)
        {
            base.NumberTel = NumberTel;
        }
    }
}
