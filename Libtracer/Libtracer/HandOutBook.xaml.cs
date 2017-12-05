using Logics;
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
    /// Логика взаимодействия для HandOutBook.xaml
    /// </summary>
    public partial class HandOutBook : Window
    {
        Context _ctx = new Context();
        public event Func<int, int, DateTime, DateTime, bool> OnHandOut;

        public HandOutBook()
        {
           
            InitializeComponent();
        }

        private void HandOut_Click(object sender, RoutedEventArgs e)
        {
            OnHandOut += _ctx.HandOutBook;
            try
            {
                OnHandOut = _ctx.HandOutBook;
                var res = OnHandOut?.Invoke(int.Parse(HandOutPersonId.Text), int.Parse(HandOutBookId.Text), DateTime.Now, DateTime.Now.AddMonths(1));
                if (res == true)
                {
                    HandOutBookId.Text = "";
                    HandOutPersonId.Text = "";
                    HandOutSuccess.Visibility = Visibility.Visible;
                } else
                {
                    MessageBox.Show("Книга недоступна");
                }
            }
            catch (Exception ex)
            {
                HandOutSuccess.Visibility = Visibility.Hidden;
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void HandOutBack_Click(object sender, RoutedEventArgs e)
        {
            
            OptionsWindow _options = new OptionsWindow();
            _options.Show();
            this.Close();
        }
    }
}
