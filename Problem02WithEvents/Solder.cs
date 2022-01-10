namespace Problem02WithEvents
{
    public abstract class Solder : Person
    {
        public Solder(string name) : base(name)
        {
        }

        public bool IsDead { get; private set; }
        public void Die()
        {
            this.IsDead = true;
        }

        public abstract void ResponseToAttack(object sender, KingAttackedEventArgs args);
    }
}
