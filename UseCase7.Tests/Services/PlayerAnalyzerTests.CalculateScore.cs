using UseCase7.Services;

namespace UseCase7.Tests
{
    /// <summary>
    /// Tests for <see cref="PlayerAnalyzer.CalculateScore(List{Models.Player})"/>
    /// </summary>
    public partial class PlayerAnalyzerTests
    {
        #region Positive Test Cases
        /// <summary>
        /// Given an array with a single player object with age 25, experience 5 years, 
        /// and skills [2, 2, 2], the function should return a score of 250 (since 25*5*2 = 250). 
        /// </summary>
        [Fact]
        public void CalculateScore_NormalPlayer()
        {
            GivenAPlayer(age: 25, experience: 5, skills: new List<int> { 2, 2, 2 });
            WhenCalculatingScore();
            ThenScoreShouldBe(expectedScore: 250);
        }

        /// <summary>
        /// Given an array with a single player object with age 15, experience 3 years, 
        /// and skills [3, 3, 3], the function should return a score of 67.5 (since (15*3*3)*0.5 = 67.5).
        /// </summary>
        [Fact]
        public void CalculateScore_JuniorPlayer()
        {
            GivenAPlayer(age: 15, experience: 3, skills: new List<int> { 3, 3, 3 });
            WhenCalculatingScore();
            ThenScoreShouldBe(expectedScore: 67.5);
        }

        /// <summary>
        /// Given an array with a single player object with age 35, experience 15 years, 
        /// and skills [4, 4, 4], the function should return a score of 2520 (since (35*15*4)*1.2 = 2520). 
        /// </summary>
        [Fact]
        public void CalculateScore_SeniorPlayer()
        {
            GivenAPlayer(age: 35, experience: 15, skills: new List<int> { 4, 4, 4 });
            WhenCalculatingScore();
            ThenScoreShouldBe(expectedScore: 2520);
        }

        /// <summary>
        /// Given an array with multiple player objects, 
        /// the function should return the sum of their scores. 
        /// </summary>
        [Fact]
        public void CalculateScore_MultiplePlayers()
        {
            // JuniorPlayer = 67.5 (since (1533)*0.5 = 67.5)
            const double juniorScore = 67.5;
            GivenAPlayer(age: 15, experience: 3, skills: new List<int> { 3, 3, 3 });

            // SeniorPlayer = 2520 (since (35*15*4)*1.2 = 2520)
            const double seniorScore = 2520;
            GivenAPlayer(age: 35, experience: 15, skills: new List<int> { 4, 4, 4 });

            WhenCalculatingScore();
            ThenScoreShouldBe(expectedScore: juniorScore + seniorScore);
        }
        #endregion

        #region Negative Test Cases
        /// <summary>
        /// Given an array with a player where Skills property is null, 
        /// the function should throw an error.
        /// </summary>
        [Fact]
        public void CalculateScore_SkillsIsNull()
        {
            GivenAPlayer(age: 15, experience: 3, skills: null!);
            ThenErrorIsThrown<ArgumentNullException>(WhenCalculatingScore);
        }

        /// <summary>
        /// Given an empty array, the function should return 0 
        /// (since there are no players to contribute to the score). 
        /// </summary>
        [Fact]
        public void CalculateScore_EmptyArray()
        {
            GivenNoPlayersProvided();
            WhenCalculatingScore();
            ThenScoreShouldBe(expectedScore: 0);
        }
        #endregion
    }
}