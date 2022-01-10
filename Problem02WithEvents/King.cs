using System;

namespace Problem02WithEvents
{
    public class King : Person
    {
        public event EventHandler<KingAttackedEventArgs> OnKingAttacked;
        public King(string name) : base(name)
        {
        }

        public void ResponseToAttack()
        {
            System.Console.WriteLine($"King {this.Name} is under attack!");
            this.OnKingAttacked?.Invoke(this, new KingAttackedEventArgs());
        }
    }
}
