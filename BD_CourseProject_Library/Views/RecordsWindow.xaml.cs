using BD_CourseProject_Library.Controllers.Books.Add;
using BD_CourseProject_Library.Controllers.Clients.Add;
using BD_CourseProject_Library.Controllers.Genres.Add;
using BD_CourseProject_Library.Controllers.Records.Add;
using BD_CourseProject_Library.Controllers.Records.Delete;
using BD_CourseProject_Library.Controllers.Records.Edit;
using BD_CourseProject_Library.Models;
using MaterialDesignThemes.Wpf;
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

            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);

            ComboBoxBookIdEdit.ItemsSource = _context.Books.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxClientId.ItemsSource = _context.Clients.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxClientIdEdit.ItemsSource = _context.Clients.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxRecordIdDelete.ItemsSource = _context.Records.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxRecordIdEdit.ItemsSource = _context.Records.OrderBy(x => x.Id).Select(x => x.Id).ToList();
            ComboBoxBookName.ItemsSource = _context.Books.OrderBy(x => x.Name).Select(x => x.Name).ToList();

            ComboBoxAuthorId.ItemsSource = _context.Authors.Select(x => x.Name).ToList();
            ComboBoxGenreId.ItemsSource = _context.Genres.Select(x => x.Name).ToList();

            DatePickerEnd.DisplayDateStart = DateTime.Parse("01-Jan-2015");
            DatePickerEnd.DisplayDateEnd = DateTime.Parse("01-Jan-2030");

            DatePickerStart.DisplayDateStart = DateTime.Parse("01-Jan-2015");
            DatePickerStart.DisplayDateEnd = DateTime.Parse("01-Jan-2030");

            DatePickerEndsEdit.DisplayDateStart = DateTime.Parse("01-Jan-2015");
            DatePickerEndsEdit.DisplayDateEnd = DateTime.Parse("01-Jan-2030");

            DatePickerStartEdit.DisplayDateStart = DateTime.Parse("01-Jan-2015");
            DatePickerStartEdit.DisplayDateEnd = DateTime.Parse("01-Jan-2030");
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            int tempId = -1;
            DateTime tempDate = DateTime.MinValue;

            if (!Int32.TryParse(ComboBoxClientId.Text, out tempId) || DatePickerStart.Text == string.Empty || DatePickerEnd.Text == string.Empty
                || !DateTime.TryParse(DatePickerEnd.Text, out tempDate) || !DateTime.TryParse(DatePickerStart.Text, out tempDate))
            {
                MessageBox.Show("Error!");
                return;
            }



            var command = new AddRecordCommand()
            {
                BookName = ComboBoxBookName.Text,
                RentDateStart = DateTime.Parse(DatePickerStart.Text),
                RentDateEnd = DateTime.Parse(DatePickerEnd.Text),
                ClientId = ComboBoxClientId.Text
            };
            

            if (!AddRecord.Add(_context, command))
            {
                MessageBox.Show("Error!");
            }
            else
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);

                ComboBoxRecordIdDelete.ItemsSource = null;
                ComboBoxRecordIdEdit.ItemsSource = null;

                ComboBoxRecordIdDelete.ItemsSource = _context.Records.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                ComboBoxRecordIdEdit.ItemsSource = _context.Records.OrderBy(x => x.Id).Select(x => x.Id).ToList();

                DatePickerStart.Text = string.Empty;
                DatePickerEnd.Text = string.Empty;

                ComboBoxBookName.Text = string.Empty;
                ComboBoxClientId.Text = string.Empty;
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            int tempId = -1;


            if (ComboBoxClientIdEdit.Text != string.Empty &&!Int32.TryParse(ComboBoxClientIdEdit.Text, out tempId))
            {
                MessageBox.Show("Error!");
                return;
            }
            var command = new EditRecordCommand()
            {
                Id = ComboBoxRecordIdEdit.Text,
                BookId = ComboBoxBookIdEdit.Text,
                ClientId = ComboBoxClientIdEdit.Text,
            };

            DateTime tempDateStart;
            DateTime tempDateEnd;

            if (!DateTime.TryParse(DatePickerStartEdit.Text, out tempDateEnd)) command.RentDateStart = default;
            else command.RentDateStart = DateTime.Parse(DatePickerStartEdit.Text);
            if (!DateTime.TryParse(DatePickerEndsEdit.Text, out tempDateEnd)) command.RentDateEnd = default;
            else command.RentDateEnd = DateTime.Parse(DatePickerEndsEdit.Text);


            if (!EditRecord.Edit(_context, command))
            {
                MessageBox.Show("Error!");
            }
            else
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context);

                ComboBoxBookIdEdit.Text = string.Empty;
                ComboBoxBookName.Text = string.Empty;
                ComboBoxClientIdEdit.Text = string.Empty;
                DatePickerStartEdit.Text = string.Empty;
                DatePickerEndsEdit.Text = string.Empty;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(ComboBoxRecordIdDelete.Text, out idInt))
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


                    ComboBoxRecordIdDelete.ItemsSource = null;
                    ComboBoxRecordIdEdit.ItemsSource = null;

                    ComboBoxRecordIdDelete.ItemsSource = _context.Records.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                    ComboBoxRecordIdEdit.ItemsSource = _context.Records.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void RadioId_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.Id).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.Id).ToList();
            }
        }

        private void RadioBookId_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.BookId).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.BookId).ToList();
            }
        }

        private void RadioRentStart_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.RentDateStart).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.RentDateStart).ToList();
            }
        }

        private void RadioRentEnd_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.RentDateEnd).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.RentDateEnd).ToList();
            }
        }

        private void RadioClientId_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.ClientId).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.ClientId).ToList();
            }
        }

        private void DescOrAsc_Click(object sender, RoutedEventArgs e)
        {
            if (RadioId != null && RadioBookId != null && RadioClientId != null && RadioRentStart != null && RadioRentEnd != null)
            {
                if ((bool)DescOrAsc.IsChecked)
                {
                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.Id).ToList();
                    }
                    else if ((bool)RadioBookId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.BookId).ToList();

                    }
                    else if ((bool)RadioClientId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.ClientId).ToList();

                    }
                    else if ((bool)RadioRentStart.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.RentDateStart).ToList();

                    }
                    else if ((bool)RadioRentEnd.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderBy(x => x.RentDateEnd).ToList();

                    }
                }
                else if (!(bool)DescOrAsc.IsChecked)
                {

                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.Id).ToList();
                    }
                    else if ((bool)RadioBookId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.BookId).ToList();

                    }
                    else if ((bool)RadioClientId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.ClientId).ToList();

                    }
                    else if ((bool)RadioRentStart.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.RentDateStart).ToList();

                    }
                    else if ((bool)RadioRentEnd.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = RecordDisplayConfigurator.GetRecords(_context).OrderByDescending(x => x.RentDateEnd).ToList();
                    }
                }
            }
        }

        private void AcceptButtonBook_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty && textBoxQuantity.Text != string.Empty && ComboBoxAuthorId.Text != string.Empty && ComboBoxGenreId.Text != string.Empty)
            {
                int idTemp = -1;

                if (!Int32.TryParse(textBoxQuantity.Text, out idTemp))
                {
                    MessageBox.Show("Error!");
                    return;
                }

                var command = new AddBookCommand 
                {
                    Name = textBoxName.Text,
                    Author = ComboBoxAuthorId.Text,
                    Genre = ComboBoxGenreId.Text,
                    Quantity = Convert.ToInt32(textBoxQuantity.Text)
                };

                if (!AddBook.Add(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);

                    textBoxName.Clear();
                    textBoxQuantity.Clear();

                    ComboBoxBookIdEdit.ItemsSource = _context.Books.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                    ComboBoxBookName.ItemsSource = _context.Books.OrderBy(x => x.Name).Select(x => x.Name).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }

        private void AcceptButtonClient_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxClientName.Text != string.Empty && TextBoxClientSurname.Text != string.Empty && TextBoxClientPhoneNumber.Text != string.Empty)
            {
                var command = new AddClientCommand { Name = TextBoxClientName.Text, Surname = TextBoxClientSurname.Text, PhoneNumber = TextBoxClientPhoneNumber.Text };

                if (!AddClient.Add(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);

                    TextBoxClientName.Clear();
                    TextBoxClientSurname.Clear();
                    TextBoxClientPhoneNumber.Clear();

                    ComboBoxClientId.ItemsSource = _context.Clients.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                    ComboBoxClientIdEdit.ItemsSource = _context.Clients.OrderBy(x => x.Id).Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }

        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            DIalogAddBook.ShowDialog(DIalogAddBook.Content);
        }

        private void ButtonAddClient_Click(object sender, RoutedEventArgs e)
        {
            DIalogAddClient.ShowDialog(DIalogAddClient.Content);
        }
    }
}
