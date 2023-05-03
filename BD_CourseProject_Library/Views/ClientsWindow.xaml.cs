using BD_CourseProject_Library.Controllers.Authors.Add;
using BD_CourseProject_Library.Controllers.Authors.Delete;
using BD_CourseProject_Library.Controllers.Authors.Edit;
using BD_CourseProject_Library.Controllers.Clients.Add;
using BD_CourseProject_Library.Controllers.Clients.Delete;
using BD_CourseProject_Library.Controllers.Clients.Edit;
using BD_CourseProject_Library.Models;
using System;
using System.Linq;
using System.Windows;

namespace BD_CourseProject_Library.Views
{
    /// <summary>
    /// Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        readonly LibraryDbContext _context;
        public ClientsWindow()
        {
            InitializeComponent();

            _context = new LibraryDbContext();

            MainList.ItemsSource = _context.Clients.ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text.Length > 3 && textBoxSurname.Text.Length > 3)
            {
                var command = new AddClientCommand { Name = textBoxName.Text, Surname = textBoxSurname.Text, PhoneNumber = textBoxPhoneNumber.Text };

                if (!AddClient.Add(_context, command))
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

            if (Int32.TryParse(textBoxIdEdit.Text, out idInt))
            {
                var command = new EditClientCommand { Id = idInt,  Name = textBoxNameEdit.Text, Surname = textBoxSurnameEdit.Text, PhoneNumber = textBoxPhoneEdit.Text };

                if (!EditClient.Edit(_context, command))
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
                var command = new DeleteClientCommand { Id = idInt };

                if (!DeleteClient.Delete(_context, command))
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
            textBoxSurname.Clear();
            textBoxPhoneNumber.Clear();
        }

        private void ClearEditTextBoxes()
        {
            textBoxIdEdit.Clear();
            textBoxNameEdit.Clear();
            textBoxSurnameEdit.Clear();
            textBoxPhoneEdit.Clear();
        }

        private void ClearDeleteTextBox()
        {
            textBoxIdDelete.Clear();
        }
    }
}
