using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    abstract class Payment
    {
        public abstract double Value { get; set; }
    }
}
