namespace Problem02
{
    public class King : IAmNational
    {
        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ResponseToAttack()
        {
            System.Console.WriteLine($"King {this.Name} is under attack!");
        }
    }
}
