using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchadosPerdidosApi.Repository.Infra.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        public User()
        {

        }
        public User(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string NickName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        public long Phone { get; set; }

        [MaxLength(50)]
        public string Facebook { get; set; }
    }
}