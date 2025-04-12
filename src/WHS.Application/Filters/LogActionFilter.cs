using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHS.Application.CQRS.Audit.ActionLog.Commands;

namespace WHS.Application.Filters
{
    public  class LogActionFilter(IMediator mediator) : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public async override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var actionName = context.ActionDescriptor.DisplayName;
            var elapsed = _stopwatch.ElapsedMilliseconds;
            var elapsedSeconds = elapsed / 1000.0;

            var logCommand = new CreateLogActionCommand
            {
                ActionName = actionName,
                ElapsedSeconds = elapsedSeconds,
                Timestamp = DateTime.UtcNow
            };

            // send command to save
            await mediator.Send(logCommand);
            // 
            Console.WriteLine($"Action {actionName} executed in {elapsedSeconds} ms.");
            Log.Information($"Action {actionName} executed in {elapsedSeconds} seconds.");

           
        }
    }
}
