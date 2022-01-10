using System;

namespace Problem05
{
    public class King : IAmNational
    {
        public event EventHandler<KingAttackedEventArgs> KingAttacked;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ResponseToAttack()
        {
            this.KingAttacked?.Invoke(this, new KingAttackedEventArgs(this.Name, this.ToString()));
        }

        public override string ToString()
        {
            return $"King {this.Name} is under attack!";
        }
    }
}
