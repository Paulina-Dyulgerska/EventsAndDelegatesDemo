namespace Problem02WithEvents
{
    public class RoyalGuard : Solder
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void ResponseToAttack(object sender, KingAttackedEventArgs args)
        {
            System.Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
