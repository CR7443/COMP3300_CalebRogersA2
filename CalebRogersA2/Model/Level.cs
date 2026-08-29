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

    public override string ToString()
    {
        return $"Level: {LevelName} – Total Attempts: {RunCount}, Record Runs: {RecordRunCount}";
    }
}
