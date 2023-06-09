using PopulatedPlacesAPI.Data.Interfaces;
using RestSharp;

namespace PopulatedPlacesAPI.Data;

public class LocationDataProvider : IDataDownloader
{
    private readonly string _downloadUrl;
    private readonly string _downloadDirectory;

    public LocationDataProvider()
    {
        _downloadUrl = "0c5e1a3b-0097-45a9-afa9-7f7262f3f623/resource/1d3cbdf2-ee7d-4743-90c7-97d38824d0bf/download/aw_csv.zip";
        _downloadDirectory = "C:\\Users\\User\\Downloads";
    }

    public string DownloadDataFile()
    {
        var directory = Path.Combine(_downloadDirectory, "aw_csv.zip");

        if (Directory.Exists(directory))
        {
            var client = new RestClient("https://data.gov.lv/dati/dataset");
            var response = client.DownloadData(new RestRequest(_downloadUrl));
            File.WriteAllBytes(directory, response);
        }

        return directory;
    }
}