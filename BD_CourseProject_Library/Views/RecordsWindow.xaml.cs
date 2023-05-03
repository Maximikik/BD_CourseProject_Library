using BD_CourseProject_Library.Controllers.Records.Add;
using BD_CourseProject_Library.Controllers.Records.Delete;
using BD_CourseProject_Library.Controllers.Records.Edit;
using BD_CourseProject_Library.Models;
using System;
using System.Linq;
using System.Windows;

namespace BD_CourseProject_Library.Views
{
    /// <summary>
    /// Interaction logic for RecordsWindow.xaml
    /// </summary>
    public partial class RecordsWindow : Window
    {
        readonly LibraryDbContext _context;
        public RecordsWindow()
        {
            InitializeComponent();

            _context = new LibraryDbContext();

            MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var query = new AddRecordCommand()
            {
                BookName = textBoxName.Text,
                RentDateStart = textBoxRentStart.Text,
                RentDateEnd= textBoxRentEnd.Text,
                ClientId = textBoxClientId.Text
            };

            if (!AddRecord.Add(_context, query))
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

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var command = new EditRecordCommand()
            {
                Id = textBoxIdEdit.Text,
                BookId = textBoxBookIdEdit.Text,
                ClientId = textBoxClientIdEdit.Text,
                RentDateStart = textBoxRentDateStartEdit.Text,
                RentDateEnd = textBoxRentDateEndEdit.Text
            };

            if (!EditRecord.Edit(_context, command))
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

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(textBoxIdDelete.Text, out idInt))
            {
                var command = new DeleteRecordCommand { Id = idInt };

                if (!DeleteRecord.Delete(_context, command))
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
            textBoxClientId.Clear();
            textBoxRentStart.Clear();
            textBoxRentEnd.Clear();
        }

        private void ClearEditTextBoxes()
        {
            textBoxIdEdit.Clear();
            textBoxBookIdEdit.Clear();
            textBoxClientIdEdit.Clear();
            textBoxRentDateEndEdit.Clear();
            textBoxRentDateStartEdit.Clear();
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
