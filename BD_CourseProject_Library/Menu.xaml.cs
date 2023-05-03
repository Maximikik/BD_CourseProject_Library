using BD_CourseProject_Library.Models;
using BD_CourseProject_Library.Views;
using Microsoft.EntityFrameworkCore;
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

namespace BD_CourseProject_Library
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        LibraryDbContext libraryDbContext;
        public Menu()
        {
            InitializeComponent();
            libraryDbContext = new LibraryDbContext();
        }

        private void ButtonAuthors_Click(object sender, RoutedEventArgs e)
        {
            new AuthorsWindow().Show();
            this.Close();
        }

        private void ButtonBooks_Click(object sender, RoutedEventArgs e)
        {
            new BooksWindow().Show();
            this.Close();
        }

        private async void ButtonGenres_Click(object sender, RoutedEventArgs e)
        {
            new GenresWindow().Show();
            this.Close();
        }

        private void ButtonClients_Click(object sender, RoutedEventArgs e)
        {
            new ClientsWindow().Show();
            this.Close();
        }

        private void ButtonRecords_Click(object sender, RoutedEventArgs e)
        {
            new RecordsWindow().Show();
            this.Close();
        }
    }
}
