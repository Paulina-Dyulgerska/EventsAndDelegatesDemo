using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegatesDemo
{
    public class Person
    {
        private string firstName;
        private string lastName;

        public Action<string> OnPropertyChanged { get; set; }

        public Action<string, object, object> OnPropertyChangedWithValues { get; set; }

        public Action<Person> OnGreeting { get; set; } //tozi object shte e this i shte prashtam taka info 
        //na subscriberite za towa koj raise-va eventa!!!!

        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                // ako nqkoj se e subscribenal za OnPropertyChanged (zatowa slagam ?, zashtoto moje i da nqma
                //nito edin method zakachen za OnPropertyChanged i da mi grymne zaradi null s tazi error:
                //Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
                this.OnPropertyChanged?.Invoke($"Property was changed: {nameof(this.FirstName)} -> {this.FirstName}");
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                this.OnPropertyChangedWithValues?.Invoke(nameof(this.LastName), this.lastName, value);
                this.lastName = value;
            }
        }

        public string SayHello()
        {
            this.OnGreeting?.Invoke(this);
            return $"My name is: {this.FirstName} {this.LastName}";
        }
    }
}
