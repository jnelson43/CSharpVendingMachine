using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public  decimal Cost { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public Item(string id, string name, string code, decimal cost,string type,int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
            this.Cost = cost;
            this.Type = type;
            this.Quantity = quantity;
        }
    }
}
