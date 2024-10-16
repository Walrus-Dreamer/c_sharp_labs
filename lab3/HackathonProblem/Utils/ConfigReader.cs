
using HackathonProblem.Models;
using Newtonsoft.Json;

namespace HackathonProblem.Utils
{
    public class ConfigReader
    {
        public static Config ReadConfig(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var configData = JsonConvert.DeserializeObject<ConfigData>(json);

            return new Config(
                configData?.HackathonCount ?? 1000,
                configData?.JuniorsPath ?? "../../CSHARP_2024_NSU/Juniors20.csv",
                configData?.TeamLeadsPath ?? "../../CSHARP_2024_NSU/TeamLeads20.csv"
            );
        }

        private class ConfigData
        {
            public int HackathonCount { get; set; } = 1000;
            public string JuniorsPath { get; set; } = "../../CSHARP_2024_NSU/Juniors20.csv";
            public string TeamLeadsPath
            {
                get; set;
            } = "../../CSHARP_2024_NSU/TeamLeads20.csv";
        }

    }
}
