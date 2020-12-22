using System.Collections.Generic;

namespace Southport.Messaging.Email.Core.Recipient
{
    public class EmailRecipient : IEmailRecipient
    {
        public EmailRecipient()
        {
            Substitutions = new Dictionary<string, string>();
        }
        public EmailRecipient(string address) : this()
        {
            EmailAddress = new EmailAddress(address);
        }
        public EmailRecipient(string name, string address) : this()
        {
            EmailAddress = new EmailAddress(address, name);
        }
        public EmailRecipient(string name, string address, Dictionary<string, string> substitutions) : this(name, address)
        {
            Substitutions = substitutions;
        }
        public EmailRecipient(string address, Dictionary<string, string> substitutions) : this(address)
        {
            Substitutions = substitutions;
        }

        public EmailAddress EmailAddress { get; set; }
        public Dictionary<string, string> Substitutions { get; set; }

    }
}
