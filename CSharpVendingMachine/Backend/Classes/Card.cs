using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Card : Payment
    {
        public override double Value { get; set; }
        public string CardNum { get; set; }
        public string Expiration { get; set; }
        public string SecurityNumber { get; set; }

        public Card(double value,string cardNum, string expiration, string securityNumber)
        {
            this.Value = value;
            this.CardNum = cardNum;
            this.Expiration = expiration;
            this.SecurityNumber = securityNumber
        }
    }
}
