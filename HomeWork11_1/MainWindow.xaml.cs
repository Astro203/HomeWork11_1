using GalaSoft.MvvmLight.CommandWpf;
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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork11_1
{
    class NewClass : BankClient
    { 
        public NewClass(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumberOfPassport, int DepartamentID)
            : base(FirstName, LastName, MiddleName, NumberTel, SerialAndNumberOfPassport, DepartamentID)
        {

        }
    }
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string json;
        public MainWindow()
        {
            InitializeComponent();
            cbUser.Text = "Консультант";
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(cbUser.Text == "Консультант")
            {
                MessageBox.Show("Консультант не может вносить изменения");
            }
            else
            {
                Manager.EditClient(this);
                MessageBox.Show("Запись о клиенте изменена");
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(cbUser.Text == "Менеджер")
            {
                Manager.AddClient(this);
                MessageBox.Show("Информация добавлена");
            }
            else
            {
                MessageBox.Show("Консультант не может добавлять клиентов");
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Departaments.json"))
            { 
                json = File.ReadAllText("Departaments.json");
                List<Departament> Departaments = new List<Departament>();
                Departaments = JsonConvert.DeserializeObject<List<Departament>>(json);
                JsonConvert.SerializeObject(Departaments);
                lvDepartaments.ItemsSource = Departaments;
            }
            else MessageBox.Show("Нет списка департаментов");
        }
        private void lvDepartaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            json = File.ReadAllText("Clients.json");
            List<BankClient> Clients = new List<BankClient>();
            Clients = JsonConvert.DeserializeObject<List<BankClient>>(json);
            JsonConvert.SerializeObject(Clients);
            if (cbUser.Text == "Консультант")
            {
                foreach (var item in Clients)
                {
                    item.NumberTel = "***********";
                }
            }
            lvClients.ItemsSource = Clients.Where(findID);          
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (cbUser.Text == "Менеджер")
            {
                if (File.Exists("Clients.json"))
                {
                    json = File.ReadAllText("Clients.json");
                    List<BankClient> Clients = new List<BankClient>();
                    Clients = JsonConvert.DeserializeObject<List<BankClient>>(json);
                    Clients.RemoveAt(lvClients.SelectedIndex);
                    json = JsonConvert.SerializeObject(Clients);
                    File.WriteAllText("Clients.json", json);
                    MessageBox.Show("Запись удалена");
                }
            }
            else MessageBox.Show("Консультант не может удалять данные о клиентах");
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (cbUser.Text == "Менеджер")
            {
                Manager.AddDepartament(this);
                MessageBox.Show("Депаратмент добавлен");
            }
            else MessageBox.Show("Консультант не может добавлять департаменты");
        }
        private bool findID(BankClient arg)
        {
            return arg.DepartamentID == (lvDepartaments.SelectedItem as Departament).DepartamentID;
        }
        private void tbDep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(cbUser.Text == "Консультант")
            {

            }
            else
            {

            }
        }
    }
}
