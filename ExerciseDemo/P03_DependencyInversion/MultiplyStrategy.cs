namespace ExerciseDemo.P03_DependencyInversion
{
    public class MultiplyStrategy : IStrategy
    {
        public double Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
