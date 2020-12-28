using System.Collections.Generic;
using Southport.Messaging.Email.Core.EmailAttachments;

namespace Southport.Messaging.Email.Core.Recipient
{
    public class EmailRecipient : IEmailRecipient
    {
        public EmailRecipient()
        {
            Substitutions = new Dictionary<string, object>();
            Attachments = new List<IEmailAttachment>();
        }
        public EmailRecipient(string address) : this()
        {
            EmailAddress = new EmailAddress(address);
        }
        public EmailRecipient(string name, string address) : this()
        {
            EmailAddress = new EmailAddress(address, name);
        }
        public EmailRecipient(string name, string address, Dictionary<string, object> substitutions) : this(name, address)
        {
            Substitutions = substitutions;
        }
        public EmailRecipient(string address, Dictionary<string, object> substitutions) : this(address)
        {
            Substitutions = substitutions;
        }

        public EmailAddress EmailAddress { get; set; }
        public Dictionary<string, object> Substitutions { get; set; }
        public List<IEmailAttachment> Attachments { get; set; }

    }
}
