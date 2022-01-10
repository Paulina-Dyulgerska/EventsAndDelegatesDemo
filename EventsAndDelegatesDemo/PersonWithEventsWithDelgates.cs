using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesDemo
{
    public class PersonWithEventsWithDelgates
    {
        private string firstName;
        private string lastName;

        public Action<PersonWithEventsWithDelgates, PersonPropertyEventArgs> OnPropertyChanged { get; set; } //delegate kym eventhandlera, kojto instanciite 
        //na tozi type shte si naprawqt, ako iskat.
        public Action<PersonWithEventsWithDelgates> OnGreeting { get; set; }
        //delegate kym eventhandlera, kojto instanciite 
        //na tozi type shte si naprawqt, ako iskat.

        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.OnPropertyChanged?
                    .Invoke(this, new PersonPropertyEventArgs
                    {
                        PropertyName = nameof(this.FirstName),
                        OldValue = this.FirstName,
                        NewValue = value
                    });
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                this.OnPropertyChanged?
                    .Invoke(this, new PersonPropertyEventArgs
                    {
                        PropertyName = nameof(this.LastName),
                        OldValue = this.LastName,
                        NewValue = value
                    });
                this.lastName = value;
            }
        }

        public string SayHello()
        {
            this.OnGreeting?.Invoke(this);
            return $"Hello! My name is: {this.FirstName} {this.LastName}";
        }
    }
}
