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
using System.Windows.Shapes;
using Logics;
using Logics.Models;

namespace Libtracer
{
    /// <summary>
    /// Логика взаимодействия для RegistrateWindow.xaml
    /// </summary>
    public partial class RegistrateWindow : Window
    {
        Context ctx = new Context();
        public event Action<string, string, int> OnRegisterBook;
        public event Action<int, string> OnRegisterShelf;
        public event Action<string, string, int, DateTime, string, string, bool, string> OnRegisterPerson;
        public RegistrateWindow()
        {
            InitializeComponent();
        }

        private void RegPerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnRegisterPerson = ctx.AddNewUser;
                if (RegPersonRole.Text == "Admin")
                {
                    OnRegisterPerson?.Invoke(RegPersonName.Text, RegPersonSurname.Text, int.Parse(RegPersonPassport.Text), Convert.ToDateTime(RegPersonDate.SelectedDate), RegPersonPhone.Text, RegPersonMail.Text, true, RegPersonPassword.Text);
                } else
                {
                    OnRegisterPerson?.Invoke(RegPersonName.Text, RegPersonSurname.Text, int.Parse(RegPersonPassport.Text), Convert.ToDateTime(RegPersonDate.SelectedDate), RegPersonPhone.Text, RegPersonMail.Text, false, null);
                }

                RegPersonName.Text = "";
                RegPersonDate.Text = "";
                RegPersonMail.Text = "";
                RegPersonPassport.Text = "";
                RegPersonPassword.Text = "";
                RegPersonRole.Text = "";
                RegPersonSurname.Text = "";
                RegPersonPhone.Text = "";

                RegPersonSuccess.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                RegPersonSuccess.Visibility = Visibility.Hidden;
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void RegBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnRegisterBook = ctx.AddBookToLibrary;
                OnRegisterBook?.Invoke(RegBookName.Text, RegBookAuthor.Text, int.Parse(RegBookShelf.Text));
                RegBookName.Text = "";
                RegBookAuthor.Text = "";
                RegBookShelf.Text = "";

                RegBookSuccess.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                RegBookSuccess.Visibility = Visibility.Hidden;
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void RegShelf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnRegisterShelf = ctx.AddNewShelf;
                OnRegisterShelf?.Invoke(int.Parse(RegShelfNumber.Text), RegShelfDepartment.Text);
                RegShelfNumber.Text = "";
                RegShelfDepartment.Text = "";

                RegShelfSuccess.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                RegShelfSuccess.Visibility = Visibility.Hidden;
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void RegistrateBack_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow _options = new OptionsWindow();
            _options.Show();
            this.Close();
        }
    }
}
