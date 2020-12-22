using System.Collections.Generic;

namespace Southport.Messaging.Email.Core.Recipient
{
    public interface IEmailRecipient
    {
        EmailAddress EmailAddress { get; set; }
        Dictionary<string, string> Substitutions { get; set; }
    }
}