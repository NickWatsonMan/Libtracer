﻿using System;
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
using System.Data.Entity;
using Logics;
using Logics.Models;

namespace Libtracer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context cont = new Context();
        public MainWindow()
        { 
            InitializeComponent();
            //cont.Shelves.Add(new Shelf { Number = 4, Department = "SF" });
        }



        private void OpenSearchWindow(object sender, RoutedEventArgs e)
        {
            SearchWindow _search = new SearchWindow();
            _search.Show();
        }

        private void OpenAdminWindow(object sender, RoutedEventArgs e)
        {
            LoginWindow _login = new LoginWindow();
            _login.Show();
        }
    }
}
