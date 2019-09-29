using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Maintenance : Interaction
    {
        public override string Id { get; set; }
        public override DateTime InteractionDateTime { get; set; }
        public string StockerID { get; set; }
        public IDictionary<string, int> Added { get; set; }
        public IDictionary<string, int> Removed { get; set; }

        public Maintenance(string id, DateTime datetime, string stockerID, IDictionary<string, int> added, IDictionary<string, int> removed)
        {
            this.Id = id;
            this.InteractionDateTime = datetime;
            this.StockerID = stockerID;
            this.Added = added;
            this.Removed = removed;
        }
    }
}
