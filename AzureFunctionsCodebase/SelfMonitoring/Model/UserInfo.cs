using System;
using System.Collections.Generic;
using System.Text;

namespace BackToWorkFunctions.Model
{
    public class UserInfo
    {
        public string UserId { get; set; }
        public string UserGUID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public int YearOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string TeamsAddress { get; set; }
        public string TwilioAddress { get; set; }
        public string RequestBTWEmail { get; set; }
        public string RequestBTWMobile { get; set; }
    }
}