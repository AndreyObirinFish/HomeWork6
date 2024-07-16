using System.ComponentModel.DataAnnotations;

namespace MyCity.Core.Domain
{
    public class Role : BaseEntity
    {
        [MaxLength(60)]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
