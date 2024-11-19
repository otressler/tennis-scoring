namespace TennisScoring.UnitTests;

public class GameTests
{
    [Fact]
    public void GetScore_WhenNobodyScored_ShouldReturnLoveLove()
    {
        // Arrange
        var game = new Game();

        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("Love-Love", score);
    }
    
    [Fact]
    public void GetScore_Player1Scored_ShouldReturn15Love()
    {
        // Arrange
        var game = new Game();
        game.PlayerOneScores();

        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("15-Love", score);
    }
    
    [Fact]
    public void GetScore_Player2Scored_ShouldReturnLove15()
    {
        // Arrange
        var game = new Game();
        game.PlayerTwoScores();
        
        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("Love-15", score);
    }
    
    [Fact]
    public void GetScore_Player1ScoredTwice_ShouldReturn30Love()
    {
        // Arrange
        var game = new Game();
        game.PlayerOneScores();
        game.PlayerOneScores();

        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("30-Love", score);
    }
    
    [Fact]
    public void GetScore_Player2ScoredTwice_ShouldReturnLove30()
    {
        // Arrange
        var game = new Game();
        game.PlayerTwoScores();
        game.PlayerTwoScores();
        
        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("Love-30", score);
    }
    
    [Fact]
    public void GetScore_Player1ScoredThrice_ShouldReturn40Love()
    {
        // Arrange
        var game = new Game();
        game.PlayerOneScores();
        game.PlayerOneScores();
        game.PlayerOneScores();

        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("40-Love", score);
    }
    
    [Fact]
    public void GetScore_Player2ScoredThrice_ShouldReturnLove40()
    {
        // Arrange
        var game = new Game();
        game.PlayerTwoScores();
        game.PlayerTwoScores();
        game.PlayerTwoScores();

        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("Love-40", score);
    }
    
    [Fact]
    public void GetScore_Player1ScoredThriceAndPlayer2ScoredTwice_ShouldReturn40_30()
    {
        // Arrange
        var game = new Game();
        game.PlayerOneScores();
        game.PlayerOneScores();
        game.PlayerOneScores();
        game.PlayerTwoScores();
        game.PlayerTwoScores();

        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("40-30", score);
    }
    
    [Fact]
    public void GetScore_Player1ScoredTwiceAndPlayer2ScoredThrice_ShouldReturn30_40()
    {
        // Arrange
        var game = new Game();
        game.PlayerOneScores();
        game.PlayerOneScores();
        game.PlayerTwoScores();
        game.PlayerTwoScores();
        game.PlayerTwoScores();

        // Act
        string score = game.GetScore();

        // Assert
        Assert.Equal("30-40", score);
    }

    [Fact]
    public void GetScore_PlayerOneTakesAdvantage_ShouldReturnAdIn()
    {
        // Arrange
        Game game = CreateTiedGame();
        game.PlayerOneScores();
        
        // Act
        string score = game.GetScore();
        
        // Assert
        Assert.Equal("Ad-In", score);
    }
    
    [Fact]
    public void GetScore_PlayerTwoTakesAdvantage_ShouldReturnAdOut()
    {
        // Arrange
        Game game = CreateTiedGame();
        game.PlayerTwoScores();
        
        // Act
        string score = game.GetScore();
        
        // Assert
        Assert.Equal("Ad-Out", score);
    }

    [Fact]
    public void GetScore_PlayerOneCancelsAdvantageOut_ShouldReturn4040()
    {
        // Arrange
        Game game = CreateTiedGame();
        game.PlayerTwoScores();
        game.PlayerOneScores();
        
        // Act
        string score = game.GetScore();
        
        // Assert
        Assert.Equal("40-40", score);
    }
    
    [Fact]
    public void GetScore_PlayerTwoCancelsAdvantageIn_ShouldReturn4040()
    {
        // Arrange
        Game game = CreateTiedGame();
        game.PlayerOneScores();
        game.PlayerTwoScores();
        
        // Act
        string score = game.GetScore();
        
        // Assert
        Assert.Equal("40-40", score);
    }
    
    private static Game CreateTiedGame()
    {
        var game = new Game();
        game.PlayerOneScores();
        game.PlayerOneScores();
        game.PlayerOneScores();
        game.PlayerTwoScores();
        game.PlayerTwoScores();
        game.PlayerTwoScores();
        return game;
    }
}