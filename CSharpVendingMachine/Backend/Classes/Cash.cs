using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Cash : Payment
    {
        public override double Value { get; set; }

        public Cash(double value)
        {
            this.Value = value;
        }
    }
}
