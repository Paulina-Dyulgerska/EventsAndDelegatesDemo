using System;

namespace EventsAndDelegatesDemo
{
    //tozi class mi e realniq Observer, toj moje da e edin ot mnogo observeri, koito da si naprawq
    // towa e pravilniqt nachin da se handle-vat eventite - zashtoto taka wseki handle e otdelen 
    // class i e po-lesno da se prizpolzwa koda v edin po-slojen scenarii. Tozi nachin na iznasqne 
    // na handler realizira principa za "Separation of conserns". Za elementarni scenarii, kato moqt 
    // class PersonWithEvents, stawa i vytre v samiqt PersonWithEvents da si pravq handle-vaneto na 
    // eventite, no za slojni i golemi apps, trqbwa da prawq taka otdelni classove za Handlewane.
    public class ConsoleWriteLinePersonObserver : IPersonObserver
    {
        public void Handle(string property)
        {
            Console.WriteLine($"Person changed: {property}");
        }
    }
}
