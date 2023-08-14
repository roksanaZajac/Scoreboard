namespace CODING_EXERCISE
{
    public class Match
    {
        public string? homeTeam;
        public int homeTeamScore;
        public string? awayTeam;
        public int awayTeamScore;
    }

    public class Scoreboard
    {
        /// <summary>
        /// Scoreboard
        /// </summary>
        public List<Match> matches;

        /// <summary>
        /// Initializes a new instance of the Scoreboard class.
        /// </summary>
        public Scoreboard()
        {
            matches = new List<Match>();
        }

        /// <summary>
        /// Adds new match to scoreboard.
        /// </summary>
        /// <param name="homeTeam">Name of home team</param>
        /// <param name="awayTeam">Name of away team</param>
        public void StratNewMatch(string homeTeam, string awayTeam)
        {
            matches.Add(new Match() { homeTeam = homeTeam, homeTeamScore = 0, awayTeam = awayTeam, awayTeamScore = 0 });
        }

        /// <summary>
        /// Updates scores for each team.
        /// </summary>
        /// <param name="matchToUpdate">Scores to be update</param>
        public void UpdateScore(Match matchToUpdate)
        {
            var match = matches[FindMatch(matchToUpdate.homeTeam ?? "", matchToUpdate.awayTeam ?? "")];
            match.homeTeamScore = matchToUpdate.homeTeamScore;
            match.awayTeamScore = matchToUpdate.awayTeamScore;
        }

        /// <summary>
        /// Removes match of homeTeam and awayTeam from scoreboard.
        /// </summary>
        /// <param name="homeTeam">Name of home team to be removed from scoreboard</param>
        /// <param name="awayTeam">Name of away team to be removed from scoreboard</param>
        public void RemoveMatch(string homeTeam, string awayTeam)
        {
            matches.Remove(matches[FindMatch(homeTeam, awayTeam)]);
        }

        /// <summary>
        /// Gets summary of matches ordered by their total score.
        /// </summary>
        /// <returns>List of matches in given order</returns>
        public List<Match> GetSummaryOfMatches()
        {
            List<Match> summaryOfMatches = new List<Match>();
            foreach (Match match1 in matches)
                summaryOfMatches.Add(match1);

            summaryOfMatches.Sort((p1, p2) => (p1.homeTeamScore + p1.awayTeamScore).CompareTo(p2.homeTeamScore + p2.awayTeamScore));
            summaryOfMatches.Reverse();
            return summaryOfMatches;
        }

        private int FindMatch(string team1, string team2)
        {
            return matches.IndexOf(matches.FirstOrDefault(x => x.homeTeam == team1 && x.awayTeam == team2) ?? new Match());
        }
    }
}