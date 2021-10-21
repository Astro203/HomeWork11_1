using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_1
{
    class Manager : BankClient
    {
        public Manager(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumberOfPassport,
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
                List<BankClient> BankClients = new List<BankClient>();
                BankClients = JsonConvert.DeserializeObject<List<BankClient>>(json);
                JsonConvert.SerializeObject(file);
                M.cbLastName.Items.Clear();
                foreach (var item in BankClients)
                {
                    M.cbLastName.Items.Add(item.LastName);
                }
                M.tbFirstName.Text = BankClients[0].FirstName;
                M.tbLastName.Text = BankClients[0].LastName;
                M.tbMiddleName.Text = BankClients[0].MiddleName;
                M.tbNumberTel.Text = BankClients[0].NumberTel;
                M.tbPassport.Text = BankClients[0].SerialAndNumberOfPassport;
            }
        }
        public void EditInfo(MainWindow M)
        {
            string json = "";
            string file = "Client.json";
            List<Manager> manager = new List<Manager>();
            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
                manager = JsonConvert.DeserializeObject<List<Manager>>(json);
                manager[M.cbLastName.SelectedIndex].FirstName = M.tbFirstName.Text;
                manager[M.cbLastName.SelectedIndex].LastName = M.tbLastName.Text;
                manager[M.cbLastName.SelectedIndex].MiddleName = M.tbMiddleName.Text;
                manager[M.cbLastName.SelectedIndex].NumberTel = M.tbNumberTel.Text;
                manager[M.cbLastName.SelectedIndex].SerialAndNumberOfPassport = M.tbPassport.Text;
                json = JsonConvert.SerializeObject(manager);
                File.WriteAllText(file, json);
            }
        }
        public static void AddInfo(MainWindow M)
        {
            string json = "";
            string file = "Client.json";
            List<Manager> manager = new List<Manager>();
            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
                manager = JsonConvert.DeserializeObject<List<Manager>>(json);
            }
            manager.Add(
                new Manager(
                    M.tbFirstName.Text,
                    M.tbLastName.Text,
                    M.tbMiddleName.Text,
                    M.tbNumberTel.Text,
                    M.tbPassport.Text),"","","","");
            json = JsonConvert.SerializeObject(manager);
            File.WriteAllText(file, json);
        }
    }
}
