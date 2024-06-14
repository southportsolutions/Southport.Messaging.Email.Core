// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 03-06-2022
// ***********************************************************************
// <copyright file="IEmailResult.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Net.Http;
using Southport.Messaging.Email.Core.Recipient;

namespace Southport.Messaging.Email.Core.Result
{
    /// <summary>
    /// Interface IEmailResult
    /// </summary>
    public interface IEmailResult
    {
        /// <summary>
        /// Gets or sets the email recipient.
        /// </summary>
        /// <value>The email recipient.</value>
        IEmailRecipient EmailRecipient { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>The response message.</value>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the email body.
        /// </summary>
        /// <value>The email body.</value>
        public string MessageBody { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is successful.
        /// </summary>
        /// <value><c>true</c> if this instance is successful; otherwise, <c>false</c>.</value>
        bool IsSuccessful { get; set; }
    }
}
