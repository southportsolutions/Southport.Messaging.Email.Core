using System.IO;

namespace Southport.Messaging.Email.Core.EmailAttachments
{
    public class EmailAttachment : IEmailAttachment
    {
        public Stream Content { get; set; }
        public string AttachmentType { get; set; }
        public string AttachmentFilename { get; set; }
    }
}