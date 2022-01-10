namespace Problem04
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
