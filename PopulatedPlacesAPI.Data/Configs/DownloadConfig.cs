using Microsoft.Extensions.Configuration;

namespace PopulatedPlacesAPI.Data.Configs
{
    public class DownloadConfig
    {
        public DownloadConfig(IConfiguration config)
        {
            DownloadUrl = config["DownloadConfig:DownloadUrl"];
            DownloadDirectory = config["DownloadConfig:DownloadDirectory"];
        }

        public string DownloadUrl { get; set; }
        public string DownloadDirectory { get; set; }
    }
}
