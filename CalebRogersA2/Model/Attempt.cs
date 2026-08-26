namespace CalebRogersA2.Model;

public class Attempt
{
    public Attempt()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Score = 0;
        Time = 0m;
    }

    public Attempt(string? firstName, string? lastName, decimal time, int score)
    {
        if (firstName is null)
        {
            throw new ArgumentNullException(nameof(firstName));
        }

        if (lastName is null)
        {
            throw new ArgumentNullException(nameof(lastName));
        }

        if (score is < 0 or > 2000)
        {
            throw new ArgumentOutOfRangeException(nameof(score));
        }

        if (time is < 0.0m or > 59.99m)
        {
            throw new ArgumentException("Time must be between 0.0 and 59.99 seconds.", nameof(time));
        }

        FirstName = firstName;
        LastName = lastName;
        Time = time;
        Score = score;
        RunDate = DateTime.Now;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Score { get; set; }
    public decimal? Time { get; set; }
    public DateTime? RunDate { get; set; }

    public string PlayerName => FirstName + " " + LastName;
    public bool IsTimeBelowRecord => Time.HasValue && Time.Value < 27.5m;

    public override string ToString()
    {
        return $"{PlayerName} with a score of {Score} and a time of {Time} on {RunDate?.ToShortDateString()}.";
    }
}
