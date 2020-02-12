using EdufaceCms.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EdufaceCms.UI.Models
{
    public class UserRoleModel
    {
        public List<SelectListItem> Roles{ get; set; }
        public List<string> UserRoles{ get; set; }

        public UserEntity  User{ get; set; }
    }
}
