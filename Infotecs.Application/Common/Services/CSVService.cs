using CsvHelper;
using CsvHelper.Configuration;
using Infotecs.Application.Common.Exceptions;
using Infotecs.Application.Interfaces;
using Infotecs.Domain;
using System.Globalization;

namespace Infotecs.Application.Common.Services
{
    public class CSVService : ICSVService
    {
        public IEnumerable<Value> ReadCSV(Stream file, string fileName)
        {
            List<Value> result = new();

            var reader = new StreamReader(file);

            var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter= ";"
            });

            while (csv.Read())
            {

                var row = csv.Context.Parser.Record;

                if (row != null)
                {
                    if(result.Count > 10000)
                    {
                        throw new LargeCountRowsInFileException(fileName);
                    }

                    if (row.Length == 3)
                    {
                        if (DateTime.TryParseExact(row[0], "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime)
                           && Int32.TryParse(row[1], out var seconds)
                           && float.TryParse(row[2], out var indicator))
                        {
                            Value value = new()
                            {
                                FileName = fileName,
                                DateAndTime = dateTime,
                                Seсonds = seconds,
                                Indicator = indicator
                            };

                            result.Add(value);
                        }
                    }
                }
            }
            return result;
        }
    }
}
