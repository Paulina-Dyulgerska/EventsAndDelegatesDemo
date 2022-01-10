using Problem04.Controllers;
using Problem04.IO;

namespace Problem04
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
