using UseCase7.Models;
using UseCase7.Services;

namespace UseCase7.Tests
{
    /// <summary>
    /// Tests setup for <see cref="PlayerAnalyzer"/>
    /// </summary>
    public partial class PlayerAnalyzerTests : BaseTest
    {
        private double _actualScore;
        private List<Player> _players;

        /// <summary>
        /// Setup constructor
        /// </summary>
        public PlayerAnalyzerTests()
        {
            _players = new List<Player>();
        }

        #region Given
        private void GivenNoPlayersProvided() => _players = new List<Player>();

        protected void GivenAPlayer(int age, int experience, List<int> skills) 
            => _players.Add(new Player { Age = age, Experience = experience, Skills = skills});
        #endregion

        #region When
        private void WhenCalculatingScore() => _actualScore = PlayerAnalyzer.CalculateScore(_players);
        #endregion

        #region Then
        private void ThenScoreShouldBe(double expectedScore)
        {
            Assert.Equal(expectedScore, _actualScore);
        }
        #endregion
    }
}