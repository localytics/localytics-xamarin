using System;
using LocalyticsMaui.Common;

namespace LocalyticsMaui.Common
{
    public class Customer : LocalyticsMaui.Common.IXLCustomer
    {
        string customerId;
        string firstName;
        string lastName;
        string fullName;
        string emailAddress;

        public Customer(string customerId, string firstName, string lastName, string fullName, string emailAddress)
        {
            this.CustomerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = fullName;
            this.emailAddress = emailAddress;
        }

        public string CustomerId { get => customerId; private set { customerId = value; } }

        public string FirstName { get => firstName; private set { firstName = value; } }

        public string LastName { get => lastName; private set { lastName = value; } }

        public string FullName { get => fullName; private set { fullName = value; } }

        public string EmailAddress { get => emailAddress; private set { emailAddress = value; } }
    }
}
