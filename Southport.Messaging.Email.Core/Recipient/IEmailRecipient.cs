using System.Collections.Generic;
using System.Runtime.InteropServices;
using Southport.Messaging.Email.Core.EmailAttachments;

namespace Southport.Messaging.Email.Core.Recipient
{
    public interface IEmailRecipient
    {
        EmailAddress EmailAddress { get; set; }
        Dictionary<string, object> Substitutions { get; set; }
        List<IEmailAttachment> Attachments { get; set; }
    }
}