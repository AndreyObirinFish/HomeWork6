using System.ComponentModel.DataAnnotations;

namespace Dtos.RoleDtos
{
    public class CreateOrUpdateRoleDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
