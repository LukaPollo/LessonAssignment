using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

public static class CsvReaderService
{
    public static List<T> ReadCsv<T>(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            // ??? not working as it should after tests, fix and understand
            using (CsvReader csv = new CsvReader(reader, new CsvConfiguration(new CultureInfo(""))
            {
                Delimiter = ";",
                HeaderValidated = null,
                ReadingExceptionOccurred = args => false
            }))
            {
                return csv.GetRecords<T>().ToList();
            }
            // ???
        }
    }
}
