using System;
using LocalyticsXamarin.Common;
using LocalyticsXamarin.Shared;
#if __IOS__
using LocalyticsXamarin.IOS;
#else
using LocalyticsXamarin.Android;
#endif

namespace LocalyticsXamarin.Shared
{
    public partial class Customer : LocalyticsXamarin.Common.ILLCustomer
    {
        //NativeCustomer customer;
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

        public string CustomerId { get => customerId; set { customerId = value; } }

        public string FirstName { get => firstName; set { firstName = value; } }

        public string LastName { get => lastName; set { lastName = value; } }

        public string FullName { get => fullName; set { fullName = value; } }

        public string EmailAddress { get => emailAddress; set { emailAddress = value; } }

        object ILLCustomer.ToNativeCustomer()
        {
#if __IOS__
            return LLCustomer.CustomerWithBlock((LLCustomerBuilder builder) =>
            {
                builder.CustomerId = CustomerId;
                builder.EmailAddress = EmailAddress;
                builder.FirstName = FirstName;
                builder.FullName = FullName;
                builder.LastName = LastName;
            });
#else
            LocalyticsXamarin.Android.Customer.Builder builder = new LocalyticsXamarin.Android.Customer.Builder();
            builder.SetCustomerId(CustomerId);
            builder.SetEmailAddress(EmailAddress);
            builder.SetFirstName(FirstName);
            builder.SetFullName(FullName);
            builder.SetLastName(LastName);
            return builder.Build();
#endif    
        }

    }
}
