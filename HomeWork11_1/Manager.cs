using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork11_1
{
    class Manager : BankClient
    {
        public Manager(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumbeOfPassport, int DepartamentID)
            : base(FirstName, LastName, MiddleName, NumberTel, SerialAndNumbeOfPassport, DepartamentID)
        {

        }
        public static void AddDepartament(MainWindow M)
        {
            string json = "";
            string file = "Departaments.json";
            List<Departament> departament = new List<Departament>();
            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
                departament = JsonConvert.DeserializeObject<List<Departament>>(json);
                if (!departament.Exists(x => x.Name == M.tbDep.Text))
                {
                    departament.Add
                    (new Departament(
                         M.tbDep.Text,
                         departament.Count));
                }
                else MessageBox.Show("Департамент с таким именем уже существует");
                json = JsonConvert.SerializeObject(departament);
                File.WriteAllText(file, json);
            }
            M.lvDepartaments.ItemsSource = departament;
        }
        public static void EditClient(MainWindow M)
        {
            string json = "";
            string file = "Client.json";
            List<Manager> clients = new List<Manager>();
            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
                clients = JsonConvert.DeserializeObject<List<Manager>>(json);
                BankClient client = (BankClient)M.lvClients.SelectedItem;
                client.LastName = M.tbLastName.Text;
                client.FirstName = M.tbFirstName.Text;
                client.MiddleName = M.tbMiddleName.Text;
                client.NumberTel = M.tbNumberTel.Text;
                client.SerialAndNumbeOfPassport = M.tbPassport.Text;
                json = JsonConvert.SerializeObject(clients);
                File.WriteAllText(file, json);
            }          
        }
        public static void AddClient(MainWindow M)
        {
            string json = "";
            string file = "Client.json";
            List<Manager> clients = new List<Manager>();
            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
                clients = JsonConvert.DeserializeObject<List<Manager>>(json);
            }
            clients.Add(
                new Manager(
                    M.tbFirstName.Text,
                    M.tbLastName.Text,
                    M.tbMiddleName.Text,
                    M.tbNumberTel.Text,
                    M.tbPassport.Text,
                    findDepID(M.lvDepartaments.SelectedItem.ToString())));
            json = JsonConvert.SerializeObject(clients);
            File.WriteAllText(file, json);
        }

        private static int findDepID(string Name)
        {
            string file = "Departaments.json";
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                List<Departament> departaments = new List<Departament>();
                departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
                foreach (var item in departaments)
                {
                    if (item.Name == Name) return item.DepartamentID;
                }
                json = JsonConvert.SerializeObject(departaments);
                File.WriteAllText(file, json);
            }
            return 0;
        }
    }
}
