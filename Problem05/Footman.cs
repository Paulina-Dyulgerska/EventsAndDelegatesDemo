namespace Problem05
{
   public class Footman : Solder
    {
        private const int killCommandsCountNeededToDie = 2;

        public Footman(string name)
            : base(name, killCommandsCountNeededToDie)
        {
        }

        public override string ToString()
        {
            return $"Footman {this.Name} is panicking!";
        }
    }
}
