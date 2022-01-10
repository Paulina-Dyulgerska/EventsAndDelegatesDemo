namespace Problem02WithEvents
{
    public class Footman : Solder
    {
        public Footman(string name) : base(name)
        {
        }

        public override void ResponseToAttack(object sender, KingAttackedEventArgs args)
        {
            System.Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
