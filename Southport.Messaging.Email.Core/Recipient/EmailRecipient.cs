// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 12-28-2020
// ***********************************************************************
// <copyright file="EmailRecipient.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Southport.Messaging.Email.Core.EmailAttachments;

namespace Southport.Messaging.Email.Core.Recipient
{
    /// <summary>
    /// Class EmailRecipient.
    /// Implements the <see cref="Southport.Messaging.Email.Core.Recipient.IEmailRecipient" />
    /// </summary>
    /// <seealso cref="Southport.Messaging.Email.Core.Recipient.IEmailRecipient" />
    public class EmailRecipient : IEmailRecipient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRecipient"/> class.
        /// </summary>
        public EmailRecipient()
        {
            Substitutions = new Dictionary<string, object>();
            Attachments = new List<IEmailAttachment>();
            CustomArguments = new Dictionary<string, string>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRecipient"/> class.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        public EmailRecipient(string emailAddress) : this()
        {
            EmailAddress = new EmailAddress(emailAddress);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRecipient"/> class.
        /// </summary>
        /// <param name="name">The recipient's name.</param>
        /// <param name="emailAddress">The recipient's email address.</param>
        public EmailRecipient(string name, string emailAddress) : this()
        {
            EmailAddress = new EmailAddress(emailAddress, name);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRecipient"/> class.
        /// </summary>
        /// <param name="name">The recipient's name.</param>
        /// <param name="emailAddress">The recipient's email address.</param>
        /// <param name="substitutions">The recipient's substitutions.</param>
        public EmailRecipient(string name, string emailAddress, Dictionary<string, object> substitutions) : this(name, emailAddress)
        {
            Substitutions = substitutions;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRecipient"/> class.
        /// </summary>
        /// <param name="name">The recipient's name.</param>
        /// <param name="emailAddress">The recipient's email address.</param>
        /// <param name="substitutions">The recipient's substitutions.</param>
        /// <param name="customArguments">The recipient's custom arguments to attach data to the message.</param>
        public EmailRecipient(string name, string emailAddress, Dictionary<string, object> substitutions, Dictionary<string, string> customArguments) : this(name, emailAddress, substitutions)
        {
            CustomArguments = customArguments;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRecipient"/> class.
        /// </summary>
        /// <param name="emailAddress">The recipient's email address.</param>
        /// <param name="substitutions">The recipient's substitutions.</param>
        public EmailRecipient(string emailAddress, Dictionary<string, object> substitutions) : this(emailAddress)
        {
            Substitutions = substitutions;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRecipient"/> class.
        /// </summary>
        /// <param name="emailAddress">The recipient's email address.</param>
        /// <param name="substitutions">The recipient's substitutions.</param>
        /// <param name="customArguments">The recipient's custom arguments to attach data to the message.</param>
        public EmailRecipient(string emailAddress, Dictionary<string, object> substitutions, Dictionary<string, string> customArguments) : this(emailAddress, substitutions)
        {
            CustomArguments = customArguments;
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        public EmailAddress EmailAddress { get; set; }
        /// <summary>
        /// Gets the substitutions.
        /// </summary>
        /// <value>The substitutions.</value>
        public Dictionary<string, object> Substitutions { get; }
        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        public List<IEmailAttachment> Attachments { get; }
        /// <summary>
        /// Gets the custom arguments.
        /// </summary>
        /// <value>The custom arguments.</value>
        public Dictionary<string, string> CustomArguments { get; }
    }
}
