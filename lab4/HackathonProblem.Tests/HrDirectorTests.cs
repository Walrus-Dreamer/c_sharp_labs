using HackathonProblem.Models;
using HackathonProblem.Services;


public class HrDirectorTests
{
    [Fact]
    public void CalculateHarmonicity_ShouldReturnCorrectValue_ForValidInput()
    {
        // Arrange.
        List<Team> teams = new List<Team>(
            new Team[]
            {
                new Team(new Employee(1, "John Doe"),
                new Employee(2, "Jane Doe"))
            }
        );
        List<Wishlist> teamLeadsWishlists = new List<Wishlist>(
            new Wishlist[]
            {
                new Wishlist(1, new int[] { 1, 2 }),
                new Wishlist(2, new int[] { 1, 2 })
            }
        );
        List<Wishlist> juniorsWishlists = new List<Wishlist>(
            new Wishlist[]
            {
                new Wishlist(1, new int[] { 1, 2 }),
                new Wishlist(2, new int[] { 1, 2 })
            }
        );

        Hackathon hackathon = new Hackathon(teams, teamLeadsWishlists, juniorsWishlists);

        // Act.
        HrDirector hrDirector = new HrDirector();
        double harmonicity = hrDirector.CalculateHarmonicity(hackathon);

        // Assert.
        Assert.Equal(1.33, harmonicity, 2);
    }

    [Fact]
    public void CalculateHarmonicity_ShouldHandleEmptyPairsList()
    {
        // Arrange.
        Hackathon hackathon = new Hackathon(new List<Team>(), new List<Wishlist>(), new List<Wishlist>());

        // Act & Assert.
        HrDirector hrDirector = new HrDirector();
        Assert.Throws<System.DivideByZeroException>(() =>
            hrDirector.CalculateHarmonicity(hackathon));
    }
}
