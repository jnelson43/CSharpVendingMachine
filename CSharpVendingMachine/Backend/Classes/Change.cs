
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Change : Payment
    {
        public override double Value { get; set; }

        public Change(double value)
        {
            this.Value = value;
        }
    }
}
