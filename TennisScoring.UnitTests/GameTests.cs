namespace TennisScoring.UnitTests;

public class GameTests
{
    [Fact]
    public void GetScore_WhenNobodyScored_ShouldReturnXXX()
    {
        // Arrange
        var game = new Game();

        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("XXX", score);
    }
}