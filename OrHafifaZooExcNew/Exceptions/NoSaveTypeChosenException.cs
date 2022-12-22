using OrHafifaZooExcNew.Properties;

namespace OrHafifaZooExcNew.Exceptions;

public class NoSaveTypeChosenException : Exception
{
    public NoSaveTypeChosenException() : base(Resources.NoSaveTypeChosenExceptionMessage) { }

    public NoSaveTypeChosenException(string message) : base(message) { }

    public NoSaveTypeChosenException(string message, Exception innerException) : base(message, innerException) { }
}