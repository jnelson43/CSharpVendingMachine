using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    abstract class Interaction
    {
        public abstract string Id { get; set; }
        public abstract DateTime InteractionDateTime  { get; set; }
    }
}
