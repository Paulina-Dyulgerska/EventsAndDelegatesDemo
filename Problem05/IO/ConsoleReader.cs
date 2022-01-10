using Problem05.Contracts;
using System;

namespace Problem05.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
           return Console.ReadLine();
        }
    }
}
