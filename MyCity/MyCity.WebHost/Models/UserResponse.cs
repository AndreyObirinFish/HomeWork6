using System.Collections.Generic;

namespace MyCity.WebHost.Models
{
    public class UserResponse
    {
        public string Fio {  get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AgreeOnPersonalDataProcessing { get; set; }

        public List<RoleResponse> Roles { get; set; }
    }
}
