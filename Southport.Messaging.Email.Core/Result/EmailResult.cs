// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 03-06-2022
// ***********************************************************************
// <copyright file="EmailResult.cs" company="Southport Solutions, LLC">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using Southport.Messaging.Email.Core.Recipient;

namespace Southport.Messaging.Email.Core.Result
{

    /// <summary>
    /// Class EmailResult.
    /// Implements the <see cref="Southport.Messaging.Email.Core.Result.IEmailResult" />
    /// </summary>
    /// <seealso cref="Southport.Messaging.Email.Core.Result.IEmailResult" />
    public class EmailResult : IEmailResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailResult" /> class.
        /// </summary>
        /// <param name="emailRecipient">The email recipient.</param>
        /// <param name="isSuccessful">if set to <c>true</c> [is successful].</param>
        /// <param name="message">The message.</param>
        public EmailResult(IEmailRecipient emailRecipient, bool isSuccessful, string message)
        {
            EmailRecipient = emailRecipient;
            IsSuccessful = isSuccessful;
            Message = message;
        }
        /// <summary>
        /// Gets or sets the email recipient.
        /// </summary>
        /// <value>The email recipient.</value>
        public IEmailRecipient EmailRecipient { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>The response message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the email body.
        /// </summary>
        /// <value>The email body.</value>
        public string MessageBody { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is successful.
        /// </summary>
        /// <value><c>true</c> if this instance is successful; otherwise, <c>false</c>.</value>
        public bool IsSuccessful { get; set; }
    }
}