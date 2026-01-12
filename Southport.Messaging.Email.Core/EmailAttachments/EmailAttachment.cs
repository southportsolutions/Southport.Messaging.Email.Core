// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 08-05-2021
// ***********************************************************************
// <copyright file="EmailAttachment.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;
using System.Threading.Tasks;

namespace Southport.Messaging.Email.Core.EmailAttachments
{
    /// <summary>
    /// Class EmailAttachment.
    /// Implements the <see cref="Southport.Messaging.Email.Core.EmailAttachments.IEmailAttachment" />
    /// </summary>
    /// <seealso cref="Southport.Messaging.Email.Core.EmailAttachments.IEmailAttachment" />
    public class EmailAttachment : IEmailAttachment, IAsyncDisposable
    {
        private string _contentString;

        /// <summary>
        ///  Gets or sets the string content. Only set 1 of ContentString, StreamContent, or ContentBytes.
        /// </summary>

        public string ContentString
        {
            get => _contentString;
            set
            {
                if (_contentStream != null || _contentBytes != null)
                {
                    throw new InvalidOperationException("Only one of ContentString, ContentStream, or ContentBytes can be set.");
                }
                _contentString = value;
            }
        }
        
        private Stream _contentStream;

        /// <summary>
        /// Gets or sets the stream content. Only set 1 of ContentString, StreamContent, or ContentBytes.
        /// </summary>
        public Stream ContentStream
        {
            get => _contentStream;
            set
            {
                if (!string.IsNullOrWhiteSpace(_contentString) || _contentBytes != null)
                {
                    throw new InvalidOperationException(
                        "Only one of ContentString, ContentStream, or ContentBytes can be set.");
                }

                // dispose any previous owned stream
                _contentStream?.Dispose();
                _contentStream = null;

                if (value == null)
                {
                    _contentStream?.Dispose();
                    _contentStream = null;
                    return;
                }

                if (!value.CanRead) throw new InvalidOperationException("Stream must be readable to copy.");
                var ms = new MemoryStream();
                if (value.CanSeek) value.Position = 0;
                value.CopyTo(ms);
                ms.Position = 0;
                _contentStream = ms;
            }
        }
        
        private byte[] _contentBytes;
        /// <summary>
        /// Gets or sets the byte array content. Only set 1 of ContentString, StreamContent, or ContentBytes.
        /// </summary>
        public byte[] ContentBytes {
            get => _contentBytes;
            set
            {
                if (!string.IsNullOrWhiteSpace(_contentString) || _contentStream != null)
                {
                    throw new InvalidOperationException("Only one of ContentString, ContentStream, or ContentBytes can be set.");
                }
                _contentBytes = value;
            }
        }

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

        public void Dispose()
        {
            _contentStream?.Dispose();
            ContentStream?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (_contentStream != null) await _contentStream.DisposeAsync();
            if (ContentStream != null) await ContentStream.DisposeAsync();
        }
    }
}