using PopulatedPlacesAPI.Core.Models;
using PopulatedPlacesAPI.Data.Interfaces;
using PopulatedPlacesAPI.Services.Interfaces;

namespace PopulatedPlacesAPI.Services;

public class ParsingService : IParsingService
{
    private readonly IDataDownloader _dataDownloader;
    private readonly IDataExtractor _dataExtractor;
    private readonly ICsvParser _csvParser;

    public ParsingService(IDataDownloader dataDownloader, IDataExtractor dataExtractor, ICsvParser csvParser)
    {
        _dataDownloader = dataDownloader;
        _dataExtractor = dataExtractor;
        _csvParser = csvParser;
    }

    public List<ParsedData> ParseData()
    {
        var directory = _dataDownloader.DownloadDataFile();

        var csvFilePath = _dataExtractor.ExtractCSVFile(directory);

        var parsedDataList = _csvParser.ParseCSVFile(csvFilePath);

        return parsedDataList;
    }
}