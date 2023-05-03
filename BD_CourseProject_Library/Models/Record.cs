using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BD_CourseProject_Library.Models
{
    [Table("Records")]
    public class Record
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Book.Id))]
        public virtual int BookId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime RentDateStart { get; set; }
        [Column(TypeName = "Date")]
        public DateTime RentDateEnd { get; set; }

        [ForeignKey(nameof(Client.Id))]
        public virtual int ClientId { get; set; }
    }
}
