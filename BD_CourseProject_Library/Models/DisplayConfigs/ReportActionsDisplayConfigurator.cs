using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Models.DisplayConfigs
{
    public static class ReportActionsDisplayConfigurator
    {
        public static List<ActionTemp> GetActions(LibraryDbContext _context)
        {
            List<ActionTemp> ListRecords = new List<ActionTemp>();

            foreach (var item in _context.ReportActions)
            {
                ListRecords.Add(new ActionTemp
                {
                    Id = item.Id,
                    Operation = item.Operation,
                    Table = item.Table,
                    DateOffered = DateOnly.FromDateTime(item.DateOffered)
                });
                
            }
            return ListRecords;
        }

        public class ActionTemp
        {
            public int Id { get; set; }

            public string Operation { get; set; } = null!;

            public string Table { get; set; } = null!;

            public DateOnly DateOffered { get; set; }
        }

    }
}