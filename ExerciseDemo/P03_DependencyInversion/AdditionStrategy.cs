using ExerciseDemo.P03_DependencyInversion;

namespace P03_DependencyInversion
{
	public class AdditionStrategy : IStrategy
    {
        public double Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
