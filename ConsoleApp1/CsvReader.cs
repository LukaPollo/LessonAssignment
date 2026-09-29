using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

public static class CsvReaderService
{
    public static List<T> ReadCsv<T>(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>().ToList(); // column name discrepancy error 
            }
        }
    }
}
