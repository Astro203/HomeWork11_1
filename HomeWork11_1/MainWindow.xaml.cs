using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork11_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ShowClient()
        {
            string file = "Client.json";
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                List<Consultant> Clients = new List<Consultant>(); 
                Clients = JsonConvert.DeserializeObject<List<Consultant>>(json);
                tbFirstName.Text = Clients[cbLastName.SelectedIndex].FirstName;
                tbLastName.Text = Clients[cbLastName.SelectedIndex].LastName;
                tbMiddleName.Text = Clients[cbLastName.SelectedIndex].MiddleName;
                tbNumberTel.Text = Clients[cbLastName.SelectedIndex].NumberTel;
                JsonConvert.SerializeObject(file);
                if (cbUser.Text == "Консультант") tbPassport.Text = "***********"; else tbPassport.Text = Clients[cbLastName.SelectedIndex].SerialAndNumberOfPassport;
            }
        }

        public void CreateClient()
        {
            string json = "";
            string file = "Client.json";
            List<Manager> Clients = new List<Manager>();
            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
                Clients = JsonConvert.DeserializeObject<List<Manager>>(json);
            }
            Clients.Add(
                new Manager(
                    tbFirstName.Text,
                    tbLastName.Text,
                    tbMiddleName.Text,
                    tbNumberTel.Text,
                    tbPassport.Text));
            json = JsonConvert.SerializeObject(Clients);
            File.WriteAllText(file, json);
            MessageBox.Show("Информация добавлена");

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string file = "Client.json.json";
            string json = File.ReadAllText(file);
            List<Consultant> Clients = new List<Consultant>();
            Clients = JsonConvert.DeserializeObject<List<Consultant>>(json);
            if (tbNumberTel.Text != "")
            {
                Clients[cbLastName.SelectedIndex].NumberTel = tbNumberTel.Text;
            }
            else
            {
                tbNumberTel.Text = "8-999-999-99-99";
                Clients[cbLastName.SelectedIndex].NumberTel = tbNumberTel.Text;
            }
            json = JsonConvert.SerializeObject(Clients);
            File.WriteAllText(file, json);
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowClient();
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (cbUser.Text == "Менеджер")
            {
                CreateClient();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string file = "Client.json";
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                List<Consultant> Clients = new List<Consultant>();
                Clients = JsonConvert.DeserializeObject<List<Consultant>>(json);
                cbLastName.Items.Clear();
                foreach (var item in Clients)
                {
                    cbLastName.Items.Add(item.LastName);
                }
                tbFirstName.Text = Clients[0].FirstName;
                tbLastName.Text = Clients[0].LastName;
                tbMiddleName.Text = Clients[0].MiddleName;
                tbNumberTel.Text = Clients[0].NumberTel;
                JsonConvert.SerializeObject(file);
                tbPassport.Text = "***********";
            }
        }
    }
}
