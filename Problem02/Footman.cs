namespace Problem02
{
   public class Footman : ICanBeKilled, IAmNational
    {
        public Footman(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void ResponseToAttack()
        {
            System.Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
