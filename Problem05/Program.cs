using Problem05.IO;

namespace Problem05
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
