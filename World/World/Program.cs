using System;
using System.Collections.Generic;

namespace World
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] sizes = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            //var sizeX = sizes[0];
            //var sizeY = sizes[1];
            //var countOfAnimals = int.Parse(Console.ReadLine());

            var sizeX = 4;
            var sizeY = 5;
            var countOfAnimals = 6;

            var random = new Random();

            var animals = new List<Animal>();
            var positionGenerator = new PositionGenerator(sizeX, sizeY);

            for (int i = 0; i < countOfAnimals; i++)
            {
                var newPosition = positionGenerator.GeneratePosition();

                if (random.Next(0, 10000) % 2 == 0)
                {
                    animals.Add(new Herbivorous(newPosition));
                }
                else
                {
                    animals.Add(new Predator(newPosition));
                }
            }

            var world = new World(sizeX, sizeY, animals, positionGenerator);

            Console.WriteLine(world);

            Console.WriteLine("------------------");

            while (true)
            {
                var countHerbivorousLeft = world.MakeATurn();

                Console.WriteLine(world);

                Console.WriteLine("------------------");

                if (countHerbivorousLeft == 0)
                {
                    break;
                }
            }
        }
    }
}
