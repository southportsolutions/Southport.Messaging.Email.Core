
using System;

namespace Southport.Messaging.Email.Core.EmailAttachments
{
    public sealed class EmailAttachmentString : IEmailAttachment
    {
        public EmailAttachmentString(string content, string filename = null, string contentType = "text/plain")
        {
            Content = content;
            Filename = filename;
            Type = contentType;
        }

        // Strongly-typed property for normal use
        public string Content { get; set; }

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
                if (value is string s)
                {
                    Content = s;
                    return;
                }
                throw new InvalidCastException("IEmailAttachment.Content must be a string for EmailAttachmentString.");
            }
        }
        public string Type { get; set; }
        public string Filename { get; set; }
    }
}
