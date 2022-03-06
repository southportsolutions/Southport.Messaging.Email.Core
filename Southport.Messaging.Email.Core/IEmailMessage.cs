// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : Robert H Anstett
// Created          : 12-27-2020
//
// Last Modified By : Robert H Anstett
// Last Modified On : 2021-08-05
// ***********************************************************************
// <copyright file="IEmailMessage.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Southport.Messaging.Email.Core.EmailAttachments;
using Southport.Messaging.Email.Core.Recipient;

namespace Southport.Messaging.Email.Core
{
    /// <summary>
    /// Interface IEmailMessage
    /// </summary>
    [Obsolete("Use IEmailMessageCore.")]
    public interface IEmailMessage<TInterface, TResult> : IEmailMessageCore<TResult> 
        where TInterface : IEmailMessageCore<TResult> 
        where TResult : class 
    {
        /// <summary>
        /// Adds from address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddFromAddress(IEmailAddress emailAddress);
        /// <summary>
        /// Adds from address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddFromAddress(string emailAddress, string name = null);
        /// <summary>
        /// Adds to address.
        /// </summary>
        /// <param name="recipient">The address.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddToAddress(IEmailRecipient recipient);
        /// <summary>
        /// Adds to address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddToAddress(string emailAddress, string name = null);
        /// <summary>
        /// Adds to addresses.
        /// </summary>
        /// <param name="recipients">The addresses.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddToAddresses(List<IEmailRecipient> recipients);
        /// <summary>
        /// Adds the cc address.
        /// </summary>
        /// <param name="recipient">The address.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddCcAddress(IEmailAddress recipient);
        /// <summary>
        /// Adds the cc address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddCcAddress(string emailAddress, string name = null);
        /// <summary>
        /// Adds the cc addresses.
        /// </summary>
        /// <param name="recipients">The addresses.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddCcAddresses(List<IEmailAddress> recipients);
        /// <summary>
        /// Adds the BCC address.
        /// </summary>
        /// <param name="recipient">The address.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddBccAddress(IEmailAddress recipient);
        /// <summary>
        /// Adds the BCC address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddBccAddress(string emailAddress, string name = null);
        /// <summary>
        /// Adds the BCC addresses.
        /// </summary>
        /// <param name="recipients">The addresses.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddBccAddresses(List<IEmailAddress> recipients);
        /// <summary>
        /// Sets the subject.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetSubject(string subject);
        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetText(string text);
        /// <summary>
        /// Sets the HTML.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetHtml(string html);
        /// <summary>
        /// Adds the attachments.
        /// </summary>
        /// <param name="attachment">The attachment.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddAttachments(IEmailAttachment attachment);
        /// <summary>
        /// Adds the attachments.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddAttachments(List<IEmailAttachment> attachments);
        /// <summary>
        /// Sets the template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetTemplate(string template);
        /// <summary>
        /// Sets the delivery time.
        /// </summary>
        /// <param name="deliveryTime">The delivery time.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetDeliveryTime(DateTime deliveryTime);
        /// <summary>
        /// Sets the test mode.
        /// </summary>
        /// <param name="testMode">if set to <c>true</c> [test mode].</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetTestMode(bool testMode);
        /// <summary>
        /// Sets the tracking.
        /// </summary>
        /// <param name="tracking">if set to <c>true</c> [tracking].</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetTracking(bool tracking);
        /// <summary>
        /// Sets the tracking clicks.
        /// </summary>
        /// <param name="tracking">if set to <c>true</c> [tracking].</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetTrackingClicks(bool tracking);
        /// <summary>
        /// Sets the tracking opens.
        /// </summary>
        /// <param name="tracking">if set to <c>true</c> [tracking].</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetTrackingOpens(bool tracking);
        /// <summary>
        /// Sets the reply to.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface SetReplyTo(string emailAddress);
        /// <summary>
        /// Adds the custom argument to attach data to the message (recipient custom arguments will override message level ones).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddCustomArgument(string key, string value);
        /// <summary>
        /// Adds the custom arguments.
        /// </summary>
        /// <param name="customArguments">The custom arguments.</param>
        /// <returns>IEmailMessage.</returns>
        new TInterface AddCustomArguments(Dictionary<string, string> customArguments);
    }
}