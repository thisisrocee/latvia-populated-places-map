using PopulatedPlacesAPI.Core.Models;
using PopulatedPlacesAPI.Data.Interfaces;
using PopulatedPlacesAPI.Services.Interfaces;

namespace PopulatedPlacesAPI.Services;

public class LocationDataProvider : ILocationDataProvider
{
    private readonly IDataDownloader _dataDownloader;
    private readonly IDataExtractor _dataExtractor;
    private readonly IFileParser _csvParser;

    public LocationDataProvider(IDataDownloader dataDownloader, IDataExtractor dataExtractor, IFileParser csvParser)
    {
        _dataDownloader = dataDownloader;
        _dataExtractor = dataExtractor;
        _csvParser = csvParser;
    }

    public List<LocationData> GetLocationDataCollection()
    {
        var directory = _dataDownloader.DownloadDataFile();

        var csvFilePath = _dataExtractor.ExtractCSVFile(directory);

        var parsedDataList = _csvParser.GetLocationData(csvFilePath);

        return parsedDataList;
    }
}