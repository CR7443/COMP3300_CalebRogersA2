namespace CalebRogersA2.Model;

public class Level
{
    public Level()
    {
        RunAttempts = new List<Attempt>();
        LevelName = string.Empty;
    }

    public List<Attempt> RunAttempts { get; }
    public string LevelName { get; set; }

    public int RunCount => RunAttempts.Count;
    public int RecordRunCount => RunAttempts.Count(attempt => attempt.IsTimeBelowRecord);
}
