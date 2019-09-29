using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class AdministrativeMaintenance : Interaction
    {
        public override string Id { get; set; }
        public override DateTime InteractionDateTime { get; set; }
        public string AdminID { get; set; }
        public string Description { get; set; }

        public AdministrativeMaintenance(string id, DateTime datetime, string adminID, string description)
        {
            this.Id = id;
            this.InteractionDateTime = datetime;
            this.AdminID = adminID;
            this.Description = description;
        }
    }
}
