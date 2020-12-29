// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 12-27-2020
// ***********************************************************************
// <copyright file="EmailResult.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Net.Http;
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
        /// Initializes a new instance of the <see cref="EmailResult"/> class.
        /// </summary>
        /// <param name="emailRecipient">The email recipient.</param>
        /// <param name="responseMessage">The response message.</param>
        public EmailResult(IEmailRecipient emailRecipient, HttpResponseMessage responseMessage)
        {
            EmailRecipient = emailRecipient;
            ResponseMessage = responseMessage;
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
        public HttpResponseMessage ResponseMessage { get; set; }
    }
}