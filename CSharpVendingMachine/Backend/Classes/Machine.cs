using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Machine
    {
        public List<Item> Inventory { get; set; }
        public decimal PaymentsTotal { get; set; }
        public DateTime DateSinceStocked { get; set; }
        public List<Interaction> History { get; set; }

        public Machine(List<Item> inventory, decimal paymentsTotal, DateTime dateSinceStocked, List<Interaction> history)
        {
            this.Inventory = inventory;
            this.PaymentsTotal = paymentsTotal;
            this.DateSinceStocked = dateSinceStocked;
            this.History = history;
        }

        public Machine()
        {
            this.Inventory = new List<Item>();
            this.PaymentsTotal = 0;
            this.DateSinceStocked = DateTime.Now;
            this.History = new List<Interaction>();
        }
    }
}
