namespace CalebRogersA2.Model;

public class Level
{
    public Level() : this(string.Empty)
    {
    }

    public Level(string levelName)
    {
        RunAttempts = new List<Attempt>();
        LevelName = levelName;
    }

    public List<Attempt> RunAttempts { get; }
    public string LevelName { get; set; }

    public int RunCount => RunAttempts.Count;
    public int RecordRunCount => RunAttempts.Count(attempt => attempt.IsTimeBelowRecord);

    public void AddLevel(Attempt attempt)
    {
        RunAttempts.Add(attempt);
    }

    public void AddLevel(string? firstName, string? lastName, int score, decimal time)
    {
        AddLevel(new Attempt(firstName, lastName, time, score));
    }

    public int GetMinimumScore()
    {
        return RunAttempts.Min(attempt => attempt.Score) ?? 0;
    }

    public int GetMaximumScore()
    {
        return RunAttempts.Max(attempt => attempt.Score) ?? 0;
    }

    public decimal GetAverageTime()
    {
        return RunAttempts.Average(attempt => attempt.Time) ?? 0m;
    }

    public decimal GetTimeRange()
    {
        decimal minimumTime = RunAttempts.Min(attempt => attempt.Time) ?? 0m;
        decimal maximumTime = RunAttempts.Max(attempt => attempt.Time) ?? 0m;

        return maximumTime - minimumTime;
    }

    public int GetScoreCountBetween(int low, int high)
    {
        return RunAttempts.Count(attempt =>
            attempt.Score.HasValue && attempt.Score.Value >= low && attempt.Score.Value <= high);
    }

    public override string ToString()
    {
        return $"Level: {LevelName} – Total Attempts: {RunCount}, Record Runs: {RecordRunCount}";
    }
}
