using System;
using System.Collections.Generic;

namespace World
{
    public class Predator : Animal
    {
        private Random random;

        public Predator(Position position) : base(position)
        {
            this.random = new Random();
        }

        public override string Eat(ICollection<Animal> animals)
        {
            foreach (var animal in animals)
            {
                var shallAnimalBeEaten = random.Next(0, 100) <= 60;

                if (animal.GetType() == typeof(Herbivorous) && shallAnimalBeEaten)
                {
                    animal.Die();
                    return "I ate a Herbivorous!";
                }
            }

            return "I ate nothing!";
        }
    }
}
