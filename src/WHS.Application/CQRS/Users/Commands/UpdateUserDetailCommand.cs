using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WHS.Application.UserAuth;
using WHS.Domain.Entities.Account;
using WHS.Domain.Exceptions;

namespace WHS.Application.CQRS.Users.Commands;

public class UpdateUserDetailCommand : IRequest
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}

public class UpdateUserDetailCommandHandler(ILogger<UpdateUserDetailCommand> logger,
                                     IUserContext userContext,
                                     IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailCommand>
{
    public async Task Handle(UpdateUserDetailCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        logger.LogInformation("Updating user: {UserId},with {@Request}", user!.Id, request);
        var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);
        if (dbUser == null)
        {
            throw new NotFoundException(nameof(User), user!.Id);
        }
        dbUser.Nationality = request.Nationality;
        dbUser.DateOfBirth = request.DateOfBirth;
        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}