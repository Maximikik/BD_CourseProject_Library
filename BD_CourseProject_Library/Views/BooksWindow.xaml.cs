using BD_CourseProject_Library.Controllers.Books.Add;
using BD_CourseProject_Library.Controllers.Books.Delete;
using BD_CourseProject_Library.Controllers.Books.Edit;
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

namespace BD_CourseProject_Library.Views
{
    /// <summary>
    /// Interaction logic for BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {
        private readonly LibraryDbContext _context;
        public BooksWindow()
        {
            InitializeComponent();
        
            _context = new LibraryDbContext();

            MainList.ItemsSource = _context.Books.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var query = new AddBookQuery()
            {
                Name = textBoxName.Text,
                Author = textBoxAuthor.Text,
                Genre = textBoxGenre.Text,
                Quantity = Convert.ToInt32(textBoxQuantity.Text)
            };

            if (!AddBook.Add(_context, query))
            {
                MessageBox.Show("Error!");
                ClearAddTextBoxes();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var query = new DeleteBookQuery()
            {
                id = Convert.ToInt32(textBoxIdDelete.Text)
            };

            if (!DeleteBook.Delete(_context, query))
            {
                MessageBox.Show("Error!");
                ClearDeleteTextBox();
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            var query = new EditBookQuery()
            {
                Id = textBoxIdEdit.Text,
                Name = textBoxNameEdit.Text,
                AuthorId = textBoxAuthorEdit.Text,
                GenreId = textBoxGenreEdit.Text,
                Quantity = textBoxQuantityEdit.Text
            };

            EditBook.Edit(_context, query);
        }

        private void ClearAddTextBoxes()
        {
            textBoxAuthor.Clear();
            textBoxName.Clear();
            textBoxGenre.Clear();
            textBoxQuantity.Clear();
        }

        

        private void ClearDeleteTextBox()
        {
            textBoxIdDelete.Clear();
        }
    }
}
