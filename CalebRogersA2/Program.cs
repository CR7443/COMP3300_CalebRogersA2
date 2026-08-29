using CalebRogersA2.Model;

namespace CalebRogersA2;

class Program
{
    private readonly Level _level;

    public Program()
    {
        _level = new Level();
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    public void Run()
    {
        FillLevelAttempts();
        DisplayLevelAttempts();
    }

    private void FillLevelAttempts()
    {
        Console.Write("Enter the level name: ");
        _level.LevelName = Console.ReadLine() ?? string.Empty;

        int attemptCount = ReadAttemptCount();

        for (int attemptNumber = 1; attemptNumber <= attemptCount; attemptNumber++)
        {
            Console.WriteLine($"Attempt {attemptNumber}:");

            Console.Write("Enter the first name: ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter the last name: ");
            string lastName = Console.ReadLine() ?? string.Empty;

            int score = ReadScore();
            decimal time = ReadTime();

            _level.AddLevel(firstName, lastName, score, time);
        }
    }

    private void DisplayLevelAttempts()
    {
        int playerNameWidth = _level.RunAttempts.Max(attempt => attempt.PlayerName.Length);
        int scoreWidth = _level.RunAttempts.Max(attempt => attempt.Score?.ToString()?.Length ?? 0);

        Console.WriteLine();
        Console.WriteLine($"{_level.LevelName} – Total Attempts: {_level.RunCount}");
        Console.WriteLine("Attempts:");

        foreach (Attempt attempt in _level.RunAttempts)
        {
            string score = attempt.Score?.ToString() ?? string.Empty;
            Console.WriteLine(
                $"{attempt.PlayerName.PadRight(playerNameWidth)} ({score.PadLeft(scoreWidth)}) : {attempt.Time}");
        }
    }

    private static int ReadAttemptCount()
    {
        while (true)
        {
            Console.Write("Enter the number of attempts to add (3-5): ");

            if (int.TryParse(Console.ReadLine(), out int attemptCount) &&
                attemptCount is >= 3 and <= 5)
            {
                return attemptCount;
            }

            Console.WriteLine("Please enter a number between 3 and 5.");
        }
    }

    private static int ReadScore()
    {
        while (true)
        {
            Console.Write("Enter the score: ");

            if (int.TryParse(Console.ReadLine(), out int score) &&
                score is >= 0 and <= 2000)
            {
                return score;
            }

            Console.WriteLine("Please enter a score between 0 and 2000.");
        }
    }

    private static decimal ReadTime()
    {
        while (true)
        {
            Console.Write("Enter the time: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal time) &&
                time is >= 0.0m and <= 59.99m)
            {
                return time;
            }

            Console.WriteLine("Please enter a time between 0.0 and 59.99 seconds.");
        }
    }
}
