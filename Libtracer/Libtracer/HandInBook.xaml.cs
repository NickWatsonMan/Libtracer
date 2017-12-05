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
    /// Логика взаимодействия для HandInBook.xaml
    /// </summary>
    public partial class HandInBook : Window
    {
        Context ctx = new Context();
        public event Action<int, int, int> OnHandIn;
        public HandInBook()
        {
            InitializeComponent();
        }

        private void HandIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnHandIn += ctx.HandInBook;
                OnHandIn?.Invoke(int.Parse(HandInPersonId.Text), int.Parse(HandInBookId.Text), int.Parse(HandInShelf.Text));
                HandInSuccess.Visibility = Visibility.Visible;
                HandInPersonId.Text = "";
                HandInBookId.Text = "";
                HandInShelf.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void HandInBack_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow _options = new OptionsWindow();
            _options.Show();
            this.Close();
        }
    }
}
