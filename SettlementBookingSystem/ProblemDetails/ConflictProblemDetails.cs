using Microsoft.AspNetCore.Http;
using SettlementBookingSystem.Application.Exceptions;
using DomainExceptions = SettlementBookingSystem.Core.Common.Exceptions;

namespace SettlementBookingSystem.ProblemDetails
{
    public class ConflictProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public ConflictProblemDetails(ConflictException ex)
        {
            Status = StatusCodes.Status409Conflict;
            Title = "Conflict";
            Detail = ex?.Message;
            Type = "https://httpstatuses.com/409";
        }

        public ConflictProblemDetails(DomainExceptions.DuplicationException duplicationException)
        {
            Status = StatusCodes.Status409Conflict;
            Title = "Conflict";
            Detail = duplicationException.Message;
            Type = "https://httpstatuses.com/409";
        }
    }
}
