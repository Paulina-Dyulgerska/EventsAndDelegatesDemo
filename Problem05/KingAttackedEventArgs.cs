using System;

namespace Problem05
{
    public class KingAttackedEventArgs : EventArgs
    //not needed to derive from EventArgs anymore,
    //code will work even without deriving from EventArgs.
    {
        public KingAttackedEventArgs(string name, string kingToStringMessage)
        {
            this.Name = name;
            this.KingToStringMessage = kingToStringMessage;
        }

        public string Name { get; }

        public string KingToStringMessage { get; }
    }
}
