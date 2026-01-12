
namespace Southport.Messaging.Email.Core.EmailAttachments
{
    public sealed class EmailAttachmentString : EmailAttachmentBase
    {
        public EmailAttachmentString(string content, string filename = null, string contentType = "text/plain")
        {
            ContentString = content;
            AttachmentFilename = filename;
            AttachmentType = contentType;
        }
    }
}
