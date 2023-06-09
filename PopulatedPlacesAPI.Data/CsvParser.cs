using PopulatedPlacesAPI.Core.Models;
using PopulatedPlacesAPI.Data.Interfaces;

namespace PopulatedPlacesAPI.Data;

public class CsvParser : ICsvParser
{
    public List<ParsedData> ParseCSVFile(string csvFilePath)
    {
        var parsedDataList = new List<ParsedData>();

        using (var reader = new StreamReader(csvFilePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var fields = line.Split(';');

                for (int i = 0; i < fields.Length; i++)
                {
                    fields[i] = fields[i].Replace("#", "").Trim();
                }

                var parsedData = new ParsedData();
                parsedData.Name = fields[2];
                parsedData.Latitude = fields[8];
                parsedData.Longitude = fields[9];

                parsedDataList.Add(parsedData);
            }
        }

        return parsedDataList;
    }
}