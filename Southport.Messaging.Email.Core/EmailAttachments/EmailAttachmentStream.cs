using System;
using System.IO;

namespace Southport.Messaging.Email.Core.EmailAttachments;

public sealed class EmailAttachmentStream : EmailAttachmentBase
    {
        /// <summary>
        /// Create a stream attachment.
        /// - copyOnSet: if true, the input stream will be copied into a MemoryStream (attachment owns the copy).
        /// - takeOwnershipWhenNotCopying: if true and copyOnSet is false, the attachment will dispose the provided stream when disposed.
        /// </summary>
        private readonly bool _copyOnSet;
        private readonly bool _takeOwnershipWhenNotCopying;

        /// <summary>
        /// Create a stream attachment.
        /// - copyOnSet: if true, the input stream will be copied into a MemoryStream (attachment owns the copy).
        /// - takeOwnershipWhenNotCopying: if true and copyOnSet is false, the attachment will dispose the provided stream when disposed.
        /// </summary>
        public EmailAttachmentStream(bool copyOnSet = true, bool takeOwnershipWhenNotCopying = false)
        {
            _copyOnSet = copyOnSet;
            _takeOwnershipWhenNotCopying = takeOwnershipWhenNotCopying;
        }

        public EmailAttachmentStream(Stream stream, string filename = null, string contentType = null, bool copyOnSet = true, bool takeOwnershipWhenNotCopying = false)
            : this(copyOnSet, takeOwnershipWhenNotCopying)
        {
            AttachmentFilename = filename;
            AttachmentType = contentType;
            ContentStream = stream;
        }

        public override Stream ContentStream
        {
            get => _contentStream;
            set
            {
                if (value != null && (_contentString != null || _contentBytes != null))
                    throw new InvalidOperationException("Only one of ContentString, ContentStream, or ContentBytes can be set.");

                // Dispose any previously owned stream
                if (_contentStream != null && _ownsStream)
                {
                    _contentStream.Dispose();
                    _contentStream = null;
                    _ownsStream = false;
                }

                if (value == null)
                {
                    _contentStream = null;
                    _ownsStream = false;
                    return;
                }

                if (_copyOnSet)
                {
                    if (!value.CanRead) throw new InvalidOperationException("Stream must be readable to copy.");
                    var ms = new MemoryStream();
                    if (value.CanSeek) value.Position = 0;
                    value.CopyTo(ms);
                    ms.Position = 0;
                    _contentStream = ms;
                    _ownsStream = true;
                }
                else
                {
                    _contentStream = value;
                    _ownsStream = _takeOwnershipWhenNotCopying;
                }
            }
        }
    }