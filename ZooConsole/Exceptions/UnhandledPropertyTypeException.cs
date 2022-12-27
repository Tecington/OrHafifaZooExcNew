namespace ZooConsole.Exceptions
{
    internal class UnhandledPropertyTypeException : Exception
    {
        public UnhandledPropertyTypeException() : base("Unhandled property type found") { }

        public UnhandledPropertyTypeException(string message) : base(message) { }

        public UnhandledPropertyTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
