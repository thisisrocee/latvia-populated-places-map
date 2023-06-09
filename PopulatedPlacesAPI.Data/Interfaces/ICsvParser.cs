using PopulatedPlacesAPI.Core.Models;

namespace PopulatedPlacesAPI.Data.Interfaces
{
    public interface ICsvParser
    {
        List<ParsedData> ParseCSVFile(string csvFilePath);
    }
}
