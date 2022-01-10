using Problem05.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem05
{
    public class Engine
    {
        private readonly ICollection<ICanFight> solders = new List<ICanFight>();
        private readonly IReader reader;
        private readonly IWriter writer;
        private King king;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var kingName = this.reader.ReadLine();
            var royalGuardsNames = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var footmansNames = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            this.king = new King(kingName);

            foreach (var name in royalGuardsNames)
            {
                var royalGuard = new RoyalGuard(name);
                solders.Add(royalGuard);
            }

            foreach (var name in footmansNames)
            {
                var footman = new Footman(name);
                solders.Add(footman);
            }

            foreach (var solder in solders)
            {
                king.KingAttacked += solder.OnKingAttackedHandler;
                solder.SolderKilled += OnSolderKilledHandler;
                solder.SolderRespondedOnKingAttack += OnSolderRespondedOnKingAttacked;
            }

            var input = this.reader.ReadLine();

            while (input != "End")
            {
                if (input == "Attack King")
                {
                    this.writer.WriteLine(king.ToString());
                    king.ResponseToAttack();
                }
                else
                {
                    var nameOfTheKilledPerson = input.Split(" ")[1];
                    var killedPerson = solders.FirstOrDefault(x => x.Name == nameOfTheKilledPerson);
                    killedPerson.Die();
                }

                input = this.reader.ReadLine();
            }
        }
        private void OnSolderKilledHandler(object sender, SolderEventArgs eventArgs)
        {
            king.KingAttacked -= ((Solder)sender).OnKingAttackedHandler;
            this.solders.Remove((Solder)sender);
        }

        private void OnSolderRespondedOnKingAttacked(object sender, SolderEventArgs eventArgs)
        {
            this.writer.WriteLine(eventArgs.SolderToStringMessage);
        }
    }
}
