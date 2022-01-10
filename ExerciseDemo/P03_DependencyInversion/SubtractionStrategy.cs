using ExerciseDemo.P03_DependencyInversion;

namespace P03_DependencyInversion
{
	public class SubtractionStrategy : IStrategy
    {
        public double Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
