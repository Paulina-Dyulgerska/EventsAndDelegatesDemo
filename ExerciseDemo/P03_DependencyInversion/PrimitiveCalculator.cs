using ExerciseDemo.P03_DependencyInversion;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private readonly IStrategy strategy;

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public double performCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
