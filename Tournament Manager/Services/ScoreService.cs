public class ScoreService : IScoreService
{
    private readonly ApplicationDbContext _context;

    public ScoreService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddScoreAsync(string userId, int value)
    {
        var score = new Score
        {
            UserId = userId,
            Value = value,
            DateRecorded = DateTime.UtcNow
        };
        _context.Scores.Add(score);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Score>> GetUserScoresAsync(string userId)
    {
        return await _context.Scores
            .Where(s => s.UserId == userId)
            .OrderByDescending(s => s.DateRecorded)
            .ToListAsync();
    }

    public async Task<List<Score>> GetTopScoresAsync(int count)
    {
        return await _context.Scores
            .OrderByDescending(s => s.Value)
            .Take(count)
            .ToListAsync();
    }
}