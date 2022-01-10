using System;

namespace EventsAndDelegatesDemo
{
    public class PersonPropertyEventArgs : EventArgs
    {
        public string PropertyName { get; set; }

        public object OldValue { get; set; }

        public object NewValue { get; set; }
    }
}
