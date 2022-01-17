using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World
{
    public class World
    {
        private readonly IList<Animal> animals;
        private readonly IList<Animal>[,] worldMatrix;
        private readonly PositionGenerator positionGenerator;
        private int countHerbivorous;

        public World(int sizeX, int sizeY, IList<Animal> animals, PositionGenerator positionGenerator)
        {
            this.animals = animals;
            this.worldMatrix = new List<Animal>[sizeX, sizeY];
            this.positionGenerator = positionGenerator;
            this.GenerateWorld();
        }

        public ICollection<Animal> Animals => this.animals;

        public int MakeATurn()
        {
            this.ClearWorld();
            this.RepositionAnimals();
            this.PlaceAnimalsOnTheWorld();
            this.FeedThePredators();
            this.UpdateCountHerbivorous();

            return this.countHerbivorous;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (int row = 0; row < this.worldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.worldMatrix.GetLength(1); col++)
                {
                    if (worldMatrix[row, col].Any())
                    {
                        stringBuilder.Append($"{string.Join('|', this.worldMatrix[row, col])} ");
                    }
                    else
                    {
                        stringBuilder.Append($"- ");
                    }
                }
                stringBuilder.AppendLine();
            }

            stringBuilder.AppendLine($"Number of Herbivorous: {this.countHerbivorous}");

            return stringBuilder.ToString();
        }

        private void GenerateWorld()
        {
            for (int row = 0; row < this.worldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.worldMatrix.GetLength(1); col++)
                {
                    this.worldMatrix[row, col] = new List<Animal>();
                }
            }

            this.PlaceAnimalsOnTheWorld();
        }

        private void PlaceAnimalsOnTheWorld()
        {
            foreach (var animal in this.Animals)
            {
                if (animal.Position.X == -1)
                {
                    continue;
                }
                this.worldMatrix[animal.Position.X, animal.Position.Y].Add(animal);
            }

            this.UpdateCountHerbivorous();
        }

        private void ClearWorld()
        {
            for (int row = 0; row < this.worldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.worldMatrix.GetLength(1); col++)
                {
                    this.worldMatrix[row, col].Clear();
                }
            }
        }

        private void RepositionAnimals()
        {
            foreach (var animal in this.Animals)
            {
                var newPosition = this.positionGenerator.GeneratePosition();

                animal.ChangePosition(newPosition);
            }
        }

        private void FeedThePredators()
        {
            for (int row = 0; row < this.worldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.worldMatrix.GetLength(1); col++)
                {
                    var currentCellAnimals = this.worldMatrix[row, col];

                    if (currentCellAnimals.Count > 1)
                    {
                        for (int i = 0; i < currentCellAnimals.Count; i++)
                        {
                            System.Console.WriteLine(currentCellAnimals[i].Eat(currentCellAnimals));
                        }
                    }
                }
            }

        }

        private void UpdateCountHerbivorous()
        {
            for (int i = 0; i < this.animals.Count; i++)
            {
                if (animals[i].IsDead)
                {
                    animals.Remove(animals[i]);
                }
            }

            this.countHerbivorous = this.Animals.Where(x => x.GetType() == typeof(Herbivorous)).Count();
        }
    }
}
