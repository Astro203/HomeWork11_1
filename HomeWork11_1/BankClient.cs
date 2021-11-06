using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HomeWork11_1
{
    class BankClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NumberTel { get; set; }
        public string SerialAndNumbeOfPassport { get; set; }
        public int DepartamentID { get; private set; }
        
        public BankClient(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumbeOfPassport, int DepartamentID)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.NumberTel = NumberTel;
            this.SerialAndNumbeOfPassport = SerialAndNumbeOfPassport;
            this.DepartamentID = DepartamentID;
        }

    }
}
