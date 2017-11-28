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

namespace Libtracer
{
    /// <summary>
    /// Логика взаимодействия для HandInBook.xaml
    /// </summary>
    public partial class HandInBook : Window
    {
        public HandInBook()
        {
            InitializeComponent();
        }


        private void HandInBack_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow _options = new OptionsWindow();
            _options.Show();
            this.Close();
        }

        private void HandIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HandInPersonId.Text = "";
                HandInBookId.Text = "";
                HandInSuccess.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                HandInSuccess.Visibility = Visibility.Hidden;
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
