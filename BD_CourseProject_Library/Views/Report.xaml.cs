using Aspose.Words;
using Aspose.Words.Tables;
using BD_CourseProject_Library.Models.DisplayConfigs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Table = Aspose.Words.Tables.Table;

namespace BD_CourseProject_Library.Views
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        LibraryDbContext _context;

        public Report()
        {
            InitializeComponent();

            _context = new LibraryDbContext();

            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            DatePickerStart.DisplayDateStart = DateTime.Parse("01-Jan-2015");
            DatePickerEnd.DisplayDateEnd = DateTime.Parse("01-Jan-2030");

            AddRowToListView(DateTime.Parse("01-Jan-2015"), DateTime.Parse("01-Jan-2030"));

            DatePickerStart.Text = "01.01.2015";
            DatePickerEnd.Text = "01.01.2030";
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(GridToPring, "Report");
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents (.docx)|*.docx";
            saveFileDialog.Title = "Save report";
            saveFileDialog.ShowDialog();


            if (saveFileDialog.FileName == string.Empty)
            {
                return;
            }
            // Create a new document.
            Document doc = new Document();

            // We can position where we want the table to be inserted and also specify any extra formatting to be
            // applied onto the table as well.
            DocumentBuilder builder = new DocumentBuilder(doc);

            // We want to rotate the page landscape as we expect a wide table.
            doc.FirstSection.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;



            // Retrieve the data from our data source which is stored as a DataTable.
            

            // Build a table in the document from the data contained in the DataTable.
            Table table = ImportToWord(builder, ReportAllRentsDisplay.GetReportList(_context, DateTime.Parse(DatePickerStart.Text), DateTime.Parse(DatePickerEnd.Text)), true);

            // We can apply a table style as a very quick way to apply formatting to the entire table.
            table.StyleIdentifier = StyleIdentifier.MediumList2Accent1;
            table.StyleOptions = TableStyleOptions.FirstRow | TableStyleOptions.RowBands | TableStyleOptions.LastColumn;

            // For our table we want to remove the heading for the image column.
            table.FirstRow.LastCell.RemoveAllChildren();

            // Save the output document.
            doc.Save(saveFileDialog.FileName);

            MessageBox.Show("File was succesfully saved", "Success");
        }

        private void DatePickerStart_DataContextChanged(object sender, RoutedEventArgs e)
        {
            if (DatePickerStart.Text != string.Empty && DatePickerEnd.Text != string.Empty)
                AddRowToListView(DateTime.Parse(DatePickerStart.Text), DateTime.Parse(DatePickerEnd.Text));
            else if (DatePickerStart.Text != string.Empty && DatePickerEnd.Text == string.Empty)
                AddRowToListView(DateTime.Parse(DatePickerStart.Text), DateTime.Now);
            else if (DatePickerStart.Text == string.Empty && DatePickerEnd.Text != string.Empty)
                AddRowToListView(DateTime.Parse("01-Jan-2015"), DateTime.Parse(DatePickerEnd.Text));
        }

        private void DatePickerEnd_DataContextChanged(object sender, RoutedEventArgs e)
        {
            if (DatePickerStart.Text != string.Empty && DatePickerEnd.Text != string.Empty)
                AddRowToListView( DateTime.Parse(DatePickerStart.Text), DateTime.Parse(DatePickerEnd.Text));
            else if (DatePickerStart.Text != string.Empty && DatePickerEnd.Text == string.Empty)
                AddRowToListView(DateTime.Parse(DatePickerStart.Text), DateTime.Now);
            else if (DatePickerStart.Text == string.Empty && DatePickerEnd.Text != string.Empty)
                AddRowToListView(DateTime.Parse("01-Jan-2015"), DateTime.Parse(DatePickerEnd.Text));
        }

        private void AddRowToListView(DateTime timeStart, DateTime timeEnd)
        {
            HashSet<int> ClientsNumber = new HashSet<int>();
            MainList.Items.Clear();
            foreach (var item in ReportAllRentsDisplay.GetReportList(_context, timeStart, timeEnd).OrderBy(x => x.rentStart))
            {
                MainList.Items.Add(new ReportAllRentsToListView
                {
                    Id = item.Id,
                    book = item.book,
                    author = item.author,
                    genre = item.genre,
                    clientName = item.clientName,
                    clientSurname = item.clientSurname,
                    clientPhoneNumber = item.clientPhoneNumber,
                    rentStart = DateOnly.FromDateTime(item.rentStart),
                    rentEnd = DateOnly.FromDateTime(item.rentEnd)
                });
                ClientsNumber.Add(item.Id);
            }
            TextBoxWereRented.Text = $"Books were rented: {MainList.Items.Count}";
            TextBoxClients.Text = $"Clients: {ClientsNumber.Count}";
            TBMadeIn.Text = $"Report have been done in:  {DateTime.Now}";
        }

        private Table ImportToWord(DocumentBuilder builder, List<ReportAllRents> dataTable, bool importColumnHeadings)
        {
            Table table = builder.StartTable();

            

            // Check if the names of the columns from the data source are to be included in a header row.
            if (importColumnHeadings)
            {
                // Store the original values of these properties before changing them.
                bool boldValue = builder.Font.Bold;
                ParagraphAlignment paragraphAlignmentValue = builder.ParagraphFormat.Alignment;

                // Format the heading row with the appropriate properties.
                builder.Font.Bold = true;
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;

                // Create a new row and insert the name of each column into the first row of the table.

                builder.InsertCell();
                builder.Writeln("Book");

                builder.InsertCell();
                builder.Writeln("Author");

                builder.InsertCell();
                builder.Writeln("Genre");

                builder.InsertCell();
                builder.Writeln("Client id");

                builder.InsertCell();
                builder.Writeln("Client name");

                builder.InsertCell();
                builder.Writeln("Client surname");

                builder.InsertCell();
                builder.Writeln("Client phone number");

                builder.InsertCell();
                builder.Writeln("Rent started");

                builder.InsertCell();
                builder.Writeln("Rent ends");

                builder.EndRow();

                // Restore the original formatting.
                builder.Font.Bold = boldValue;
                builder.ParagraphFormat.Alignment = paragraphAlignmentValue;
            }


            foreach (var item in dataTable)
            {
                builder.InsertCell();
                builder.Write(item.book);
                builder.InsertCell();
                builder.Write(item.author);
                builder.InsertCell();
                builder.Write(item.genre);
                builder.InsertCell();
                builder.Write(item.Id.ToString());
                builder.InsertCell();
                builder.Write(item.clientName);
                builder.InsertCell();
                builder.Write(item.clientSurname);
                builder.InsertCell();
                builder.Write(item.clientPhoneNumber);
                builder.InsertCell();
                builder.Write(item.rentStart.ToString("MMMM d, yyyy"));
                builder.InsertCell();
                builder.Write(item.rentEnd.ToString("MMMM d, yyyy"));
                builder.EndRow();
            }

            builder.InsertCell();
            builder.Write($"Library perfomance report of {TBMadeIn.Text}");

            builder.InsertCell();
            builder.Write($"{TextBoxWereRented.Text}");

            builder.InsertCell();
            builder.Write($"{TextBoxClients.Text}");

            // We have finished inserting all the data from the DataTable, we can end the table.
            builder.EndTable();

            return table;
        }
    }
}
