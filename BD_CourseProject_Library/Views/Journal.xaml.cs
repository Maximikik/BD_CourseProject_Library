using BD_CourseProject_Library.Models;
using BD_CourseProject_Library.Models.DisplayConfigs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BD_CourseProject_Library.Views
{
    /// <summary>
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        LibraryDbContext _context;

        public Journal()
        {
            InitializeComponent();

            _context = new LibraryDbContext();

            ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context);
            ListRents.ItemsSource = _context.ReportRents.ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        

        private void RentsIdClick(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscRents.IsChecked)
            {
                ListRents.ItemsSource = _context.ReportRents.OrderBy( x => x.Id ).ToList();
            }
            else if (!(bool)DescOrAscRents.IsChecked)
            {
                ListRents.ItemsSource = _context.ReportRents.OrderByDescending(x => x.Id).ToList();
            }
        }

        private void ClientIdClick(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscRents.IsChecked)
            {
                ListRents.ItemsSource = _context.ReportRents.OrderBy(x => x.ClientId).ToList();
            }
            else if (!(bool)DescOrAscRents.IsChecked)
            {
                ListRents.ItemsSource = _context.ReportRents.OrderByDescending(x => x.ClientId).ToList();
            }
        }

        private void RentsBookIdClick(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscRents.IsChecked)
            {
                ListRents.ItemsSource = _context.ReportRents.OrderBy(x => x.BookId).ToList();
            }
            else if (!(bool)DescOrAscRents.IsChecked)
            {
                ListRents.ItemsSource = _context.ReportRents.OrderByDescending(x => x.BookId).ToList();
            }
        }

        private void RentsDateClick(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscRents.IsChecked)
            {
                ListRents.ItemsSource = _context.ReportRents.OrderBy(x => x.DateOffered).ToList();
            }
            else if (!(bool)DescOrAscRents.IsChecked)
            {
                ListRents.ItemsSource = _context.ReportRents.OrderByDescending(x => x.DateOffered).ToList();
            }
        }

        private void ActionIdClick(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscActions.IsChecked)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderBy( x => x.Id);
            }
            else if (!(bool)DescOrAscActions.IsChecked)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderByDescending(x => x.Id);
            }
        }



        private void RadioOperationClick(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscActions.IsChecked)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderBy(x => x.Operation);
            }
            else if (!(bool)DescOrAscActions.IsChecked)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderByDescending(x => x.Operation);
            }
        }

        private void RadioTableClick(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscActions.IsChecked)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderBy(x => x.Table);
            }
            else if (!(bool)DescOrAscActions.IsChecked)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderByDescending(x => x.Table);
            }
        }

        private void ActionsDateClick(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscActions.IsChecked)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderBy(x => x.DateOffered);
            }
            else if (!(bool)DescOrAscRents.IsChecked)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderByDescending(x => x.DateOffered);
            }
        }

        private void DescOrAscActions_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscActions.IsChecked)
            {
                if ((bool)RadioId.IsChecked)
                {
                    ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderBy(x => x.Id);
                }
                else if ((bool)RadioOperation.IsChecked)
                {
                    ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderBy(x => x.Operation);
                }
                else if ((bool)RadioTable.IsChecked)
                {
                    ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderBy(x => x.Table);
                }
                else if ((bool)RadioDate.IsChecked)
                {
                    ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderBy(x => x.DateOffered);
                }
            }
            else if (!(bool)DescOrAscActions.IsChecked)
            {
                if ((bool)RadioId.IsChecked)
                {
                    ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderByDescending(x => x.Id);
                }
                else if ((bool)RadioOperation.IsChecked)
                {
                    ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderByDescending(x => x.Operation);
                }
                else if ((bool)RadioTable.IsChecked)
                {
                    ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderByDescending(x => x.Table);
                }
                else if ((bool)RadioDate.IsChecked)
                {
                    ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).OrderByDescending(x => x.DateOffered);
                }
            }
        }

        private void DescOrAscRents_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)DescOrAscRents.IsChecked)
            {
                if ((bool)RadioIdRents.IsChecked)
                {
                    ListRents.ItemsSource = _context.ReportRents.OrderBy(x => x.Id).ToList();
                }
                else if ((bool)RadioClientId.IsChecked)
                {
                    ListRents.ItemsSource = _context.ReportRents.OrderBy(x => x.ClientId).ToList();
                }
                else if ((bool)RadioBookId.IsChecked)
                {
                    ListRents.ItemsSource = _context.ReportRents.OrderBy(x => x.BookId).ToList();
                }
                else if ((bool)RadioDateRents.IsChecked)
                {
                    ListRents.ItemsSource = _context.ReportRents.OrderBy(x => x.DateOffered).ToList();
                }
            }
            else if (!(bool)DescOrAscRents.IsChecked)
            {
                if ((bool)RadioIdRents.IsChecked)
                {
                    ListRents.ItemsSource = _context.ReportRents.OrderByDescending(x => x.Id).ToList();
                }
                else if ((bool)RadioClientId.IsChecked)
                {
                    ListRents.ItemsSource = _context.ReportRents.OrderByDescending(x => x.ClientId).ToList();
                }
                else if ((bool)RadioBookId.IsChecked)
                {
                    ListRents.ItemsSource = _context.ReportRents.OrderByDescending(x => x.BookId).ToList();
                }
                else if ((bool)RadioDateRents.IsChecked)
                {
                    ListRents.ItemsSource = _context.ReportRents.OrderByDescending(x => x.DateOffered).ToList();
                }
            }
        }

        private void ButtonApplyActions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonApplyRents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DateRentStartChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (DatePickerEndRents.Text != string.Empty)
                ListRents.ItemsSource = _context.ReportRents.Where(x => x.DateOffered <= DateTime.Parse(DatePickerEndRents.Text) && x.DateOffered >= DateTime.Parse(DatePickerStartRents.Text)).OrderBy(x => x.Id).ToList();
        }

        private void DatePickerStartRents_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DatePickerStartRents.Text != string.Empty && DatePickerEndRents.Text != string.Empty)
            {
                ListRents.ItemsSource = _context.ReportRents.Where(x => x.DateOffered < DateTime.Parse(DatePickerEndRents.Text) && x.DateOffered > DateTime.Parse(DatePickerStartRents.Text)).OrderBy(x => x.Id).ToList();
            }
            else if (DatePickerStartRents.Text == string.Empty && DatePickerEndRents.Text != string.Empty)
            {
                ListRents.ItemsSource = _context.ReportRents.Where(x => x.DateOffered < DateTime.Parse(DatePickerEndRents.Text)).OrderBy(x => x.Id).ToList();
            }
            else if (DatePickerStartRents.Text != string.Empty && DatePickerEndRents.Text == string.Empty)
            {
                ListRents.ItemsSource = _context.ReportRents.Where(x => x.DateOffered > DateTime.Parse(DatePickerStartRents.Text)).OrderBy(x => x.Id).ToList();
            }
        }

        private void DatePickerEndRents_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DatePickerStartRents.Text != string.Empty && DatePickerEndRents.Text != string.Empty)
            {
                ListRents.ItemsSource = _context.ReportRents.Where(x => x.DateOffered < DateTime.Parse(DatePickerEndRents.Text) && x.DateOffered > DateTime.Parse(DatePickerStartRents.Text)).OrderBy(x => x.Id).ToList();
            }
            else if (DatePickerStartRents.Text == string.Empty && DatePickerEndRents.Text != string.Empty)
            {
                ListRents.ItemsSource = _context.ReportRents.Where(x => x.DateOffered < DateTime.Parse(DatePickerEndRents.Text)).OrderBy(x => x.Id).ToList();
            }
            else if (DatePickerStartRents.Text != string.Empty && DatePickerEndRents.Text == string.Empty)
            {
                ListRents.ItemsSource = _context.ReportRents.Where(x => x.DateOffered > DateTime.Parse(DatePickerStartRents.Text)).OrderBy(x => x.Id).ToList();
            }
        }

        private void DatePickerStartActions_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DatePickerStartActions.Text != string.Empty && DatePickerEndActions.Text != string.Empty)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).Where(x => x.DateOffered < DateOnly.Parse(DatePickerEndActions.Text) && x.DateOffered > DateOnly.Parse(DatePickerStartActions.Text)).OrderBy(x => x.Id).ToList();
            }
            else if (DatePickerStartActions.Text == string.Empty && DatePickerEndActions.Text != string.Empty)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).Where(x => x.DateOffered < DateOnly.Parse(DatePickerEndActions.Text)).OrderBy(x => x.Id).ToList();
            }
            else if (DatePickerStartActions.Text != string.Empty && DatePickerEndActions.Text == string.Empty)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).Where(x => x.DateOffered > DateOnly.Parse(DatePickerStartActions.Text)).OrderBy(x => x.Id).ToList();
            }
        }

        private void DatePickerEndActions_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DatePickerStartActions.Text != string.Empty && DatePickerEndActions.Text != string.Empty)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).Where(x => x.DateOffered < DateOnly.Parse(DatePickerEndActions.Text) && x.DateOffered > DateOnly.Parse(DatePickerStartActions.Text)).OrderBy(x => x.Id).ToList();
            }
            else if (DatePickerStartActions.Text == string.Empty && DatePickerEndActions.Text != string.Empty)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).Where(x => x.DateOffered < DateOnly.Parse(DatePickerEndActions.Text)).OrderBy(x => x.Id).ToList();
            }
            else if (DatePickerStartActions.Text != string.Empty && DatePickerEndActions.Text == string.Empty)
            {
                ListActions.ItemsSource = ReportActionsDisplayConfigurator.GetActions(_context).Where(x => x.DateOffered > DateOnly.Parse(DatePickerStartActions.Text)).OrderBy(x => x.Id).ToList();
            }
        }
    }
}
