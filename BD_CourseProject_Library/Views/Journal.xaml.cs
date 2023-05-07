using BD_CourseProject_Library.Models;
using BD_CourseProject_Library.Models.DisplayConfigs;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Windows;
using static BD_CourseProject_Library.Models.ReportRentDisplayConfigurator;

namespace BD_CourseProject_Library.Views
{
    /// <summary>
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        LibraryDbContext _context;

        public Journal()
        {
            InitializeComponent();

            _context = new LibraryDbContext();

            ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context);
            ListRents.ItemsSource = _context.ReportRents.ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        

        private void DescOrAsc_Checked(object sender, RoutedEventArgs e)
        {

        }



        private void DescOrAsc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
