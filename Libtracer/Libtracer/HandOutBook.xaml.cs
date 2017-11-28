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
        Context _context = new Context();
        public event Action<int, int, DateTime, DateTime> OnHandOut;

        public HandOutBook()
        {
           
            InitializeComponent();
        }

        private void HandOut_Click(object sender, RoutedEventArgs e)
        {
            OnHandOut += _context.HandOutBook;
            //_context.HandOutBook(int.Parse(HandOutPersonId.Text), int.Parse(HandOutBookId.Text), DateTime.Now, DateTime.Now.AddMonths(1));       
            OnHandOut?.Invoke(int.Parse(HandOutPersonId.Text), int.Parse(HandOutBookId.Text), DateTime.Now, DateTime.Now.AddMonths(1));
        }

        private void HandOutBack_Click(object sender, RoutedEventArgs e)
        {
            
            OptionsWindow _options = new OptionsWindow();
            _options.Show();
            this.Close();
        }
    }
}
