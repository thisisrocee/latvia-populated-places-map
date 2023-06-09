using System.IO.Compression;
using PopulatedPlacesAPI.Data.Interfaces;

namespace PopulatedPlacesAPI.Data;

public class DataExtractor : IDataExtractor
{
    public string ExtractCSVFile(string directory)
    {
        var csvFilePath = string.Empty;

        using (var archive = ZipFile.OpenRead(directory))
        {
            foreach (var entry in archive.Entries)
            {
                if (entry.Name.Equals("AW_VIETU_CENTROIDI.CSV"))
                {
                    var tempCsvPath = Path.GetTempFileName();
                    entry.ExtractToFile(tempCsvPath, true);
                    csvFilePath = tempCsvPath;
                    break;
                }
            }
        }

        return csvFilePath;
    }
}