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
    public interface InterfaceConsultant
    {
        void EditInformationForConsultant(MainWindow M);
    }

    public interface InterfaceManager
    {
        void EditInformationForManager(MainWindow M);
    }

    class NewClass : BankClient, InterfaceConsultant, InterfaceManager
    { 
        public NewClass(string FirstName, string LastName, string MiddleName, string NumberTel, string SerialAndNumberOfPassport,
            string Date, string CorrectFields, string TypeFields, string User)
            : base(FirstName, LastName, MiddleName, NumberTel, SerialAndNumberOfPassport, Date, CorrectFields, TypeFields, User)
        {

        }

        public void EditInformationForConsultant(MainWindow M)
        {
            string json = "";
            string file = "Client.json";
            List<Manager> manager = new List<Manager>();
            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
                manager = JsonConvert.DeserializeObject<List<Manager>>(json);
                manager[M.cbLastName.SelectedIndex].Date = Convert.ToString(DateTime.Now);
                manager[M.cbLastName.SelectedIndex].CorrectFields += "Номер телефона ";
                manager[M.cbLastName.SelectedIndex].User = M.cbUser.Text;
                MessageBox.Show($"Изменены поля: {manager[M.cbLastName.SelectedIndex].CorrectFields}");
                json = JsonConvert.SerializeObject(manager);
                File.WriteAllText(file, json);
            }
        }

        public void EditInformationForManager(MainWindow M)
        {
            string json = "";
            string file = "Client.json";
            List<Manager> manager = new List<Manager>();
            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
                manager = JsonConvert.DeserializeObject<List<Manager>>(json);
                manager[M.cbLastName.SelectedIndex].Date = Convert.ToString(DateTime.Now);
                if (manager[M.cbLastName.SelectedIndex].FirstName != M.tbFirstName.Text)
                {
                    manager[M.cbLastName.SelectedIndex].CorrectFields = "Имя ";
                }
                if(manager[M.cbLastName.SelectedIndex].LastName != M.tbLastName.Text)
                {
                    manager[M.cbLastName.SelectedIndex].CorrectFields += "Фамилия ";
                }
                if(manager[M.cbLastName.SelectedIndex].MiddleName != M.tbMiddleName.Text)
                {
                    manager[M.cbLastName.SelectedIndex].CorrectFields += "Отчество ";
                }
                if(manager[M.cbLastName.SelectedIndex].NumberTel != M.tbNumberTel.Text)
                {
                    manager[M.cbLastName.SelectedIndex].CorrectFields += "Номер телефона ";
                }
                if(manager[M.cbLastName.SelectedIndex].SerialAndNumberOfPassport != M.tbPassport.Text)
                {
                    manager[M.cbLastName.SelectedIndex].CorrectFields = "Серия и номер паспорта";
                }
                manager[M.cbLastName.SelectedIndex].User = M.cbUser.Text;
                MessageBox.Show($"Изменены поля: {manager[M.cbLastName.SelectedIndex].CorrectFields}");
                json = JsonConvert.SerializeObject(manager);
                File.WriteAllText(file, json);
            }
        }
    }
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(cbUser.Text == "Консультант")
            {
                Consultant consultant = new Consultant(tbFirstName.Text, tbLastName.Text, tbMiddleName.Text, tbNumberTel.Text, tbPassport.Text, tbDate.Text,
                    tbCorrect.Text, tbType.Text, tbUser.Text);
                consultant.EditInfo(tbNumberTel.Text);              
            }
            else
            {
                Manager manager = new Manager(tbFirstName.Text, tbLastName.Text, tbMiddleName.Text, tbNumberTel.Text, tbPassport.Text, tbDate.Text,
                    tbCorrect.Text, tbType.Text, tbUser.Text);
                manager.EditInfo(this);
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BankClient.ShowClient(this);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(cbUser.Text == "Менеджер")
            {
                Manager.AddInfo(this);
                MessageBox.Show("Информация добавлена");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (cbUser.Text == "Консультант")
            {
                Consultant consultant = new Consultant(tbFirstName.Text, tbLastName.Text, tbMiddleName.Text, tbNumberTel.Text, tbPassport.Text, tbDate.Text,
                    tbCorrect.Text, tbType.Text, tbUser.Text);
                consultant.GetInfo(this);
                InterfaceConsultant interfaceconsultant = new NewClass(tbFirstName.Text, tbLastName.Text, tbMiddleName.Text, tbNumberTel.Text, tbPassport.Text, tbDate.Text,
                    tbCorrect.Text, tbType.Text, tbUser.Text);
                interfaceconsultant.EditInformationForConsultant(this);
            }
            else
            {
                Manager manager = new Manager(tbFirstName.Text, tbLastName.Text, tbMiddleName.Text, tbNumberTel.Text, tbPassport.Text, tbDate.Text,
                    tbCorrect.Text, tbType.Text, tbUser.Text);
                manager.GetInfo(this);
                InterfaceManager interfacemanager = new NewClass(tbFirstName.Text, tbLastName.Text, tbMiddleName.Text, tbNumberTel.Text, tbPassport.Text, tbDate.Text,
                    tbCorrect.Text, tbType.Text, tbUser.Text);
                interfacemanager.EditInformationForManager(this);
            }
        }
    }
}
