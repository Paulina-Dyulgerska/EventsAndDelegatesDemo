using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get => this.name;

            set
            {
                this.name = value;
                //// super typo e da wikam method i prez nego da wikam Invoke na eventa!!!
                //// Mnogo po-hitro e da go Invoke-na direktno tuk i tolkowa, vyobshte ne mi trqbwa
                //// tozi OnNameChange!!!!!
                //this.OnNameChange(new NameChangeEventArgs(value));
                this.NameChange?.Invoke(this, new NameChangeEventArgs(value));
            }
        }

        //private void OnNameChange(NameChangeEventArgs args)
        //{
        //    this.NameChange?.Invoke(this, args);
        //}
    }
}
