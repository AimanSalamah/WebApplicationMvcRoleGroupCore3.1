using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly ApplicationDbContext _context;
        public AppClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, ApplicationDbContext context) : base(userManager, optionsAccessor)
        { _context = context; }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);
            var roles = new List<Claim>();
            foreach (var item in _context.RoleGroupUsers.Include("Group.GroupRoles.Role"))
            {
                roles.AddRange(item.Group.GroupRoles.Select(c => new Claim(ClaimTypes.Role, c.Role.Name)));
            }
            identity.AddClaims(roles);
            return identity;
        }
    }
}
