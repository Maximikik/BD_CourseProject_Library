using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BD_CourseProject_Library.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Max length of client name is 30")]
        public string Name { get; set; } = null!;

        [MaxLength(30, ErrorMessage = "Max length of client surname is 30")]
        public string Surname { get; set; } = null!;

        [MaxLength(13, ErrorMessage = "Max length of client phone number is 13: +375-XX-XXX-XX-XX")]
        public string PhoneNumber { get; set; } = null!;
    }
}
