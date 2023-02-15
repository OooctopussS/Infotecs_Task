using Infotecs.Domain;

namespace Infotecs.Application.Interfaces
{
    public interface ICSVService
    {
        public IEnumerable<Value> ReadCSV(Stream file, string fileName);
    }
}
