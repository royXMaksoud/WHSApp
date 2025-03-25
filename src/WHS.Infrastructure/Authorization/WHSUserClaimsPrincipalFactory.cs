﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WHS.Domain.Entities.Account;

namespace WHS.Infrastructure.Authorization
{
    public class WHSUserClaimsPrincipalFactory(UserManager<User> userManager,
                                               RoleManager<IdentityRole> roleManager,
                                               IOptions<IdentityOptions> options)
                                             : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
    {
        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var id = await GenerateClaimsAsync(user);

            if (user.Nationality != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.Nationality, user.Nationality));
            }

            if (user.DateOfBirth != null)
            {
                id.AddClaim(new Claim(AppClaimTypes.DateOfBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }

            return new ClaimsPrincipal(id);
        }
    }
}