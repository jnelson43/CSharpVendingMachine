using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine
{
    class Stocker : Person
    {
        public override string Id { get; set; }
        public override string Username { get; set; }
        public override string Password { get; set; }
        public override List<Interaction> History { get; set; }

        public Stocker(string stockerID,string username, string stockerPassword, List<Interaction> stockerHistory)
        {
            this.Id = stockerID;
            this.Username = Username;
            this.Password = stockerPassword;
            this.History = stockerHistory;
        }

        public Stocker()
        {
            Id = "";
            Username = "Stocker";
            Password = "password";
            History = new List<Interaction>();
        }
    }
}
