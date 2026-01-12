namespace Southport.Messaging.Email.Core.EmailAttachments;

public sealed class EmailAttachmentBytes : EmailAttachmentBase
{
    public EmailAttachmentBytes(byte[] bytes, string fileName, string contentType)
    {
        ContentBytes = bytes;
        AttachmentFilename = fileName;
        AttachmentType = contentType;
    }
}