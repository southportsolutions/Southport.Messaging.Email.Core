using System;

namespace Southport.Messaging.Email.Core.EmailAttachments;

public sealed class EmailAttachmentBytes : IEmailAttachment
{
    public EmailAttachmentBytes(byte[] bytes, string fileName, string contentType)
    {
        Content = bytes;
        Filename = fileName;
        Type = contentType;
    }

    // Strongly-typed property for normal use
    public byte[] Content { get; set; }

    // Explicit interface implementation to satisfy IEmailAttachment (object)
    object IEmailAttachment.Content
    {
        get => Content;
        set
        {
            if (value == null)
            {
                Content = null;
                return;
            }
            if (value is byte[] s)
            {
                Content = s;
                return;
            }
            throw new InvalidCastException("IEmailAttachment.Content must be a byte[] for EmailAttachmentBytes.");
        }
    }
    public string Type { get; set; }
    public string Filename { get; set; }
}