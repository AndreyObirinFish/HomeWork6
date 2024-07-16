using System.ComponentModel.DataAnnotations;

namespace MyCity.WebHost.Models
{
    public class CreateOrUpdateRoleRequest
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
