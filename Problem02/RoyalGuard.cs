namespace Problem02
{
   public class RoyalGuard : ICanBeKilled, IAmNational
    {
        public RoyalGuard(string name)
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
            System.Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
