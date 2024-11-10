using Microsoft.Extensions.Options;

namespace HackathonProblem.Models
{
    public class HackathonOptions
    {
        public int hackathonCount { get; set; }
        public int teamsCount { get; set; }
        public string juniorsPath { get; set; } = String.Empty;
        public string teamLeadsPath { get; set; } = String.Empty;
    }

    public class HackathonOptionsValidation : IValidateOptions<HackathonOptions>
    {
        public ValidateOptionsResult Validate(string? name, HackathonOptions options)
        {
            if (options.hackathonCount < 0 || options.teamsCount < 0)
            {
                return ValidateOptionsResult.Fail("HackathonCount and TeamsCount must be non-negative.");
            }

            string juniorsPath = Path.GetFullPath(options.juniorsPath);
            string teamLeadsPath = Path.GetFullPath(options.teamLeadsPath);

            if (!File.Exists(juniorsPath))
            {
                return ValidateOptionsResult.Fail($"File {juniorsPath} does not exist.");
            }
            if (!File.Exists(teamLeadsPath))
            {
                return ValidateOptionsResult.Fail($"File {teamLeadsPath} does not exist.");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
