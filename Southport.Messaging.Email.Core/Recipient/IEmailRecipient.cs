// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 12-29-2020
// ***********************************************************************
// <copyright file="IEmailRecipient.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Southport.Messaging.Email.Core.EmailAttachments;

namespace Southport.Messaging.Email.Core.Recipient
{
    /// <summary>
    /// Interface IEmailRecipient
    /// </summary>
    public interface IEmailRecipient
    {
        /// <summary>
        /// Gets the email address.
        /// </summary>
        /// <value>The email address.</value>
        EmailAddress EmailAddress { get; }
        /// <summary>
        /// Gets the substitutions.
        /// </summary>
        /// <value>The substitutions.</value>
        Dictionary<string, object> Substitutions { get; }
        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <value>The email attachments.</value>
        List<IEmailAttachment> Attachments { get; }
        /// <summary>
        /// Gets the custom arguments.
        /// </summary>
        /// <value>The custom arguments, used to attach data to the email.</value>
        Dictionary<string, string> CustomArguments { get; }
    }
}