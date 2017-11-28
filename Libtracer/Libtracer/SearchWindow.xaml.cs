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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        Context ctx = new Context();
        public event Func<string, string, List<Book>> OnSearch;
        public SearchWindow()
        {
            InitializeComponent();
        }


        private void SearchBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnSearch = ctx.GetBook;
                var Search = OnSearch?.Invoke(SearchName.Text, SearchAuthor.Text);
                foreach(var item in Search)
                {
                    SearchList.Items.Add(new { Author = item.Author, Book = item.Title, Shelf = item.Shelf.Number, Department = item.Shelf.Department });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

    }
}
