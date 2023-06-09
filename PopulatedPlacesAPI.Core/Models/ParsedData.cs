using PopulatedPlacesAPI.Core.Interfaces;

namespace PopulatedPlacesAPI.Core.Models;

public class ParsedData : IParsedData
{
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}