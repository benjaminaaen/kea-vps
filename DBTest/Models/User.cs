using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace DBTest.Models
{
    public enum CredentialLevel
        {
            User, Supporter, Administrator
        }

    public class User
    {
        public int UserId { get; set; }
        public CredentialLevel CredentialLevel { get; set; }
        public String Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Boolean Confirmed { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        


    }
}