using System;

namespace Problem04
{
    public class JobEventArgs : EventArgs
    {
        public JobEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
