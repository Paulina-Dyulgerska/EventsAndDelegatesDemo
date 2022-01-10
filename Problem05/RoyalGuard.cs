namespace Problem05
{
    public class RoyalGuard : Solder
    {
        private const int killCommandsCountNeededToDie = 3;

        public RoyalGuard(string name)
            : base(name, killCommandsCountNeededToDie)
        {
        }

        public override string ToString()
        {
            return $"Royal Guard {this.Name} is defending!";
        }
    }
}
