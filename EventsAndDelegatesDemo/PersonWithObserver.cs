using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesDemo
{
   public class PersonWithObserver
    {
        private string firstName;
        private string lastName;

        private readonly ICollection<IPersonObserver> personObservers = new List<IPersonObserver>();

        //// Event are not needed any more!!!!
        //public event EventHandler<PersonPropertyEventArgs> OnPropertyChanged;
        //public event EventHandler OnGreeting;

        public string FirstName
        {
            get => this.firstName;
            set
            {
                //// Event are not needed any more!!!!
                //this.OnPropertyChanged?
                //    .Invoke(this, new PersonPropertyEventArgs
                //    {
                //        PropertyName = nameof(this.FirstName),
                //        OldValue = this.FirstName,
                //        NewValue = value
                //    });

                this.NotifyObservers(this.FirstName);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                //// Event are not needed any more!!!!
                //this.OnPropertyChanged?
                //    .Invoke(this, new PersonPropertyEventArgs
                //    {
                //        PropertyName = nameof(this.LastName),
                //        OldValue = this.LastName,
                //        NewValue = value
                //    });

                this.NotifyObservers(this.LastName);
                
                this.lastName = value;
            }
        }

        public string SayHello()
        {
            //// Event are not needed any more!!!!
            //this.OnGreeting?.Invoke(this, EventArgs.Empty);

            this.NotifyObservers("The person instance will now say 'Hello' from an Observer");
            
            return $"Hello! My name is: {this.FirstName} {this.LastName}";
        }

        public void AddObserver(IPersonObserver observer)
        {
            this.personObservers.Add(observer);
        }

        private void NotifyObservers(string property)
        {
            foreach (var observer in this.personObservers)
            {
                observer.Handle(property);
            }
        }
    }
}
