using BD_CourseProject_Library.Controllers.Authors.Add;
using BD_CourseProject_Library.Controllers.Authors.Delete;
using BD_CourseProject_Library.Controllers.Authors.Edit;
using System;
using System.Linq;
using System.Windows;

namespace BD_CourseProject_Library.Views
{
    /// <summary>
    /// Interaction logic for AuthorsWindow.xaml
    /// </summary>
    public partial class AuthorsWindow : Window
    {
        readonly LibraryDbContext _context;
        public AuthorsWindow()
        {
            InitializeComponent();

            _context = new LibraryDbContext();

            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            MainList.ItemsSource = _context.Authors.ToList();
            ComboBoxAuthorId.ItemsSource = _context.Authors.Select(x => x.Id).ToList();
            ComboBoxAuthorIdDelete.ItemsSource = _context.Authors.Select(x => x.Id).ToList();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(ComboBoxAuthorIdDelete.Text, out idInt))
            {
                var command = new DeleteAuthorCommand { Id = idInt };

                if (!DeleteAuthor.Delete(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Authors.ToList();

                    ComboBoxAuthorId.ItemsSource = null;
                    ComboBoxAuthorId.ItemsSource = _context.Authors.Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(ComboBoxAuthorId.Text, out idInt))
            {
                var command = new EditAuthorCommand { Id = idInt, Author = textBoxNameEdit.Text };

                if(!EditAuthor.Edit(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Authors.ToList();
                }
            }
            else MessageBox.Show("Error!");

            ClearEditTextBoxes();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty)
            {
                var command = new AddAuthorCommand { authorName = textBoxName.Text };

                if(!AddAuthor.Add(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Authors.ToList();

                    ComboBoxAuthorId.ItemsSource = null;
                    ComboBoxAuthorId.ItemsSource = _context.Authors.Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");

            ClearAddTextBoxes();
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

        private void DescOrAscClick(object sender, RoutedEventArgs e)
        {
            if (RadioId != null && RadioName != null)
            {
                if ((bool)DescOrAsc.IsChecked)
                {
                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Authors.OrderBy(x => x.Id).ToList();
                    }
                    else if ((bool)RadioName.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Authors.OrderBy(x => x.Name).ToList();

                    }
                }
                else if (!(bool)DescOrAsc.IsChecked)
                {
                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Authors.OrderByDescending(x => x.Id).ToList();
                    }
                    else if ((bool)RadioName.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Authors.OrderByDescending(x => x.Name).ToList();
                    }

                }
            }
        }

        private void OrderId_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Authors.OrderBy(x => x.Id).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Authors.OrderByDescending(x => x.Id).ToList();
            }
        }

        private void OrderName_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Authors.OrderBy(x => x.Name).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Authors.OrderByDescending(x => x.Name).ToList();
            }
        }
    }
}
