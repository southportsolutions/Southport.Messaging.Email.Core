// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 08-05-2021
// ***********************************************************************
// <copyright file="IEmailAttachment.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;

namespace Southport.Messaging.Email.Core.EmailAttachments
{
    /// <summary>
    /// Interface IEmailAttachment
    /// </summary>
    public interface IEmailAttachment : IDisposable
    {
        /// <summary>
        /// Gets or sets the string content. Only set 1 of ContentString, StreamContent, or ContentBytes.
        /// </summary>
        string ContentString { get; set; }
        
        /// <summary>
        /// Gets or sets the stream content. Only set 1 of ContentString, StreamContent, or ContentBytes.
        /// </summary>
        Stream ContentStream { get; set; }
        
        /// <summary>
        /// Gets or sets the content bytes. Only set 1 of ContentString, StreamContent
        /// </summary>
        byte[] ContentBytes { get; set; }
        
        /// <summary>
        /// Gets or sets the type of the attachment.
        /// </summary>
        /// <value>The type of the attachment.</value>
        string AttachmentType { get; set; }
        /// <summary>
        /// Gets or sets the attachment filename.
        /// </summary>
        /// <value>The attachment filename.</value>
        string AttachmentFilename { get; set; }
    }
}