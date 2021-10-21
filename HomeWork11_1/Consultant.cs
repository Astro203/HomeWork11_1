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
        public Consultant(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumberOfPassport,
            string Date, string CorrectFields, string TypeFields, string User)
            : base(FirstName, LastName, MiddleName, NumberTel, SerialAndNumberOfPassport, Date, CorrectFields, TypeFields, User)
        {
            
        }

        public void GetInfo(MainWindow M)
        {
            string file = "Client.json";
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                List<Consultant> consultant = new List<Consultant>();
                consultant = JsonConvert.DeserializeObject<List<Consultant>>(json);
                JsonConvert.SerializeObject(file);
                M.cbLastName.Items.Clear();
                foreach (var item in consultant)
                {
                    M.cbLastName.Items.Add(item.LastName);
                }
                M.tbFirstName.Text = consultant[0].FirstName;
                M.tbLastName.Text = consultant[0].LastName;
                M.tbMiddleName.Text = consultant[0].MiddleName;
                M.tbNumberTel.Text = consultant[0].NumberTel;
                M.tbPassport.Text = "****************";
            }
        }
        public void EditInfo(string NumberTel)
        {
            base.NumberTel = NumberTel;
        }
    }
}
