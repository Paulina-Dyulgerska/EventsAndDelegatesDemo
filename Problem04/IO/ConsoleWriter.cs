using System;

namespace Problem04.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string line)
        {
            Console.WriteLine(line);
        }
    }
}
