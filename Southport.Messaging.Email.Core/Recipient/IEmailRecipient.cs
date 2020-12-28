using System.Collections.Generic;
using Southport.Messaging.Email.Core.EmailAttachments;

namespace Southport.Messaging.Email.Core.Recipient
{
    public interface IEmailRecipient
    {
        EmailAddress EmailAddress { get; }
        Dictionary<string, object> Substitutions { get; }
        List<IEmailAttachment> Attachments { get; }
        Dictionary<string, string> CustomArguments { get; }
    }
}