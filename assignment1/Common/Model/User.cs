using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment1.Common.Model
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="TEXT"),Required]
        public string FirstName { get; set; }
        [Column(TypeName ="TEXT"),Required]
        public string LastName { get; set; }
        [Column(TypeName ="varchar(25)"),Required]     
        public string Email { get; set; }
    }
}