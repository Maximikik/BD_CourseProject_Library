using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Max length of book name is 30")]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Author.Id))]
        public virtual int AuthorId { get; set; }

        [ForeignKey(nameof(Genre.Name))]
        public virtual int GenreId { get; set; }

        public int Quantity { get; set; }
    }
}
