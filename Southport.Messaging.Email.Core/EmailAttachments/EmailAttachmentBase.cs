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
    public abstract class EmailAttachmentBase : IEmailAttachment
    {
        protected string _contentString;
        protected byte[] _contentBytes;
        protected Stream _contentStream;
        protected bool _ownsStream;

        public virtual string ContentString
        {
            get => _contentString;
            set
            {
                if (value != null && (_contentStream != null || _contentBytes != null))
                    throw new InvalidOperationException("Only one of ContentString, ContentStream, or ContentBytes can be set.");
                _contentString = value;
            }
        }

        public virtual Stream ContentStream
        {
            get => _contentStream;
            set
            {
                if (value != null && (_contentString != null || _contentBytes != null))
                    throw new InvalidOperationException("Only one of ContentString, ContentStream, or ContentBytes can be set.");
                // Default behavior: accept reference but do not claim ownership.
                _contentStream = value;
                _ownsStream = false;
            }
        }

        public virtual byte[] ContentBytes
        {
            get => _contentBytes == null ? null : (byte[])_contentBytes.Clone();
            set
            {
                if (value != null && (_contentString != null || _contentStream != null))
                    throw new InvalidOperationException("Only one of ContentString, ContentStream, or ContentBytes can be set.");
                _contentBytes = value == null ? null : (byte[])value.Clone();
            }
        }

        public string AttachmentType { get; set; }
        public string AttachmentFilename { get; set; }

        public virtual async ValueTask DisposeAsync()
        {
            // Dispose any owned stream once
            if (_contentStream != null && _ownsStream)
            {
                await _contentStream.DisposeAsync().ConfigureAwait(false);
                _contentStream = null;
                _ownsStream = false;
            }

            GC.SuppressFinalize(this);
        }

        public virtual void Dispose()
        {
            // Dispose any owned stream once
            if (_contentStream != null && _ownsStream)
            {
                _contentStream.Dispose();
                _contentStream = null;
                _ownsStream = false;
            }

            GC.SuppressFinalize(this);
        }
    }
}