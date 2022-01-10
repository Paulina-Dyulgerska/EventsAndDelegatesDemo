using System;

namespace Problem01
{
    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
