using BD_CourseProject_Library.Controllers.Books.Delete;
using BD_CourseProject_Library.Controllers.Books.Add;
using BD_CourseProject_Library.Controllers.Books.Edit;
using System;
using System.Linq;
using System.Windows;
using BD_CourseProject_Library.Models;

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
            //var books = _context.Books.OrderBy(x => x.Name).ToList();
            MainList.ItemsSource = _context.Books.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var query = new AddBookCommand()
            {
                Name = textBoxName.Text,
                Author = textBoxAuthor.Text,
                Genre = textBoxGenre.Text,
                Quantity = Convert.ToInt32(textBoxQuantity.Text)
            };

            if (!AddBook.Add(_context, query))
            {
                MessageBox.Show("Error!");
            }
            else
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);
            }
            ClearAddTextBoxes();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(textBoxIdDelete.Text, out idInt))
            {
                var command = new DeleteBookCommand { Id = idInt };

                if (!DeleteBook.Delete(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);
                }
            }
            else MessageBox.Show("Error!");

            ClearDeleteTextBox();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            var command = new EditBookCommand()
            {
                Id = textBoxIdEdit.Text,
                Name = textBoxNameEdit.Text,
                AuthorId = textBoxAuthorEdit.Text,
                GenreId = textBoxGenreEdit.Text,
                Quantity = textBoxQuantityEdit.Text
            };

            if(!EditBook.Edit(_context, command))
            {
                MessageBox.Show("Error!");
            }
            else
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);
            }

            ClearEditTextBoxes();
        }

        private void ClearAddTextBoxes()
        {
            textBoxAuthor.Clear();
            textBoxName.Clear();
            textBoxGenre.Clear();
            textBoxQuantity.Clear();
        }

        private void ClearEditTextBoxes()
        {
            textBoxIdEdit.Clear();
            textBoxNameEdit.Clear();
            textBoxAuthorEdit.Clear();
            textBoxGenreEdit.Clear();
            textBoxQuantityEdit.Clear();
        }

        private void ClearDeleteTextBox()
        {
            textBoxIdDelete.Clear();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void OrderId_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderBy(x => x.Id).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderByDescending(x => x.Id).ToList();
            }
        }

        private void OrderName_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderBy(x => x.Name).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderByDescending(x => x.Name).ToList();
            }
        }

        private void OrderAuthorId_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderBy(x => x.AuthorId).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderByDescending(x => x.AuthorId).ToList();
            }
        }

        private void OrderGenreId_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderBy(x => x.GenreId).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderByDescending(x => x.GenreId).ToList();
            }
        }

        private void OrderQuantity_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderBy(x => x.Quantity).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.OrderByDescending(x => x.Quantity).ToList();
            }
        }

        private void DescOrAscChecked(object sender, RoutedEventArgs e)
        {
            if (RadioId != null && RadioName != null && RadioAuthorId != null && RadioGenreId != null && RadioQuantity != null)
            {
                if ((bool)DescOrAsc.IsChecked)
                {
                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderBy(x => x.Id).ToList();
                    }
                    else if ((bool)RadioName.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderBy(x => x.Name).ToList();
                    }
                    else if ((bool)RadioAuthorId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderBy(x => x.AuthorId).ToList();
                    }
                    else if ((bool)RadioGenreId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderBy(x => x.GenreId).ToList();
                    }
                    else if ((bool)RadioQuantity.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderBy(x => x.Quantity).ToList();
                    }
                }
                else if (!(bool)DescOrAsc.IsChecked)
                {
                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderByDescending(x => x.Id).ToList();
                    }
                    else if ((bool)RadioName.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderByDescending(x => x.Name).ToList();
                    }
                    else if ((bool)RadioAuthorId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderByDescending(x => x.AuthorId).ToList();
                    }
                    else if ((bool)RadioGenreId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderByDescending(x => x.GenreId).ToList();
                    }
                    else if ((bool)RadioQuantity.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Books.OrderByDescending(x => x.Quantity).ToList();
                    }
                }
            }
        }
    }
}
