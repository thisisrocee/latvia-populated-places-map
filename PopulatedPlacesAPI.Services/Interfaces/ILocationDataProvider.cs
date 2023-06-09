using PopulatedPlacesAPI.Core.Models;

namespace PopulatedPlacesAPI.Services.Interfaces
{
    public interface ILocationDataProvider
    {
        List<LocationData> GetLocationDataCollection();
    }
}
