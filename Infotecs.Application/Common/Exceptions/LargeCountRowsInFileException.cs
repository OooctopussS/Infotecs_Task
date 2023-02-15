namespace Infotecs.Application.Common.Exceptions
{
    public class LargeCountRowsInFileException : Exception
    {
        public LargeCountRowsInFileException(string fileName) :
            base($"File '{fileName}' has more than 10000 lines.")
        { }
    }
}
