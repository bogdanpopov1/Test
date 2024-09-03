using System;
using System.Collections.Generic;
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
using Test.Data;

namespace Test
{
    public partial class MainWindow : Window
    {
        private List<Person> peopleList;
        private Person person;
        public MainWindow()
        {
            InitializeComponent();
            peopleList = DB_Connection.GetPeople();
        }

        private double Calculate()
        {
            if (String.IsNullOrEmpty(Surname_TB.Text) || String.IsNullOrEmpty(Revenue_TB.Text) || Date_DP.SelectedDate == null)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error); 
                return 0;
            }

            bool surnameExists = false;

            foreach (Person p in peopleList) 
            { 
                if (p.Surname.ToLower() == Surname_TB.Text.ToLower().Trim())
                {
                    surnameExists = true;
                    person = p;
                    SurnameResult_TB.Text = p.FullName;
                }
            }

            if (!surnameExists)
            {
                MessageBox.Show("Фамилии нет в базе данных!", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            try
            {
                if (Convert.ToDouble(Revenue_TB.Text) < 50000)
                {
                    if (ExperienceIsCorrect())
                        return Math.Round(Convert.ToDouble(Revenue_TB.Text) * 0.03 + Convert.ToDouble(Revenue_TB.Text) * 0.03 * 0.05, 2);
                    else return Math.Round(Convert.ToDouble(Revenue_TB.Text) * 0.03, 2);

                }
                else
                {
                    if (ExperienceIsCorrect())
                        return Math.Round(Convert.ToDouble(Revenue_TB.Text) * 0.06 + Convert.ToDouble(Revenue_TB.Text) * 0.06 * 0.05, 2);
                    else return Math.Round(Convert.ToDouble(Revenue_TB.Text) * 0.06, 2);
                }
            } catch
            {
                MessageBox.Show("Средняя дневная выручка должна быть числом!", "Ошибка заполнения", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            
        }

        private bool ExperienceIsCorrect()
        {
            if (DateTime.Now.Year - Date_DP.SelectedDate.Value.Year > 5)
                return true;

            return false;
        }

        private void Calculate_Btn_Click(object sender, RoutedEventArgs e)
        {
            person = null;
            Result_TB.Text = Calculate().ToString();
            if (person != null && Result_TB.Text != "0")
                Sellers.Items.Add(new PaySlip(person, Math.Round(Convert.ToDouble(Result_TB.Text), 2), Convert.ToDouble(Revenue_TB.Text), DateTime.Now.Year - Date_DP.SelectedDate.Value.Year));
        }

        private void Surname_TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (Person p in peopleList)
            {
                if (p.Surname.ToLower() == Surname_TB.Text.ToLower().Trim())
                    Date_DP.SelectedDate = p.GetWorkDate.Date;
            }
        }
    }
}
