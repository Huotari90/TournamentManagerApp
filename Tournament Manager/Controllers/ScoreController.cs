[Authorize]
public class ScoreController : Controller
{
    private readonly IScoreService _scoreService;

    public ScoreController(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    [HttpPost]
    public async Task<IActionResult> AddScore(int value)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _scoreService.AddScoreAsync(userId, value);
        return RedirectToAction("UserScores");
    }

    public async Task<IActionResult> UserScores()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var scores = await _scoreService.GetUserScoresAsync(userId);
        return View(scores);
    }

    public async Task<IActionResult> LeaderBoard()
    {
        var topScores = await _scoreService.GetTopScoresAsync(10);
        return View(topScores);
    }
}
