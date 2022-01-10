namespace Problem04NoRefactoring
{
    public class StandardEmployee : Employee
    {
        private const int workHoursPerWeek = 40;
        public StandardEmployee(string name) 
            : base(name, workHoursPerWeek)
        {
        }
    }
}
