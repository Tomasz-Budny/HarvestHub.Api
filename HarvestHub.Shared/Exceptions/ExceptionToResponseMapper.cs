using System.Net;

namespace HarvestHub.Shared.Exceptions
{
    public sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                HarvestHubException ex => new ExceptionResponse(new Error(GetErrorCode(ex), ex.Message)
                    , HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new Error("error", "An unexpected error has occured! Contact with the administrator."),
                    HttpStatusCode.InternalServerError)
            };

        private static string GetErrorCode(object exception)
        {
            var type = exception.GetType();
            return type.Name.Replace("Exception", string.Empty);
        }
    }
}
