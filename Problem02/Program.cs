using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            var kingName = Console.ReadLine();
            var royalGuardsNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var footmansNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var king = new King(kingName);
            var nationals = new List<IAmNational>();

            foreach (var name in royalGuardsNames)
            {
                var royalGuard = new RoyalGuard(name);
                nationals.Add(royalGuard);
            }

            foreach (var name in footmansNames)
            {
                var footman = new Footman(name);
                nationals.Add(footman);
            }

            var input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Attack King")
                {
                    king.ResponseToAttack();
                    foreach (var national in nationals)
                    {
                        national.ResponseToAttack();
                    }
                }
                else
                {
                    var nameOfTheKilledPerson = input.Split(" ")[1];
                    var killedPerson = nationals.FirstOrDefault(x => x.Name == nameOfTheKilledPerson);
                    nationals.Remove(killedPerson);
                }

                input = Console.ReadLine();
            }
        }
    }
}
