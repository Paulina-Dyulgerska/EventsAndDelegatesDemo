using System;

namespace EventsAndDelegatesDemo
{
    public class PersonWithEvents
    {
        private string firstName;
        private string lastName;

        internal event EventHandler<PersonPropertyEventArgs> OnPropertyChanged;
        //tova stoi zad godniq red:public delegate void EventHandler<TEventArgs>(object? sender, TEventArgs e);
        //tova e prodto edin delegate, veche gotov za men, kojto priema Object i EventArgs i vryshta void!!!!
        //eventa e pravilno da vryshta void, zashtoto eventa NE VYRSHI rabota, a samo syobshtawa na tozi, 
        //kojto se e subscribnal za eventa, che neshto e stanalo. Eventa ne go tyrsim da vyne nikakyv rezultat!!!
        //toj prosto sysobshtawa na nqkoj, a moje i nikoj da ne se e zakachil da slusha za nishto i na nikoj 
        //nishto da ne syobshtata, no na eventa ne mu puka, toj si emitva, che neshto e stanalo, i ne vryshta 
        //resultat. Zatowa eventa e edin Action<object? sender, TEventArgs e>() i nishto drugo!!!!!
        //zatowa eventa e na praktika delegate, kojto e Action, zashtoto Action vryshta void, dokato 
        //Func vryshta neshto! Eventa e public, za da moje wseki da se zakacha za nego, zashtoto na classa ne 
        //mu puka koj shte se zakachi za eventa mu, na classa mu e vajno samo da emitne signal CHE EVENTA E 
        //nastypil i nishto poveche. koj kakwoto si iska da prawi ot tam natatyk. Moje i protected ili internal da e 
        //edin event, ako ima smisul za prilojenieto mi.
        public event EventHandler OnGreeting;
        //tova stoi zad godniq red: public delegate void EventHandler(object? sender, EventArgs e);

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
            this.OnGreeting?.Invoke(this, EventArgs.Empty);
            return $"Hello! My name is: {this.FirstName} {this.LastName}";
        }
    }
}
