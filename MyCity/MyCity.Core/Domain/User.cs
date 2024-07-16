using System.ComponentModel.DataAnnotations;

namespace MyCity.Core.Domain
{
    public class User : BaseEntity
    {
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(70)]
        public string Nickname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public bool AgreeOnPersonalDataProcessing {  get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }
}
