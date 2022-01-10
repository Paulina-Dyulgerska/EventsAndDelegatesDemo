using System;

namespace Problem04
{
    public class Job
    {
        public event EventHandler<JobEventArgs> OnJobDone;

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
                this.OnJobDone?.Invoke(this, new JobEventArgs(this.Name));
            }
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
        }
    }
}
