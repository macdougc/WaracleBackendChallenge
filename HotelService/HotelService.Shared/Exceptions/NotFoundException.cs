using System.Diagnostics.CodeAnalysis;

namespace HotelService.Shared.Exceptions;

[Serializable]
public class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message,
        Exception innerException) : base(message, innerException)
    {
    }

    public static void EnsureWasFound([NotNull] object? item,
        string message)
    {
        if (item != null)
        {
            return;
        }

        throw new NotFoundException(message);
    }
}