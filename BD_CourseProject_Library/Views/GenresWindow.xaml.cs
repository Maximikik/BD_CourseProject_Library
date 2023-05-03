using BD_CourseProject_Library.Controllers.Authors.Add;
using BD_CourseProject_Library.Controllers.Authors.Delete;
using BD_CourseProject_Library.Controllers.Authors.Edit;
using BD_CourseProject_Library.Controllers.Genres.Add;
using BD_CourseProject_Library.Controllers.Genres.Edit;
using BD_CourseProject_Library.Models;
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

            MainList.ItemsSource = _context.Genres.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text.Length > 3)
            {
                var command = new AddGenreCommand { Name = textBoxName.Text };

                if (!AddGenre.Add(_context, command))
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

            ClearAddTextBoxes();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(textBoxIdDelete.Text, out idInt))
            {
                var command = new EditGenreCommand { Id = idInt, Genre = textBoxNameEdit.Text };

                if (!EditGenre.Edit(_context, command))
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

            ClearEditTextBoxes();
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
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);
                }
            }
            else MessageBox.Show("Error!");

            ClearDeleteTextBox();
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
