using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Max length of author name is 30")]
        public string Name { get; set; } = null!;
    }
}
