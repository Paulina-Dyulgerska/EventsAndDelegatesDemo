using System;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var input = Console.ReadLine();

            while(input != "End")
            {
                dispatcher.Name = input.Trim();

                input = Console.ReadLine();
            }
        }
    }
}
