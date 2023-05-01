using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BD_CourseProject_Library.Models
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Max length of genre name is 30")]
        public string Name { get; set; } = null!;
    }
}
