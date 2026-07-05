using System;
using System.Collections.Generic;
using System.Text;

namespace HotelService.Shared.Exceptions;

[Serializable]
public class ValidationFailedException : Exception
{
    public ValidationFailedException() { }

    public ValidationFailedException(string? message) : base(message) { }

    public ValidationFailedException(string? message,
        Exception? innerException) : base(message, innerException) { }
}
