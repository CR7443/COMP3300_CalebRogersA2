namespace CalebRogersA2.Model;

/// <summary>
/// Represents a game level and the collection of attempts made on that level.
/// </summary>
public class Level
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Level"/> class with an empty level name.
    /// </summary>
    public Level() : this(string.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Level"/> class with the specified level name.
    /// </summary>
    /// <param name="levelName">The name of the level.</param>
    public Level(string levelName)
    {
        RunAttempts = new List<Attempt>();
        LevelName = levelName;
    }

    /// <summary>
    /// Gets the collection of attempts made on the level.
    /// </summary>
    public List<Attempt> RunAttempts { get; }

    /// <summary>
    /// Gets or sets the name of the level.
    /// </summary>
    public string LevelName { get; set; }

    /// <summary>
    /// Gets the total number of attempts made on the level.
    /// </summary>
    public int RunCount => RunAttempts.Count;

    /// <summary>
    /// Gets the number of attempts completed in less than the record time.
    /// </summary>
    public int RecordRunCount => RunAttempts.Count(attempt => attempt.IsTimeBelowRecord);

    /// <summary>
    /// Adds an existing attempt to the level.
    /// </summary>
    /// <param name="attempt">The attempt to add.</param>
    public void AddLevel(Attempt attempt)
    {
        RunAttempts.Add(attempt);
    }

    /// <summary>
    /// Creates an attempt from the specified player and run data and adds it to the level.
    /// </summary>
    /// <param name="firstName">The player's first name.</param>
    /// <param name="lastName">The player's last name.</param>
    /// <param name="score">The player's score.</param>
    /// <param name="time">The player's completion time in seconds.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="firstName"/> or <paramref name="lastName"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="score"/> is outside the range from 0 through 2000.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="time"/> is outside the range from 0.0 through 59.99 seconds.
    /// </exception>
    public void AddLevel(string? firstName, string? lastName, int score, decimal time)
    {
        AddLevel(new Attempt(firstName, lastName, time, score));
    }

    /// <summary>
    /// Finds the minimum score among the attempts on the level.
    /// </summary>
    /// <returns>The minimum score, or 0 when the level has no scored attempts.</returns>
    public int GetMinimumScore()
    {
        return RunAttempts.Min(attempt => attempt.Score) ?? 0;
    }

    /// <summary>
    /// Finds the maximum score among the attempts on the level.
    /// </summary>
    /// <returns>The maximum score, or 0 when the level has no scored attempts.</returns>
    public int GetMaximumScore()
    {
        return RunAttempts.Max(attempt => attempt.Score) ?? 0;
    }

    /// <summary>
    /// Calculates the average completion time for the attempts on the level.
    /// </summary>
    /// <returns>The average completion time, or 0 when the level has no timed attempts.</returns>
    public decimal GetAverageTime()
    {
        return RunAttempts.Average(attempt => attempt.Time) ?? 0m;
    }

    /// <summary>
    /// Calculates the difference between the maximum and minimum completion times.
    /// </summary>
    /// <returns>The completion-time range, or 0 when the level has no timed attempts.</returns>
    public decimal GetTimeRange()
    {
        decimal minimumTime = RunAttempts.Min(attempt => attempt.Time) ?? 0m;
        decimal maximumTime = RunAttempts.Max(attempt => attempt.Time) ?? 0m;

        return maximumTime - minimumTime;
    }

    /// <summary>
    /// Counts the scores that fall within the specified inclusive range.
    /// </summary>
    /// <param name="low">The inclusive lower score boundary.</param>
    /// <param name="high">The inclusive upper score boundary.</param>
    /// <returns>The number of scores greater than or equal to <paramref name="low"/> and less than or equal to <paramref name="high"/>.</returns>
    public int GetScoreCountBetween(int low, int high)
    {
        return RunAttempts.Count(attempt =>
            attempt.Score.HasValue && attempt.Score.Value >= low && attempt.Score.Value <= high);
    }

    /// <summary>
    /// Returns a summary of the level, including its attempt and record-run counts.
    /// </summary>
    /// <returns>A formatted summary of the level.</returns>
    public override string ToString()
    {
        return $"Level: {LevelName} – Total Attempts: {RunCount}, Record Runs: {RecordRunCount}";
    }
}
