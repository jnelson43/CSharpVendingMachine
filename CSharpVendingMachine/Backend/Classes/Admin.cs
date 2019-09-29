using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Admin : Person
    {
        public override string Id { get; set; }
        public override string Username { get; set; }
        public override string Password { get; set; }
        public override List<Interaction> History { get; set; }

        public Admin(string adminID, string username, string adminPassword, List<Interaction> adminHistory = null)
        {
            this.Id = adminID;
            this.Username = username;
            this.Password = adminPassword;
            this.History = adminHistory;
        }

        public Admin()
        {
            Id = "";
            Username = "admin";
            Password = "admin";
            History = new List<Interaction>();
        }
    }
}
