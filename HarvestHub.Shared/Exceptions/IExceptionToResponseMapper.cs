﻿namespace HarvestHub.Shared.Exceptions
{
    public interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}
