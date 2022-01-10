namespace Problem05
{
    public class SolderEventArgs
    {
        public SolderEventArgs(string name, string solderToStringMessage)
        {
            this.Name = name;
            this.SolderToStringMessage = solderToStringMessage;
        }

        public string Name { get; set; }

        public string SolderToStringMessage { get; set; }
    }
}
