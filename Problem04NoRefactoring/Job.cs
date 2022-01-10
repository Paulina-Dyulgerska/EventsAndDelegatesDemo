using System;

namespace Problem04NoRefactoring
{
    public class Job
    {
        public event EventHandler OnJobDone;

        public Job(string name, int hoursOfWorkRequired, Employee employee)
        {
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.Employee = employee;
        }

        public Employee Employee { get;  }

        public string Name { get; }

        public int HoursOfWorkRequired { get; private set; }

        public void Update()
        {
            this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;
            if (this.HoursOfWorkRequired <= 0)
            {
                this.HoursOfWorkRequired = 0;
                Console.WriteLine($"Job {this.Name} done!");
                this.OnJobDone?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
