namespace HackathonProblem.Models
{
    public class Config
    {
        public int HackathonCount { get; }
        public string JuniorsPath { get; }
        public string TeamLeadsPath { get; }

        public Config(int hackathonCount, string juniorsPath, string teamLeadsPath)
        {
            HackathonCount = hackathonCount;
            JuniorsPath = juniorsPath;
            TeamLeadsPath = teamLeadsPath;
        }
    }

}
