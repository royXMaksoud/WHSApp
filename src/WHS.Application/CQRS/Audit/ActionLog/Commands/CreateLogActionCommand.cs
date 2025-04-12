using MediatR;
using Microsoft.Extensions.Logging;
using WHS.Domain.Repositories.Audit;


namespace WHS.Application.CQRS.Audit.ActionLog.Commands;

public class CreateLogActionCommand:IRequest
{
    public string ActionName { get; set; }
    public double ElapsedSeconds { get; set; }
    public DateTime Timestamp { get; set; }
}
public class CreateLogActionCommanddHandler(ILogger<CreateLogActionCommanddHandler> _logger,
                                           IActionLogRepository actionLogRepository) :
                 IRequestHandler<CreateLogActionCommand>
{
    public async Task<Unit> Handle(CreateLogActionCommand request, CancellationToken cancellationToken)
    {
        var actionLog = new Domain.Entities.Audit.ActionLog
        {
            ActionName = request.ActionName,
            ElapsedSeconds = request.ElapsedSeconds,
            Timestamp = request.Timestamp
        };

       
        await actionLogRepository.SaveActionLogAsync(actionLog);

        return Unit.Value;
    }

    Task IRequestHandler<CreateLogActionCommand>.Handle(CreateLogActionCommand request, CancellationToken cancellationToken)
    {
        return Handle(request, cancellationToken);
    }
}
