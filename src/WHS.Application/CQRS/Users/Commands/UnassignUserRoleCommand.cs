using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WHS.Domain.Entities.Account;
using WHS.Domain.Exceptions;

namespace WHS.Application.CQRS.Users.Commands
{
    public class UnassignUserRoleCommand : IRequest
    {
        public string UserEmail { get; set; } = default!;
        public string RoleName { get; set; } = default!;
    }

    public class UnUnassignUserRoleCommandHandler(ILogger<UnUnassignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignUserRoleCommand>
    {
        public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Unassigning user role: {@Request}", request);
            var user = await userManager.FindByEmailAsync(request.UserEmail)
                ?? throw new NotFoundException(nameof(User), request.UserEmail);

            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

            await userManager.RemoveFromRoleAsync(user, role.Name!);
        }
    }
}