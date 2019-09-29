using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Purchase : Interaction
    {
        public override string Id { get; set; }
        public override DateTime InteractionDateTime { get; set; }
        public double Total { get; set; }
        public List<Item> Cart { get; set; }
        public Payment Payment { get; set; }
        public double Change { get; set; }

        public Purchase(string id, DateTime datetime, double total, List<Item> cart, Payment payment, double change)
        {
            this.Id = id;
            this.InteractionDateTime = datetime;
            this.Total = total;
            this.Cart = cart;
            this.Payment = payment;
            this.Change = change;
        }

        public Purchase()
        {
            this.InteractionDateTime = DateTime.Now;
            this.Total = 0.0;
            this.Cart = new List<Item>();
            this.Payment = null;
        }
    }
}
