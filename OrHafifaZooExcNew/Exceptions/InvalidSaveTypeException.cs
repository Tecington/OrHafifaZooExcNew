using OrHafifaZooExcNew.Properties;

namespace OrHafifaZooExcNew.Exceptions
{
    internal class InvalidSaveTypeException : Exception
    {
        public InvalidSaveTypeException() : base(Resources.InvalidSaveTypeExceptionMessage) { }

        public InvalidSaveTypeException(string message) : base(message) { }

        public InvalidSaveTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}