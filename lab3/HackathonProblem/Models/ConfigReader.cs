using System.IO;
using Newtonsoft.Json;

public class ConfigReader
{
    public static Config ReadConfig(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var configData = JsonConvert.DeserializeObject<ConfigData>(json);

        return new Config(
            configData.HackathonCount,
            configData.JuniorsPath,
            configData.TeamLeadsPath
        );
    }

    private class ConfigData
    {
        public int HackathonCount { get; set; }
        public string JuniorsPath { get; set; }
        public string TeamLeadsPath { get; set; }
    }
}
