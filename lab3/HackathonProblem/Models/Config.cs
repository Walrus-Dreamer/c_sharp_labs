namespace HackathonProblem.Models // TODO: Переделать с паттерном Options pattern.
{
    public class Config
    {
        public int hackathonCount { get; }
        public int teamsCount { get; }
        public string juniorsPath { get; }
        public string teamLeadsPath { get; }

        public Config(int hackathonCount, int teamsCount, string juniorsPath, string teamLeadsPath)
        {
            if (hackathonCount < 0 || teamsCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(hackathonCount) + "," + nameof(teamsCount), "must be non-negative");
            }

            juniorsPath = Path.GetFullPath(juniorsPath);
            teamLeadsPath = Path.GetFullPath(teamLeadsPath);

            if (!File.Exists(juniorsPath))
            {
                throw new ArgumentException($"File {juniorsPath} does not exist", nameof(juniorsPath));
            }
            if (!File.Exists(teamLeadsPath))
            {
                throw new ArgumentException($"File {teamLeadsPath} does not exist", nameof(teamLeadsPath));
            }

            this.hackathonCount = hackathonCount;
            this.teamsCount = teamsCount;
            this.juniorsPath = juniorsPath;
            this.teamLeadsPath = teamLeadsPath;
        }
    }
}
