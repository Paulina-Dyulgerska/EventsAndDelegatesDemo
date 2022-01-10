using Problem04.IO;
using System.Collections.Generic;
using System.Linq;

namespace Problem04.Controllers
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IList<Job> jobs = new List<Job>();
        private readonly IList<Job> jobsToRemove = new List<Job>();
        private readonly ICollection<Employee> employees = new List<Employee>();

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.ProcessCommandLines();
        }

        private void ProcessCommandLines()
        {
            var input = this.reader.Read();

            while (input != "End")
            {
                var tokens = input.Split();

                switch (tokens[0])
                {
                    case "Job":
                        this.CreateJob(tokens);
                        break;
                    case "StandardEmployee":
                        this.CreateStandardEmployee(tokens);
                        break;
                    case "PartTimeEmployee":
                        this.CreatePartTimeEmployee(tokens);
                        break;
                    case "Pass":
                        this.PassWeekExecute();
                        break;
                    case "Status":
                        this.ShowStatus();
                        break;
                    default:
                        break;
                }

                input = this.reader.Read();
            }
        }

        private void ShowStatus()
        {
            foreach (var currentJob in this.jobs)
            {
                this.writer.Write(currentJob.ToString());
            }
        }

        private void PassWeekExecute()
        {
            foreach (var currentJob in this.jobs)
            {
                currentJob.Update();
            }

            foreach (var currentJob in this.jobsToRemove)
            {
                jobs.Remove(currentJob);
            }
        }

        private void CreatePartTimeEmployee(string[] tokens)
        {
            var partTimeEmployee = new PartTimeEmployee(tokens[1]);
            this.employees.Add(partTimeEmployee);
        }

        private void CreateStandardEmployee(string[] tokens)
        {
            var standardEmployee = new StandardEmployee(tokens[1]);
            this.employees.Add(standardEmployee);
        }

        private void CreateJob(string[] tokens)
        {
            var jobName = tokens[1];
            var jobHoursNeeded = int.Parse(tokens[2]);
            var employeeName = tokens[3];
            var employee = employees.FirstOrDefault(x => x.Name == employeeName);
            var job = new Job(jobName, jobHoursNeeded, employee);
            job.OnJobDone += (x, y) =>
            {
                this.writer.Write($"Job {y.Name} done!");
                jobsToRemove.Add((Job)x);
            };

            //// can be done with this named method, not the lambda function above:
            //job.OnJobDone += OnJobDoneHandler;

            jobs.Add(job);
        }

        //// can be done with this named method, not the lambda function above:
        //private void OnJobDoneHandler(object sender, JobEventArgs args)
        //{
        //    this.writer.Write($"Job {args.Name} done!");
        //    jobsToRemove.Add((Job)sender);
        //}
    }
}
