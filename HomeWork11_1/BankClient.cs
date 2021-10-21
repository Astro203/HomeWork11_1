using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_1
{
    abstract class BankClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NumberTel { get; set; }
        public string SerialAndNumberOfPassport { get; set; }
        public string Date { get; set; }
        public string CorrectFields { get; set; }
        public string TypeFields { get; set; }
        public string User { get; set; }
        
        public BankClient(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumberOfPassport,
            string Date, string CorrectFields, string TypeFields, string User)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.NumberTel = NumberTel;
            this.SerialAndNumberOfPassport = SerialAndNumberOfPassport;
            this.Date = Date;
            this.CorrectFields = CorrectFields;
            this.TypeFields = TypeFields;
            this.User = User;
        }
        

        public static void ShowClient(MainWindow M)
        {
            string file = "Client.json";
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                List<Consultant> Clients = new List<Consultant>();
                Clients = JsonConvert.DeserializeObject<List<Consultant>>(json);
                M.tbFirstName.Text = Clients[M.cbLastName.SelectedIndex].FirstName;
                M.tbLastName.Text = Clients[M.cbLastName.SelectedIndex].LastName;
                M.tbMiddleName.Text = Clients[M.cbLastName.SelectedIndex].MiddleName;
                M.tbNumberTel.Text = Clients[M.cbLastName.SelectedIndex].NumberTel;
                JsonConvert.SerializeObject(file);
                if (M.cbUser.Text == "Консультант") M.tbPassport.Text = "***********"; else M.tbPassport.Text = Clients[M.cbLastName.SelectedIndex].SerialAndNumberOfPassport;
            }
        }
    }
}
