using PopulatedPlacesAPI.Core.Models;

namespace PopulatedPlacesAPI.Services.Interfaces
{
    public interface IParsingService
    {
        List<ParsedData> ParseData();
    }
}
