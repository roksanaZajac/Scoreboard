using CODING_EXERCISE;
using NUnit.Framework;

namespace CODING_EXERCISE_Tests
{
    public class ScoreboardTests
    {
        private Scoreboard _scoreboard;

        [SetUp]
        public void Setup()
        {
            _scoreboard = new Scoreboard();
        }

        [Test]
        public void When_ExecuteAddNewMatch_Then_ScoreboardShouldHaveNewTeamsAdded()
        {
            //Arrange
            var expectedResult = new List<Match>()
            {
                new Match() {homeTeam = "Mexico", homeTeamScore = 0, awayTeam = "Canada", awayTeamScore = 0},
                new Match() {homeTeam = "Spain", homeTeamScore = 0, awayTeam = "Brazil", awayTeamScore = 0},
                new Match() {homeTeam = "Germany", homeTeamScore = 0, awayTeam = "France", awayTeamScore = 0},
                new Match() {homeTeam = "Uruguay", homeTeamScore = 0, awayTeam = "Italy", awayTeamScore = 0},
                new Match() {homeTeam = "Argentina", homeTeamScore = 0, awayTeam = "Australia", awayTeamScore = 0}
            };

            //Act
            _scoreboard.StratNewMatch("Mexico", "Canada");
            _scoreboard.StratNewMatch("Spain", "Brazil");
            _scoreboard.StratNewMatch("Germany", "France");
            _scoreboard.StratNewMatch("Uruguay", "Italy");
            _scoreboard.StratNewMatch("Argentina", "Australia");

            //Assert
            AssertCompareMatchesListToExpectedList(expectedResult, _scoreboard.matches);
        }

        [Test]
        public void When_ExecuteUpdateScore_Then_ScoreboardShouldBeUpdated()
        {
            //Arrange
            var expectedResult = new List<Match>()
            {
                new Match() {homeTeam = "Mexico", homeTeamScore = 0, awayTeam = "Canada", awayTeamScore = 5},
                new Match() {homeTeam = "Spain", homeTeamScore = 10, awayTeam = "Brazil", awayTeamScore = 2},
                new Match() {homeTeam = "Germany", homeTeamScore = 2, awayTeam = "France", awayTeamScore = 2},
                new Match() {homeTeam = "Uruguay", homeTeamScore = 6, awayTeam = "Italy", awayTeamScore = 6},
                new Match() {homeTeam = "Argentina", homeTeamScore = 3, awayTeam = "Australia", awayTeamScore = 1}
            };

            _scoreboard.matches = new List<Match>()
            {
                new Match() {homeTeam = "Mexico", homeTeamScore = 0, awayTeam = "Canada", awayTeamScore = 0},
                new Match() {homeTeam = "Spain", homeTeamScore = 0, awayTeam = "Brazil", awayTeamScore = 0},
                new Match() {homeTeam = "Germany", homeTeamScore = 0, awayTeam = "France", awayTeamScore = 0},
                new Match() {homeTeam = "Uruguay", homeTeamScore = 0, awayTeam = "Italy", awayTeamScore = 0},
                new Match() {homeTeam = "Argentina", homeTeamScore = 0, awayTeam = "Australia", awayTeamScore = 0}
            };

            //Act
            var newupdate = new Match() { homeTeam = "Mexico", homeTeamScore = 0, awayTeam = "Canada", awayTeamScore = 5 };
            _scoreboard.UpdateScore(newupdate);

            newupdate = new Match() { homeTeam = "Spain", homeTeamScore = 10, awayTeam = "Brazil", awayTeamScore = 2 };
            _scoreboard.UpdateScore(newupdate);

            newupdate = new Match() { homeTeam = "Germany", homeTeamScore = 2, awayTeam = "France", awayTeamScore = 2 };
            _scoreboard.UpdateScore(newupdate);

            newupdate = new Match() { homeTeam = "Uruguay", homeTeamScore = 6, awayTeam = "Italy", awayTeamScore = 6 };
            _scoreboard.UpdateScore(newupdate);

            newupdate = new Match() { homeTeam = "Argentina", homeTeamScore = 3, awayTeam = "Australia", awayTeamScore = 1 };
            _scoreboard.UpdateScore(newupdate);

            //Assert
            AssertCompareMatchesListToExpectedList(expectedResult, _scoreboard.matches);
        }

        [Test]
        public void When_ExecuteRemoveMatch_Then_MatchesShouldBeRemovedFromScoreboard()
        {
            //Arrange
            var expectedResult = new List<Match>()
            {
                new Match() {homeTeam = "Spain", homeTeamScore = 10, awayTeam = "Brazil", awayTeamScore = 2},
                new Match() {homeTeam = "Germany", homeTeamScore = 2, awayTeam = "France", awayTeamScore = 2},
                new Match() {homeTeam = "Uruguay", homeTeamScore = 6, awayTeam = "Italy", awayTeamScore = 6}
            };

            _scoreboard.matches = new List<Match>()
            {
                new Match() {homeTeam = "Mexico", homeTeamScore = 0, awayTeam = "Canada", awayTeamScore = 5},
                new Match() {homeTeam = "Spain", homeTeamScore = 10, awayTeam = "Brazil", awayTeamScore = 2},
                new Match() {homeTeam = "Germany", homeTeamScore = 2, awayTeam = "France", awayTeamScore = 2},
                new Match() {homeTeam = "Uruguay", homeTeamScore = 6, awayTeam = "Italy", awayTeamScore = 6},
                new Match() {homeTeam = "Argentina", homeTeamScore = 3, awayTeam = "Australia", awayTeamScore = 1}
            };

            //Act
            _scoreboard.RemoveMatch("Mexico", "Canada");
            _scoreboard.RemoveMatch("Argentina", "Australia");

            //Assert
            AssertCompareMatchesListToExpectedList(expectedResult, _scoreboard.matches);
        }

        [Test]
        public void When_ExecuteGetSummaryOfMatches_Then_ReturnsSortedMatchesList()
        {
            //Arrange
            var expectedResult = new List<Match>()
            {
                new Match() {homeTeam = "Uruguay", homeTeamScore = 6, awayTeam = "Italy", awayTeamScore = 6},
                new Match() {homeTeam = "Spain", homeTeamScore = 10, awayTeam = "Brazil", awayTeamScore = 2},
                new Match() {homeTeam = "Mexico", homeTeamScore = 0, awayTeam = "Canada", awayTeamScore = 5},
                new Match() {homeTeam = "Argentina", homeTeamScore = 3, awayTeam = "Australia", awayTeamScore = 1},
                new Match() {homeTeam = "Germany", homeTeamScore = 2, awayTeam = "France", awayTeamScore = 2},
            };

            _scoreboard.matches = new List<Match>()
            {
                new Match() {homeTeam = "Mexico", homeTeamScore = 0, awayTeam = "Canada", awayTeamScore = 5},
                new Match() {homeTeam = "Spain", homeTeamScore = 10, awayTeam = "Brazil", awayTeamScore = 2},
                new Match() {homeTeam = "Germany", homeTeamScore = 2, awayTeam = "France", awayTeamScore = 2},
                new Match() {homeTeam = "Uruguay", homeTeamScore = 6, awayTeam = "Italy", awayTeamScore = 6},
                new Match() {homeTeam = "Argentina", homeTeamScore = 3, awayTeam = "Australia", awayTeamScore = 1}
            };

            //Act
            List<Match> result = _scoreboard.GetSummaryOfMatches();

            //Assert
            AssertCompareMatchesListToExpectedList(expectedResult, result);
        }

        private void AssertCompareMatchesListToExpectedList(List<Match> expectedResult, List<Match> matches)
        {
            Assert.That(_scoreboard.matches.Count(), Is.EqualTo(expectedResult.Count()));

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.That(matches[i].homeTeam, Is.EqualTo(expectedResult[i].homeTeam));
                Assert.That(matches[i].homeTeamScore, Is.EqualTo(expectedResult[i].homeTeamScore));
                Assert.That(matches[i].awayTeam, Is.EqualTo(expectedResult[i].awayTeam));
                Assert.That(matches[i].awayTeamScore, Is.EqualTo(expectedResult[i].awayTeamScore));
            }
        }
    }
}