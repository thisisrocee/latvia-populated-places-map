using PopulatedPlacesAPI.Data.Configs;
using PopulatedPlacesAPI.Data.Interfaces;
using RestSharp;

namespace PopulatedPlacesAPI.Data;

public class LocationDataDownloader : IDataDownloader
{
    private readonly DownloadConfig _downloadConfig;

    public LocationDataDownloader(DownloadConfig downloadConfig)
    {
        _downloadConfig = downloadConfig;
    }

    public string DownloadDataFile()
    {
        var directory = Path.Combine(_downloadConfig.DownloadDirectory, "aw_csv.zip");

        if (!Directory.Exists(directory))
        {
            var client = new RestClient("https://data.gov.lv/dati/dataset");
            var response = client.DownloadData(new RestRequest(_downloadConfig.DownloadUrl));
            File.WriteAllBytes(directory, response);
        }

        return directory;
    }
}