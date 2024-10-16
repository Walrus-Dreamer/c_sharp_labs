
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
                configData?.hackathonCount ?? 1000,
                configData?.teamsCount ?? 20,
                configData?.juniorsPath ?? "../../CSHARP_2024_NSU/Juniors20.csv",
                configData?.teamLeadsPath ?? "../../CSHARP_2024_NSU/TeamLeads20.csv"
            );
        }

        private class ConfigData
        {
            public int hackathonCount { get; set; } = 1000;
            public int teamsCount { get; set; } = 20;
            public string juniorsPath { get; set; } = "../../CSHARP_2024_NSU/Juniors20.csv";
            public string teamLeadsPath
            {
                get; set;
            } = "../../CSHARP_2024_NSU/TeamLeads20.csv";
        }

    }
}
