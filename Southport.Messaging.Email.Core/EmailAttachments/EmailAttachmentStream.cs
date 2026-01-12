using System;
using System.IO;
using System.Threading.Tasks;

namespace Southport.Messaging.Email.Core.EmailAttachments;

public sealed class EmailAttachmentStream : IEmailAttachment, IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Create a stream attachment.
        /// - copyOnSet: if true, the input stream will be copied into a MemoryStream (attachment owns the copy).
        /// - takeOwnershipWhenNotCopying: if true and copyOnSet is false, the attachment will dispose the provided stream when disposed.
        /// </summary>
        private readonly bool _copyOnSet;
        private readonly bool _takeOwnershipWhenNotCopying;
        private bool _ownsStream;

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
            Filename = filename;
            Type = contentType;
            Content = stream;
        }

        public string Filename { get; set; }
        public string Type { get; set; }

        private Stream _contentStream;
        // Strongly-typed property for normal use
        public Stream Content
        {
            get => _contentStream;
            set
            {
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
                if (value is Stream s)
                {
                    Content = s;
                    return;
                }
                throw new InvalidCastException("IEmailAttachment.Content must be a string for EmailAttachmentString.");
            }
        }

        public async ValueTask DisposeAsync()
        {
            // Dispose any owned stream once
            if (_contentStream != null && _ownsStream)
            {
                await _contentStream.DisposeAsync().ConfigureAwait(false);
                _contentStream = null;
                _ownsStream = false;
            }
        }

        public void Dispose()
        {
            // Dispose any owned stream once
            if (_contentStream != null && _ownsStream)
            {
                _contentStream.Dispose();
                _contentStream = null;
                _ownsStream = false;
            }
        }
    }