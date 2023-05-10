using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BD_CourseProject_Library.Models.DisplayConfigs
{
    public static class ReportAllRentsDisplay
    {
        public static List<ReportAllRents> GetReportList(LibraryDbContext _context, DateTime rentStart, DateTime rentEnd)
        {
            //return _context.Database.SqlQuery<ReportAllRents>($"call dbo.Books_TAKEN_IN_PERIOD {rentStart} {rentEnd})").ToList();
            //.FromSqlRaw($"EXECUTE dbo.Books_TAKEN_IN_PERIOD {rentStart} {rentEnd}")
            //ToList();

            List<ReportAllRents> reports = new List<ReportAllRents>();

            var cmd = _context.Database.GetDbConnection().CreateCommand();
                

            cmd.CommandText = "Books_TAKEN_IN_PERIOD";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            var date1 = cmd.CreateParameter();
            var date2 = cmd.CreateParameter();
            date1.ParameterName = "@DATE1";
            date2.ParameterName = "@DATE2";
            date1.Value = rentStart;
            date2.Value = rentEnd;

            cmd.Parameters.Add(date1);
            cmd.Parameters.Add(date2);

            _context.Database.OpenConnection();
            using (var result = cmd.ExecuteReader())
            {
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        reports.Add(
                        new ReportAllRents
                        {
                            book = (string)result.GetValue(0),
                            author = (string)result.GetValue(1),
                            genre = (string)result.GetValue(2),
                            Id = Convert.ToInt32(result.GetValue(3)),
                            clientName = (string)result.GetValue(4),
                            clientSurname = (string)result.GetValue(5),
                            clientPhoneNumber = (string)result.GetValue(6),
                            rentStart = (DateTime)result.GetValue(7),
                            rentEnd = (DateTime)result.GetValue(8)
                        });
                    }


                }
            }
            return reports;
        }
    }

    public class ReportAllRents
    {
        public string book { get; set; } = null!;
        public string author { get; set; } = null!;
        public string genre { get; set; } = null!;
        public int Id { get; set; }
        public string clientName { get; set; } = null!;
        public string clientSurname { get; set; } = null!;
        public string clientPhoneNumber { get; set; } = null!;
        public DateTime rentStart { get; set; }
        public DateTime rentEnd { get; set; }
    }

    public class ReportAllRentsToListView
    {
        public string book { get; set; } = null!;
        public string author { get; set; } = null!;
        public string genre { get; set; } = null!;
        public int Id { get; set; }
        public string clientName { get; set; } = null!;
        public string clientSurname { get; set; } = null!;
        public string clientPhoneNumber { get; set; } = null!;
        public DateOnly rentStart { get; set; }
        public DateOnly rentEnd { get; set; }
    }
}
