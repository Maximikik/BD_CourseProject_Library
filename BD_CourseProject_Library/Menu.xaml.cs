using BD_CourseProject_Library.Views;
using System.Windows;

namespace BD_CourseProject_Library
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        AuthorsWindow authors { get; set; }
        BooksWindow books { get; set; }
        GenresWindow genres { get; set; }
        ClientsWindow clients { get; set; }
        RecordsWindow records { get; set; }


        public Menu()
        {
            InitializeComponent();
            authors = new AuthorsWindow();
            books = new BooksWindow();
            genres = new GenresWindow();
            clients = new ClientsWindow();
            records = new RecordsWindow();
        }

        private void ButtonAuthors_Click(object sender, RoutedEventArgs e)
        {
            authors.Show();
            this.Hide();
        }

        private void ButtonBooks_Click(object sender, RoutedEventArgs e)
        {
            books.Show();
            this.Hide();
        }

        private async void ButtonGenres_Click(object sender, RoutedEventArgs e)
        {
            genres.Show();
            this.Hide();
        }

        private void ButtonClients_Click(object sender, RoutedEventArgs e)
        {
            clients.Show();
            this.Hide();
        }

        private void ButtonRecords_Click(object sender, RoutedEventArgs e)
        {
            records.Show();
            this.Hide();
        }
    }
}
