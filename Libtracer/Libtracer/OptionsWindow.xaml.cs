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
    /// Логика взаимодействия для OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void AdminHandOut_Click(object sender, RoutedEventArgs e)
        {
            HandOutBook _handOutBook = new HandOutBook();
            _handOutBook.Show();
            this.Close();
        }

        private void AdminHandIn_Click(object sender, RoutedEventArgs e)
        {
            HandInBook _handInBook = new HandInBook();
            _handInBook.Show();
            this.Close();
        }

        private void AdminReg_Click(object sender, RoutedEventArgs e)
        {
            RegistrateWindow _registrate = new RegistrateWindow();
            _registrate.Show();
            this.Close();
        }

        private void AdminLists_Click(object sender, RoutedEventArgs e)
        {
            ListsWindow _lists = new ListsWindow();
            _lists.Show();
            this.Close();
        }
    }
}
