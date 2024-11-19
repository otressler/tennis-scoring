namespace TennisScoring;

public class Game
{
    private enum Advantage
    {
        PlayerOne,
        PlayerTwo,
        None
    }
    
    private int _playerOneScore = 0;
    private int _playerTwoScore = 0;
    
    private Advantage _advantage = Advantage.None;
    
    public void PlayerOneScores()
    {
        if (_advantage == Advantage.None &&
            _playerOneScore == 3 &&
            _playerTwoScore == 3)
        {
            _advantage = Advantage.PlayerOne;
            return;
        }

        if (_advantage == Advantage.PlayerTwo)
        {
            _advantage = Advantage.None;
            return;
        }
        _playerOneScore++;
    }
    
    public void PlayerTwoScores()
    {
        if (_advantage == Advantage.None &&
            _playerOneScore == 3 &&
            _playerTwoScore == 3)
        {
            _advantage = Advantage.PlayerTwo;
            return;
        }
        
        if (_advantage == Advantage.PlayerOne)
        {
            _advantage = Advantage.None;
            return;
        }
        _playerTwoScore++;
    }
    
    public string GetScore()
    {
        if (_advantage == Advantage.None)
        {
            return $"{GetPlayerScore(_playerOneScore)}-{GetPlayerScore(_playerTwoScore)}";
        }
        if (_advantage == Advantage.PlayerOne)
        {
            return "Ad-In";
        }
        if (_advantage == Advantage.PlayerTwo)
        {
            return "Ad-Out";
        }
        throw new NotImplementedException();
    }
    
    private static string GetPlayerScore(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "15",
            2 => "30",
            3 => "40",
            _ => throw new ArgumentOutOfRangeException(nameof(score))
        };
    }
}