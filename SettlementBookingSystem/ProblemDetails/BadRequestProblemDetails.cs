using FluentValidation;
using Microsoft.AspNetCore.Http;
using DomainExceptions = SettlementBookingSystem.Core.Common.Exceptions;

namespace SettlementBookingSystem.ProblemDetails
{
    public class BadRequestProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BadRequestProblemDetails(ValidationException ex)
        {
            Status = StatusCodes.Status400BadRequest;
            Title = "Bad Request";
            Detail = string.Join(";", ex.Errors);
            Type = "https://httpstatuses.com/400";
        }

        public BadRequestProblemDetails(DomainExceptions.ValidationException ex)
        {
            Status = StatusCodes.Status400BadRequest;
            Title = "Bad Request";
            Detail = ex.Message;
            Type = "https://httpstatuses.com/400";
        }
    }
}
