// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 12-29-2020
// ***********************************************************************
// <copyright file="EmailAttachment.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;

namespace Southport.Messaging.Email.Core.EmailAttachments
{
    /// <summary>
    /// Class EmailAttachment.
    /// Implements the <see cref="Southport.Messaging.Email.Core.EmailAttachments.IEmailAttachment" />
    /// Implements the <see cref="Southport.Messaging.Email.Core.EmailAttachments.IEmailAttachment" />
    /// </summary>
    /// <seealso cref="Southport.Messaging.Email.Core.EmailAttachments.IEmailAttachment" />
    public class EmailAttachment : IEmailAttachment
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the type of the attachment.
        /// </summary>
        /// <value>The type of the attachment.</value>
        public string AttachmentType { get; set; }
        /// <summary>
        /// Gets or sets the attachment filename.
        /// </summary>
        /// <value>The attachment filename.</value>
        public string AttachmentFilename { get; set; }
    }
}