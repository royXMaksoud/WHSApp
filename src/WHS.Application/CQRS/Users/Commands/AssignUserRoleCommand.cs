﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Account;
using WHS.Domain.Exceptions;

namespace WHS.Application.CQRS.Users.Commands
{
    public class AssignUserRoleCommand : IRequest
    {
        public string UserEmail { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }

    public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
                                               UserManager<User> userManager,
                                               RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
    {
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Assigning user role :{@Request}", request);
            var user = await userManager.FindByEmailAsync(request.UserEmail) ?? throw new NotFoundException(nameof(User), request.UserEmail);

            var role = await roleManager.FindByNameAsync(request.RoleName) ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

            await userManager.AddToRoleAsync(user, role.Name);
        }
    }
}