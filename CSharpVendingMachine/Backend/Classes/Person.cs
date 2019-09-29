using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    abstract class Person
    {
        public abstract string Id { get; set; }

        public abstract string Username { get; set; }
        public abstract string Password { get; set; }
        public abstract List<Interaction> History { get; set; }
    }
}
