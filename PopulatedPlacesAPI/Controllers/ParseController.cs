using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace PopulatedPlacesAPI.Controllers;

[ApiController]
[Route("api")]
public class ParseController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var directory = Path.Combine("C:\\Users\\User\\Downloads", "aw_csv.zip");

        if (Directory.Exists(directory))
        {
            var client = new RestClient("https://data.gov.lv/dati/dataset");
            var response = client.DownloadData(new RestRequest("0c5e1a3b-0097-45a9-afa9-7f7262f3f623/resource/1d3cbdf2-ee7d-4743-90c7-97d38824d0bf/download/aw_csv.zip"));
            System.IO.File.WriteAllBytes(directory, response);
        }

        var csvFilePath = string.Empty;
        using (var archive = ZipFile.OpenRead(directory))
        {
            foreach (var entry in archive.Entries)
            {
                if (entry.Name.Equals("AW_VIETU_CENTROIDI.CSV"))
                {
                    var tempCsvPath = Path.GetTempFileName();
                    entry.ExtractToFile(tempCsvPath, true);
                    csvFilePath = tempCsvPath;
                    break;
                }
            }
        }

        var parsedDataList = new List<ParsedData>();


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

                var parsedData = new ParsedData();
                parsedData.Name = fields[2];
                parsedData.Latitude = fields[8];
                parsedData.Longitude = fields[9];

                parsedDataList.Add(parsedData);
            }
        }

        var westFurthestPlace = parsedDataList.OrderBy(data => data.Longitude).ToList();
        var eastFurthestPlace = parsedDataList.OrderByDescending(data => data.Longitude).ToList();
        var southFurthestPlace = parsedDataList.OrderBy(data => data.Latitude).ToList();
        var northFurthestPlace = parsedDataList.OrderByDescending(data => data.Latitude).ToList();

        var result = new List<ParsedData>
        {
            westFurthestPlace[0],
            eastFurthestPlace[1],
            southFurthestPlace[0],
            northFurthestPlace[1]
        };

        return Ok(result);
    }
}