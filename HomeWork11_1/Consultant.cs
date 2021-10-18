using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_1
{
    class Consultant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NumberTel { get; set; }
        public string SerialAndNumberOfPassport { get; set; }
        public Consultant(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumberOfPassport)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.NumberTel = NumberTel;
            this.SerialAndNumberOfPassport = SerialAndNumberOfPassport;
        }
    }
}
