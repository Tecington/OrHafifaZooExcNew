namespace Zoo.Exceptions;

public class NoSaveTypeChosenException : Exception
{
    public NoSaveTypeChosenException() : base("No save type found") { }

    public NoSaveTypeChosenException(string message) : base(message) { }

    public NoSaveTypeChosenException(string message, Exception innerException) : base(message, innerException) { }
}