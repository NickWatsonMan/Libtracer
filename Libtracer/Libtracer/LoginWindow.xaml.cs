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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Context ctx = new Context();
        public event Func<string, string, bool> OnLogin;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void AdminEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnLogin += ctx.Auth;
                var res = OnLogin?.Invoke(AdminLogin.Text, AdminPassword.Password.ToString());
                if (res == true)
                {
                    OptionsWindow _options = new OptionsWindow();
                    _options.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            
        }
    }
}
