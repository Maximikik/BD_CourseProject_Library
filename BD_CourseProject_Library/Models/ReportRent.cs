using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BD_CourseProject_Library.Models
{
    [Table("ReportRents")]
    public class ReportRent
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Client.Id))]
        public virtual int ClientId { get; set; }

        [ForeignKey(nameof(Book.Id))]
        public virtual int BookId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOffered { get; set; }
    }
}
