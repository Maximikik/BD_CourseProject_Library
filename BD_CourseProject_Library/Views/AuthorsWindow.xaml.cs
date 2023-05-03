using BD_CourseProject_Library.Controllers.Authors.Add;
using BD_CourseProject_Library.Controllers.Authors.Delete;
using BD_CourseProject_Library.Controllers.Authors.Edit;
using BD_CourseProject_Library.Models;
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

            MainList.ItemsSource = _context.Authors.ToList();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(textBoxIdDelete.Text, out idInt))
            {
                var command = new DeleteAuthorCommand { Id = idInt };

                if (!DeleteAuthor.Delete(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);
                }
            }
            else MessageBox.Show("Error!");

            ClearDeleteTextBox();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(textBoxIdDelete.Text, out idInt))
            {
                var command = new EditAuthorCommand { Id = idInt, Author = textBoxNameEdit.Text };

                if(!EditAuthor.Edit(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);
                }
            }
            else MessageBox.Show("Error!");

            ClearEditTextBoxes();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text.Length > 3)
            {
                var command = new AddAuthorCommand { authorName = textBoxName.Text };

                if(!AddAuthor.Add(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);
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
            textBoxIdEdit.Clear();
            textBoxNameEdit.Clear();
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
    }
}
