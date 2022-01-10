using System;

namespace ExerciseDemo.P03_DependencyInversion
{
    public class PowerStrategy : IStrategy
    {
        public double Calculate(int firstOperand, int secondOperand)
        {
            return Math.Pow(firstOperand, secondOperand);
        }
    }
}
