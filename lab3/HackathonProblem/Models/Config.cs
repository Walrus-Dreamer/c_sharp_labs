namespace HackathonProblem.Models
{
    public class Config
    {
        public int hackathonCount { get; }
        public int teamsCount { get; }
        public string juniorsPath { get; }
        public string teamLeadsPath { get; }

        public Config(int hackathonCount, int teamsCount, string juniorsPath, string teamLeadsPath)
        {
            this.hackathonCount = hackathonCount;
            this.teamsCount = teamsCount;
            this.juniorsPath = juniorsPath;
            this.teamLeadsPath = teamLeadsPath;
        }
    }
}
