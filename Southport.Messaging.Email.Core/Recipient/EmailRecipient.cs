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
            CustomArguments = new Dictionary<string, string>();
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
        public EmailRecipient(string name, string address, Dictionary<string, object> substitutions, Dictionary<string, string> customArguments) : this(name, address, substitutions)
        {
            CustomArguments = customArguments;
        }
        public EmailRecipient(string address, Dictionary<string, object> substitutions) : this(address)
        {
            Substitutions = substitutions;
        }
        public EmailRecipient(string address, Dictionary<string, object> substitutions, Dictionary<string, string> customArguments) : this(address, substitutions)
        {
            CustomArguments = customArguments;
        }

        public EmailAddress EmailAddress { get; set; }
        public Dictionary<string, object> Substitutions { get; }
        public List<IEmailAttachment> Attachments { get; }
        public Dictionary<string, string> CustomArguments { get; }
    }
}
