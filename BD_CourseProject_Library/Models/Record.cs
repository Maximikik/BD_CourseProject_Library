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

        public DateTime RentDateStart { get; set; }

        public DateTime RentDateEnd { get; set; }

        [ForeignKey(nameof(Client.Id))]
        public virtual int ClientId { get; set; }
    }
}
