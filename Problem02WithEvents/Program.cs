using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem02WithEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var kingName = Console.ReadLine();
            var royalGuardsNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var footmansNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var king = new King(kingName);
            var nationals = new List<Solder>();

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

            foreach (var national in nationals)
            {
                king.OnKingAttacked += national.ResponseToAttack;
            }


            var input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Attack King")
                {
                    king.ResponseToAttack();
                }
                else
                {
                    var nameOfTheKilledPerson = input.Split(" ")[1];
                    var killedPerson = nationals.FirstOrDefault(x => x.Name == nameOfTheKilledPerson);
                    king.OnKingAttacked -= killedPerson.ResponseToAttack;
                }

                input = Console.ReadLine();
            }
        }
    }
}
