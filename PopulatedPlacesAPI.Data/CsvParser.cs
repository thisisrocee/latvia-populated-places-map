using PopulatedPlacesAPI.Core.Models;
using PopulatedPlacesAPI.Data.Interfaces;

namespace PopulatedPlacesAPI.Data;

public class CsvParser : IFileParser
{
    public List<LocationData> GetLocationData(string csvFilePath)
    {
        var locationDataList = new List<LocationData>();

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

                var locationData = new LocationData();
                locationData.Name = fields[2];
                locationData.Latitude = fields[8];
                locationData.Longitude = fields[9];

                locationDataList.Add(locationData);
            }
        }

        return locationDataList;
    }
}