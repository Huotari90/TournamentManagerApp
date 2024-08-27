public interface IScoreService
{
    Task AddScoreAsync(string userId, int value);
    Task<List<Score>> GetUserScoresAsync(string userId);
    Task<List<Score>> GetTopScoresAsync(int count);
}