using System.Collections.Generic;

namespace World
{
    public class Herbivorous : Animal
    {
        public Herbivorous(Position position) : base(position)
        {
        }

        public override string Eat(ICollection<Animal> animals)
        {
            return "I ate a cabbage!";
        }
    }
}
