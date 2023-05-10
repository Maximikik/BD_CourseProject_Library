using BD_CourseProject_Library.Controllers.Authors.Delete;
using BD_CourseProject_Library.Controllers.Genres.Add;
using BD_CourseProject_Library.Controllers.Genres.Edit;
using BD_CourseProject_Library.Models;
using System;
using System.Linq;
using System.Windows;


namespace BD_CourseProject_Library.Views
{
    /// <summary>
    /// Interaction logic for GenresWindow.xaml
    /// </summary>
    public partial class GenresWindow : Window
    {
        readonly LibraryDbContext _context; 

        public GenresWindow()
        {
            InitializeComponent();

            _context = new LibraryDbContext();

            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            MainList.ItemsSource = _context.Genres.ToList();

            ComboBoxGenreIdEdit.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxGenreIdDelete.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty)
            {
                var command = new AddGenreCommand { Name = textBoxName.Text };

                if (!AddGenre.Add(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Genres.ToList();

                    ComboBoxGenreIdEdit.ItemsSource = null;
                    ComboBoxGenreIdDelete.ItemsSource = null; 

                    ComboBoxGenreIdEdit.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                    ComboBoxGenreIdDelete.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");

            ClearAddTextBoxes();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(ComboBoxGenreIdEdit.Text, out idInt))
            {
                var command = new EditGenreCommand { Id = idInt, Genre = textBoxNameEdit.Text };

                if (!EditGenre.Edit(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Genres.ToList();

                    ComboBoxGenreIdEdit.ItemsSource = null;
                    ComboBoxGenreIdEdit.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");

            ClearEditTextBoxes();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(ComboBoxGenreIdDelete.Text, out idInt))
            {
                var command = new DeleteAuthorCommand { Id = idInt };

                if (!DeleteAuthor.Delete(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Genres.ToList();

                    ComboBoxGenreIdEdit.ItemsSource = null;
                    ComboBoxGenreIdDelete.ItemsSource = null;

                    ComboBoxGenreIdEdit.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                    ComboBoxGenreIdDelete.ItemsSource = _context.Genres.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }

        private void ClearAddTextBoxes()
        {
            textBoxName.Clear();
        }

        private void ClearEditTextBoxes()
        {
            textBoxNameEdit.Clear();
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void DescOrAsc_Click(object sender, RoutedEventArgs e)
        {
            if (RadioId != null && RadioName != null)
            {
                if ((bool)DescOrAsc.IsChecked)
                {
                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Genres.OrderBy(x => x.Id).ToList();
                    }
                    else if ((bool)RadioName.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Genres.OrderBy(x => x.Name).ToList();

                    }
                }
                else if (!(bool)DescOrAsc.IsChecked)
                {
                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Genres.OrderByDescending(x => x.Id).ToList();
                    }
                    else if ((bool)RadioName.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Genres.OrderByDescending(x => x.Name).ToList();
                    }

                }
            }
        }

        private void OrderId_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Genres.OrderBy(x => x.Id).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Genres.OrderByDescending(x => x.Id).ToList();
            }
        }

        private void OrderName_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Genres.OrderBy(x => x.Name).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Genres.OrderByDescending(x => x.Name).ToList();
            }
        }
    }
}
