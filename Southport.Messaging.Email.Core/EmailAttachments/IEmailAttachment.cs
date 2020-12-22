using System.IO;

namespace Southport.Messaging.Email.Core.EmailAttachments
{
    public interface IEmailAttachment
    {
        Stream Content { get; set; }
        string AttachmentType { get; set; }
        string AttachmentFilename { get; set; }
    }
}