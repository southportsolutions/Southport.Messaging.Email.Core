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
        /// <param name="name">The recipient's name.</param>
        /// <param name="emailAddress">The recipient's email address.</param>
        /// <param name="substitutions">The recipient's substitutions.</param>
        /// <param name="customArguments">The recipient's custom arguments to attach data to the message.</param>
        /// <param name="attachments">The recipient's attachments.</param>
        public EmailRecipient(string emailAddress, string name = null, Dictionary<string, object> substitutions = null, Dictionary<string, string> customArguments = null, IEnumerable<IEmailAttachment> attachments = null) : this()
        {
            EmailAddress = new EmailAddress(emailAddress, name);

            if (substitutions != null)
            {
                foreach (var substitution in substitutions)
                {
                    Substitutions[substitution.Key] = substitution.Value;
                }
            }

            if (customArguments != null)
            {
                foreach (var customArg in customArguments)
                {
                    CustomArguments[customArg.Key] = customArg.Value;
                }
            }

            if (attachments != null)
            {
                Attachments.AddRange(attachments);
            }
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
