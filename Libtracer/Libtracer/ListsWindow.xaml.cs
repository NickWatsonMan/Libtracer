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
    /// Логика взаимодействия для ListsWindow.xaml
    /// </summary>
    public partial class ListsWindow : Window
    {
        Context ctx = new Context();
        public event Func<Task<List<PersonBook>>> OnList;
        public ListsWindow()
        {
            InitializeComponent();
        }

        private void ListsBack_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow _options = new OptionsWindow();
            _options.Show();
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                OnList = ctx.GetDebtors;
                var SearchDeb = await OnList?.Invoke();
                foreach (var item in SearchDeb)
                {
                    DebtorsList.Items.Add(new { Name = item.Person.Name.ToString(), Surname = item.Person.LastName.ToString(), BookName = item.Book.Title.ToString(), BookId = item.Book.BookId.ToString(), Phone = item.Person.Phone, Email = item.Person.Email, EndDate = item.EndDate.ToShortDateString() });
                }

                OnList = ctx.GetLentBooks;
                var SearchBook = await OnList?.Invoke();
                foreach (var item in SearchBook)
                {
                    BooksList.Items.Add(new { Name = item.Person.Name.ToString(), Surname = item.Person.LastName.ToString(), BookName = item.Book.Title.ToString(), BookId = item.Book.BookId.ToString(), Phone = item.Person.Phone, Email = item.Person.Email, EndDate = item.EndDate.ToShortDateString(), StartDate = item.StartDate.ToShortDateString() });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
