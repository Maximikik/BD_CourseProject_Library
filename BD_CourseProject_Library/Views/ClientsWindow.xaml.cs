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

            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            MainList.ItemsSource = _context.Clients.ToList();

            ComboBoxClientIdDelete.ItemsSource = _context.Clients.Select(x => x.Id).ToList();
            ComboBoxClientIdEdit.ItemsSource = _context.Clients.Select(x => x.Id).ToList();
        }


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty && textBoxSurname.Text != string.Empty && textBoxPhoneNumber.Text != string.Empty)
            {
                var command = new AddClientCommand { Name = textBoxName.Text, Surname = textBoxSurname.Text, PhoneNumber = textBoxPhoneNumber.Text };

                if (!AddClient.Add(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Clients.ToList();

                    ComboBoxClientIdDelete.ItemsSource = null;
                    ComboBoxClientIdEdit.ItemsSource = null;

                    ComboBoxClientIdDelete.ItemsSource = _context.Clients.Select(x => x.Id).ToList();
                    ComboBoxClientIdEdit.ItemsSource = _context.Clients.Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");

            ClearAddTextBoxes();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(ComboBoxClientIdEdit.Text, out idInt))
            {
                var command = new EditClientCommand { Id = idInt,  Name = textBoxNameEdit.Text, Surname = textBoxSurnameEdit.Text, PhoneNumber = textBoxPhoneEdit.Text };

                if (!EditClient.Edit(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Clients.ToList();
                }
            }
            else MessageBox.Show("Error!");

            ClearEditTextBoxes();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var idInt = -1;

            if (Int32.TryParse(ComboBoxClientIdDelete.Text, out idInt))
            {
                var command = new DeleteClientCommand { Id = idInt };

                if (!DeleteClient.Delete(_context, command))
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    MainList.ItemsSource = null;
                    MainList.ItemsSource = _context.Clients.ToList();

                    ComboBoxClientIdDelete.ItemsSource = null;
                    ComboBoxClientIdEdit.ItemsSource = null;

                    ComboBoxClientIdDelete.ItemsSource = _context.Clients.Select(x => x.Id).ToList();
                    ComboBoxClientIdEdit.ItemsSource = _context.Clients.Select(x => x.Id).ToList();
                }
            }
            else MessageBox.Show("Error!");
        }

        private void ClearAddTextBoxes()
        {
            textBoxName.Clear();
            textBoxSurname.Clear();
            textBoxPhoneNumber.Clear();
        }

        private void ClearEditTextBoxes()
        {
            textBoxNameEdit.Clear();
            textBoxSurnameEdit.Clear();
            textBoxPhoneEdit.Clear();
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
                        MainList.ItemsSource = _context.Clients.OrderBy(x => x.Id).ToList();
                    }
                    else if ((bool)RadioName.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Clients.OrderBy(x => x.Name).ToList();

                    }
                    else if ((bool)RadioSurname.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Clients.OrderBy(x => x.Surname).ToList();
                    }

                    
                }
                else if (!(bool)DescOrAsc.IsChecked)
                {
                    if ((bool)RadioId.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Clients.OrderByDescending(x => x.Id).ToList();
                    }
                    else if ((bool)RadioName.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Clients.OrderByDescending(x => x.Name).ToList();
                    }
                    else if ((bool)RadioSurname.IsChecked)
                    {
                        MainList.ItemsSource = null;
                        MainList.ItemsSource = _context.Clients.OrderByDescending(x => x.Surname).ToList();
                    }
                }
            }
        }

        private void OrderId_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Clients.OrderBy(x => x.Id).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Clients.OrderByDescending(x => x.Id).ToList();
            }
        }

        private void OrderName_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Clients.OrderBy(x => x.Name).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Clients.OrderByDescending(x => x.Name).ToList();
            }
        }

        private void OrderSurname_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Clients.OrderBy(x => x.Surname).ToList();
            }
            else if (!(bool)DescOrAsc.IsChecked)
            {
                MainList.ItemsSource = null;
                MainList.ItemsSource = _context.Clients.OrderByDescending(x => x.Surname).ToList();
            }
        }
    }
}
