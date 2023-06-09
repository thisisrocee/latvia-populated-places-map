using PopulatedPlacesAPI.Core.Models;

namespace PopulatedPlacesAPI.Data.Interfaces
{
    public interface IFileParser
    {
        List<LocationData> GetLocationData(string csvFilePath);
    }
}
