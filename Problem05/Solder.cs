using System;

namespace Problem05
{
    public abstract class Solder : ICanFight, IAmNational
    {
        private int countKillCommands;
        private readonly int killCommandsCountNeededToDie;

        public event EventHandler<SolderEventArgs> SolderKilled;
        public event EventHandler<SolderEventArgs> SolderRespondedOnKingAttack;

        public Solder(string name, int killCommandsCountNeededToDie)
        {
            this.Name = name;
            this.killCommandsCountNeededToDie = killCommandsCountNeededToDie;
        }

        public string Name { get; }

        public bool IsDead { get; private set; }

        public void Die()
        {
            this.countKillCommands++;
            if (this.countKillCommands >= this.killCommandsCountNeededToDie)
            {
                this.IsDead = true;
                this.SolderKilled?.Invoke(this, new SolderEventArgs(this.Name, this.ToString()));
            }
        }
        
        public void OnKingAttackedHandler(object sender, KingAttackedEventArgs args)
        {
            //Object.ReferenceEquals(args, sender);
            //Console.WriteLine(this.ToString());
            this.SolderRespondedOnKingAttack?.Invoke(this, new SolderEventArgs(this.Name, this.ToString()));
        }
    }
}
