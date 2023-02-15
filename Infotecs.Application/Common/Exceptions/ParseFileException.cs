namespace Infotecs.Application.Common.Exceptions
{
    public class ParseFileException : Exception
    {
        public ParseFileException(string fileName) :
            base($"File '{fileName}' is empty or cannot be parsed.")
        { }
    }
}
