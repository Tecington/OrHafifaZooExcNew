namespace Zoo.Exceptions
{
    internal class InvalidSaveTypeException : Exception
    {
        public InvalidSaveTypeException() : base("Invalid save type found") { }

        public InvalidSaveTypeException(string message) : base(message) { }

        public InvalidSaveTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}