using CalebRogersA2.Driver;
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
        Application application = new Application();
        application.Run();
    }
}
