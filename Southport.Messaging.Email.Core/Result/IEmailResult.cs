﻿// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 12-27-2020
// ***********************************************************************
// <copyright file="IEmailResult.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
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
        HttpResponseMessage ResponseMessage { get; set; }
    }
}
