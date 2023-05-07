using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BD_CourseProject_Library.Models
{
    [Table("ReportActions")]
    public class ReportAction
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Max length of operation name is 30")]
        public string Operation { get; set; } = null!;

        public virtual string Table { get; set; } = null!;

        public DateTime DateOffered { get; set; }
    }
}
