using BD_CourseProject_Library.Controllers.Books.Delete;
using BD_CourseProject_Library.Controllers.Books.Add;
using BD_CourseProject_Library.Controllers.Books.Edit;
using System;
using System.Linq;
using System.Windows;
using BD_CourseProject_Library.Models;
using MaterialDesignThemes.Wpf;
using BD_CourseProject_Library.Controllers.Authors.Add;
using BD_CourseProject_Library.Controllers.Genres.Add;
using System.Windows.Controls;

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

            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            MainList.ItemsSource = _context.Books.ToList();

            ComboBoxAuthorId.ItemsSource = _context.Authors.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxAuthorIdEdit.ItemsSource = _context.Authors.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxGenreId.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Name).ToList();
            ComboBoxGenreIdEdit.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Name).ToList();
            ComboBoxIdDelete.ItemsSource = _context.Books.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxIdEdit.ItemsSource = _context.Books.OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddBookCommand command;
            try
            {
                command = new AddBookCommand()
                {
                    Name = textBoxName.Text,
                    Author = ComboBoxAuthorId.Text,
                    Genre = ComboBoxGenreId.Text,
                    Quantity = Convert.ToInt32(textBoxQuantity.Text)
                };
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
                return;
            }
            

            if (!AddBook.Add(_context, command))
            {
                MessageBox.Show("Error!");
            }
            else
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Books.ToList();

                ComboBoxIdDelete.ItemsSource = null;
                ComboBoxIdEdit.ItemsSource = null;

                ComboBoxIdDelete.ItemsSource = _context.Books.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                ComboBoxIdEdit.ItemsSource = _context.Books.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            }
            ClearAddTextBoxes();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(ComboBoxIdDelete.Text, out idInt))
            {
                var command = new DeleteBookCommand { Id = idInt };

                if (!DeleteBook.Delete(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Books.ToList();

                    ComboBoxIdDelete.ItemsSource = null;
                    ComboBoxIdEdit.ItemsSource = null;

                    ComboBoxIdDelete.ItemsSource = _context.Books.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                    ComboBoxIdEdit.ItemsSource = _context.Books.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var command = new EditBookCommand()
            {
                Id = ComboBoxIdEdit.Text,
                Name = textBoxNameEdit.Text,
                AuthorId = ComboBoxAuthorIdEdit.Text,
                GenreId = ComboBoxGenreIdEdit.Text,
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
            textBoxName.Clear();
            textBoxQuantity.Clear();
        }

        private void ClearEditTextBoxes()
        {
            textBoxNameEdit.Clear();
            textBoxQuantityEdit.Clear();
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

        private void AcceptButtonAuthors_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty)
            {
                var command = new AddAuthorCommand { authorName = NameTextBox.Text };

                if (!AddAuthor.Add(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);

                    NameTextBox.Clear();

                    ComboBoxAuthorId.ItemsSource = _context.Authors.OrderBy(x => x.Id).Select(x => x.Id).ToList();

                    ComboBoxAuthorIdEdit.ItemsSource = _context.Authors.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }

        private void AcceptButtonGenre_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty)
            {
                var command = new AddGenreCommand { Name = NameTextBoxGenre.Text };

                if (!AddGenre.Add(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);

                    NameTextBoxGenre.Clear();

                    ComboBoxGenreId.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Name).ToList();

                    ComboBoxGenreIdEdit.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Name).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }

        private void ButtonAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            DIalogAddAuthor.ShowDialog(DIalogAddAuthor.Content);
        }

        private void ButtonAddGenre_Click(object sender, RoutedEventArgs e)
        {
            DIalogAddAuthor.ShowDialog(DIalogAddAuthor.Content);
        }
    }
}
