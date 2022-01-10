namespace ExerciseDemo.P03_DependencyInversion
{
    public class DivisionStrategy : IStrategy
    {
        public double Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
