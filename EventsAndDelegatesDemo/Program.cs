using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsAndDelegatesDemo
{
    public delegate int AddDelegate(int a, int b);
    public delegate void WorkPerformedHandler(int hours, string workType); //this is the delegate type, this is a Class in the final end!!! Towa e
                                                                           //shablonyt, kojto opisva referencii kym kakyv type methodi shte pazi posle instanciq ot type WorkPerformedHandler!!!!!!!!!!!!!

    class Program
    {
        private delegate int AddDelegate2(int a, int b);
        static void Main(string[] args)
        {
            var person = new PersonWithObserver
            {
                FirstName = "Ivan",
                LastName = "Dyulgerski"
            };

            // kazwam na person, che toj ima Observer, kojto e ConsoleWriteLinePersonObserver i tozi
            // observer shte slusha za twoite eventi. Ideqta e EventHandlinga da e extractnat po 
            // classove, za da e po-razpredelen kato otgovornosti koda mi i da ne chupq principa za
            // Signle Responsibility!!!!
            person.AddObserver(new ConsoleWriteLinePersonObserver());

            //raisevam event s towa:
            person.LastName = "Stavrev";
            
            //raisevam event s towa:
            Console.WriteLine(person.SayHello());

            //EventsRealisedWithDelegatesExamples3();
            //EventsRealisedWithDelegatesExamples2();
            //EventsRealisedWithDelegatesExamples();
            //DelegatesExamples();
        }

        static void OnPropertyChangedNew(object person, PersonPropertyEventArgs data)
        {
            var p = (PersonWithEvents)person;
            Console.WriteLine($"Second Method Property will be changed: {data.PropertyName } from {data.OldValue} to {data.NewValue}");
            Console.WriteLine($"Second Method I am this object: {p.FirstName}");
        }

        static void EventsRealisedWithDelegatesExamples3()
        {
            var person = new PersonWithEvents();
            person.LastName = "Stavrev";

            person.OnPropertyChanged += (p, data) =>
            {
                Console.WriteLine($"Property will be changed: {data.PropertyName } from {data.OldValue} to {data.NewValue}");
                Console.WriteLine($"I am this object: {p}");
            };
            person.OnPropertyChanged += OnPropertyChangedNew;
            person.FirstName = "Paulina";
            person.FirstName = "Ivan";

            person.OnGreeting += (p, data) =>
            {
                Console.WriteLine("The person instance will now say 'Hello'");
            };
            Console.WriteLine(person.SayHello());
        }
        static void EventsRealisedWithDelegatesExamples2()
        {
            var person = new PersonWithEventsWithDelgates();
            person.LastName = "Stavrev";

            person.OnPropertyChanged += (p, data) =>
            {
                Console.WriteLine($"Property will be changed: {data.PropertyName } from {data.OldValue} to {data.NewValue}");
                Console.WriteLine($"I am this object: {p}");
            };
            person.FirstName = "Paulina";
            person.FirstName = "Ivan";
            //Property was changed: FirstName->Paulina
            //Property was changed: FirstName->Ivan

            //person.OnPropertyChanged += msg =>
            //{
            //    throw new Exception("You cannot edit that property");
            //};
            //person.FirstName = "Paulina";
            //Property was changed: FirstName->Paulina
            //Unhandled exception. System.Exception: You cannot edit that property

            person.OnGreeting += (p) =>
            {
                Console.WriteLine("The person instance will now say 'Hello'");
            };
            Console.WriteLine(person.SayHello());
            ////The person instance will now say 'Hello'
            ////My name is: Ivan

            //person.LastName = "Dyulgerski";
            // Property LastName was changed from Stavrev to Dyulgerski
        }

        static void EventsRealisedWithDelegatesExamples()
        {
            var person = new Person();
            person.LastName = "Stavrev";

            person.OnPropertyChanged += msg =>
            {
                Console.WriteLine(msg);
            };
            person.FirstName = "Paulina";
            person.FirstName = "Ivan";
            //Property was changed: FirstName->Paulina
            //Property was changed: FirstName->Ivan

            //person.OnPropertyChanged += msg =>
            //{
            //    throw new Exception("You cannot edit that property");
            //};
            //person.FirstName = "Paulina";
            //Property was changed: FirstName->Paulina
            //Unhandled exception. System.Exception: You cannot edit that property

            person.OnGreeting += (p) =>
            {
                Console.WriteLine("The person instance will now say 'Hello'");
            };
            Console.WriteLine(person.SayHello());
            //The person instance will now say 'Hello'
            //My name is: Ivan

            person.OnPropertyChangedWithValues += (property, oldValue, newValue) =>
            {
                Console.WriteLine($"Property {property} was changed from {oldValue} to {newValue}");
            };
            person.LastName = "Dyulgerski";
            // Property LastName was changed from Stavrev to Dyulgerski
        }

        static void DelegatesExamples()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 13, 15, 16, 22 };

            var newList = list.Where(IsEven);
            Console.WriteLine("From Linq with normal method:");
            Console.WriteLine(string.Join(", ", newList));
            Console.WriteLine("----------------------");

            Func<int, bool> predicateFunc = IsEven;
            var newList2 = list.Where(predicateFunc);
            Console.WriteLine("From Linq with delegate:");
            Console.WriteLine(string.Join(", ", newList2));
            Console.WriteLine("----------------------");

            Action<string> newAction = x => Console.WriteLine(x);
            Action<string> newActionWithSimpleSyntax = Console.WriteLine;
            Console.WriteLine("From actions with strings:");
            newAction("I am newAction");
            newActionWithSimpleSyntax("I am newActionWithSimpleSyntax");
            Console.WriteLine("----------------------");

            Action<string> actionFunc = Print;
            actionFunc += PrintWithLines;
            Console.WriteLine("From multicasted delegate:");
            actionFunc("Hi from me, I am a multicasting delegate");
            Console.WriteLine("----------------------");

            // those two Lambdas are different parts of the memory (in the Heap memory holded), they are not the same functions!!!!!
            Action<string> firstLambda = x => { };
            Action<string> secondLambda = x => { };


            WorkPerformedHandler dele = new WorkPerformedHandler(WorkPerformed); // this is the instance of the delegate type, this is the delegate object!!!!!
                                                                                 //this object pazi referenciq kym methoda WorkPerformed!!!!!!

            WorkPerformedHandler dele2 = WorkPerformed;


            AddDelegate addDelegateExample = Sum;
            addDelegateExample += (x, y) => x * y;
            var addDelegateResult = addDelegateExample(5, 6);
            Console
                .WriteLine($"Add delegate example result with value returned type of the methods in the delegate invocation list: {addDelegateResult}");
            // tozi vryshta samo 30!!!!
            // predi towa se izpylnqwa i 11, no 11 ne se vryshta, zashtoto vtoriqt method prezapisva 11 i slaga 30 na negovo mqsto.

            addDelegateExample += delegate (int x, int y)
            {
                return x - y;
            };
            Console.WriteLine(addDelegateExample(5, 6));
            //-1
            //gorntoto e ==  na towa:
            addDelegateExample += (x, y) => x + y;

            Console.WriteLine(addDelegateExample.Method.Name); //<Main>b__1_5
            Console.WriteLine(addDelegateExample.Target); //EventsAndDelegatesDemo.Program+<>c - tova e koj class vika methoda.

            AddDelegate addDelegateExample3 = Sum;

            Console.WriteLine("I am static mehtod:" + addDelegateExample3.Target); //null, zashtoto Sum e static method i si nqma instanciq!!!!!
                                                                                   // Target e instanciqta, vyrhu koqto se izvikwa methoda!!!

            addDelegateExample?.Invoke(5, 6); //tova e == na dolnoto, zashtoto Invoke znachi "Izvikaj funkciqta"
            addDelegateExample(5, 6);

            Console.WriteLine("Hi from DynamicInvoke():");
            addDelegateExample.DynamicInvoke(5, 6);
            //Hi from DynamicInvoke():
            //Hi from Sum! This value wiil be overriden: 11
            //addDelegateExample.DynamicInvoke(5, 6, 4); // runtime error Unhandled exception. System.Reflection.TargetParameterCountException: Parameter count mismatch.


            var first = new AddDelegate(Sum);
            var second = new AddDelegate((x, y) => x * y);
            first += second;
            Console.WriteLine("Hi from first and second delegates:");
            Console.WriteLine(first(7, 8));
            // Hi from Sum! This value wiil be overriden: 15 
            // 56


            Console.WriteLine("Hi from callbacks:");
            DoWork(34, x => Console.WriteLine($"I am the callback function work: {x}"));
            DoWork(34, x => Console.WriteLine($"I am the callback function work: {x - 4}"));
            DoWork(34, x => Console.WriteLine($"I am the callback function work: {x + 30}"));
            DoWork(34, x => Console.WriteLine($"I am the callback function work: {x * 10}"));
            //Hi from callbacks:
            //I am the given number: 34
            //I am the callback function work: 34
            //I am the given number: 34
            //I am the callback function work: 30
            //I am the given number: 34
            //I am the callback function work: 64
            //I am the given number: 34
            //I am the callback function work: 340
        }

        static int Sum(int n1, int n2)
        {
            Console.WriteLine($"Hi from Sum! This value wiil be overriden: {n1 + n2}");
            return n1 + n2;
        }

        static void WorkPerformed(int hours, string workType) //this is the delegate Handler - the method that do the work!!!! This method is passed to the 
                                                              //delegate instance above - the WorkPerformedHandler instance above!!!!!
        {
            Console.WriteLine("WorkPerformed called " + hours.ToString());
        }

        static void DoWork(int number, Action<int> callback)
        {
            Console.WriteLine($"I am the given number: {number}");
            callback(number);
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

        static void PrintWithLines(string msg)
        {
            Console.WriteLine("Print with lines starts ----------------------");
            Console.WriteLine(msg);
            Console.WriteLine("Print with lines ends ----------------------");

        }
    }
}
