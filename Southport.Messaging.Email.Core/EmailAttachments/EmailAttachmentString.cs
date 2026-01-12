
namespace Southport.Messaging.Email.Core.EmailAttachments
{
    public sealed class StringAttachment : EmailAttachmentBase
    {
        public StringAttachment(string content, string filename = null, string contentType = "text/plain")
        {
            ContentString = content;
            AttachmentFilename = filename;
            AttachmentType = contentType;
        }
    }
}
