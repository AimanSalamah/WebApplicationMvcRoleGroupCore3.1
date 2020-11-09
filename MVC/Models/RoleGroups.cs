using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Groups
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GroupRoles> GroupRoles { get; set; }
        public virtual ICollection<RoleGroupUsers> RoleGroupUsers { get; set; }
    }
    public class GroupRoles
    {
        public Guid ID { get; set; }
        public string RoleID { get; set; }
        public virtual IdentityRole Role { get; set; }
        public Guid? GroupID { get; set; }
        public virtual Groups Group { get; set; }
    }
    public class RoleGroupUsers
    {
        public Guid ID { get; set; }
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
        public Guid GroupID { get; set; }
        public virtual Groups Group { get; set; }
    }
}
