using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem04NoRefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Job> jobs = new List<Job>();
            IList<Job> jobsToRemove = new List<Job>();
            ICollection<Employee> employees = new List<Employee>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input.Split();

                switch (tokens[0])
                {
                    case "Job":
                        var jobName = tokens[1];
                        var jobHoursNeeded = int.Parse(tokens[2]);
                        var employeeName = tokens[3];
                        var employee = employees.FirstOrDefault(x => x.Name == employeeName);
                        var job = new Job(jobName, jobHoursNeeded, employee);
                        job.OnJobDone += (x,y) =>
                        {
                            jobsToRemove.Add((Job)x);
                        };

                        jobs.Add(job);
                        break;
                    case "StandardEmployee":
                        var standardEmployee = new StandardEmployee(tokens[1]);
                        employees.Add(standardEmployee);
                        break;
                    case "PartTimeEmployee":
                        var partTimeEmployee = new PartTimeEmployee(tokens[1]);
                        employees.Add(partTimeEmployee);
                        break;
                    case "Pass":
                        foreach (var currentJob in jobs)
                        {
                            currentJob.Update();
                        }
                        foreach (var currentJob in jobsToRemove)
                        {
                            jobs.Remove(currentJob);
                        }

                        break;
                    case "Status":
                        foreach (var currentJob in jobs)
                        {
                            Console.WriteLine($"Job: {currentJob.Name} Hours Remaining: {currentJob.HoursOfWorkRequired}");
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
