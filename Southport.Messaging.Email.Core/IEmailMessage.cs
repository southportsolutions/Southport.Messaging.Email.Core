﻿// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : Robert H Anstett
// Created          : 12-27-2020
//
// Last Modified By : Robert H Anstett
// Last Modified On : 2021-02-24
// ***********************************************************************
// <copyright file="IEmailMessage.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Southport.Messaging.Email.Core.EmailAttachments;
using Southport.Messaging.Email.Core.Recipient;
using Southport.Messaging.Email.Core.Result;

namespace Southport.Messaging.Email.Core
{
    public interface IEmailMessageCore
    {
        /// <summary>
        /// Gets from address.
        /// </summary>
        /// <value>From address.</value>
        IEmailAddress FromAddress { get; }
        /// <summary>
        /// Gets from.
        /// </summary>
        /// <value>From.</value>
        string From { get; }
        /// <summary>
        /// Converts to addresses.
        /// </summary>
        /// <value>To addresses.</value>
        IEnumerable<IEmailRecipient> ToAddresses { get; }
        /// <summary>
        /// Get valid To addresses.
        /// </summary>
        /// <value>Valid To addresses.</value>
        IEnumerable<IEmailRecipient> ToAddressesValid { get; }
        /// <summary>
        /// Get invalid To addresses.
        /// </summary>
        /// <value>Invalid To addresses.</value>
        IEnumerable<IEmailRecipient> ToAddressesInvalid { get; }
        /// <summary>
        /// Gets the cc addresses.
        /// </summary>
        /// <value>The cc addresses.</value>
        IEnumerable<IEmailAddress> CcAddresses { get; }
        /// <summary>
        /// Get valid CC addresses.
        /// </summary>
        /// <value>Valid CC addresses.</value>
        IEnumerable<IEmailAddress> CcAddressesValid { get; }
        /// <summary>
        /// Get invalid CC addresses.
        /// </summary>
        /// <value>Invalid CC addresses.</value>
        IEnumerable<IEmailAddress> CcAddressesInvalid { get; }
        /// <summary>
        /// Gets the BCC addresses.
        /// </summary>
        /// <value>The BCC addresses.</value>
        IEnumerable<IEmailAddress> BccAddresses { get; }
        /// <summary>
        /// Get valid BCC addresses.
        /// </summary>
        /// <value>Valid BCC addresses.</value>
        IEnumerable<IEmailAddress> BccAddressesValid { get; }
        /// <summary>
        /// Gets the BCC addresses invalid.
        /// </summary>
        /// <value>The BCC addresses invalid.</value>
        IEnumerable<IEmailAddress> BccAddressesInvalid { get; }

        /// <summary>
        /// Gets the subject.
        /// </summary>
        /// <value>The subject.</value>
        string Subject { get; }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        string Text { get; }
        /// <summary>
        /// Gets the HTML.
        /// </summary>
        /// <value>The HTML.</value>
        string Html { get; }
        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        List<IEmailAttachment> Attachments { get; }
        /// <summary>
        /// Gets the template identifier.
        /// </summary>
        /// <value>The template identifier.</value>
        string TemplateId { get; }
        /// <summary>
        /// Gets the delivery time.
        /// </summary>
        /// <value>The delivery time.</value>
        DateTime? DeliveryTime { get; }
        /// <summary>
        /// Gets a value indicating whether [test mode].
        /// </summary>
        /// <value><c>null</c> if [test mode] contains no value, <c>true</c> if [test mode]; otherwise, <c>false</c>.</value>
        bool? TestMode { get; }
        /// <summary>
        /// Gets a value indicating whether this <see cref="IEmailMessageCore"/> is tracking.
        /// </summary>
        /// <value><c>true</c> if tracking; otherwise, <c>false</c>.</value>
        bool Tracking { get; }
        /// <summary>
        /// Gets a value indicating whether [tracking clicks].
        /// </summary>
        /// <value><c>true</c> if [tracking clicks]; otherwise, <c>false</c>.</value>
        bool TrackingClicks { get; }
        /// <summary>
        /// Gets a value indicating whether [tracking opens].
        /// </summary>
        /// <value><c>true</c> if [tracking opens]; otherwise, <c>false</c>.</value>
        bool TrackingOpens { get; }
        /// <summary>
        /// Gets the custom arguments.
        /// </summary>
        /// <value>The custom arguments.</value>
        Dictionary<string, string> CustomArguments { get; }
        /// <summary>
        /// Sends the specified cancellation token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;IEnumerable&lt;IEmailResult&gt;&gt;.</returns>
        Task<IEnumerable<IEmailResult>> Send(CancellationToken cancellationToken = default);
        /// <summary>
        /// Sends the specified domain.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;IEnumerable&lt;IEmailResult&gt;&gt;.</returns>
        Task<IEnumerable<IEmailResult>> Send(string domain, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Interface IEmailMessage
    /// </summary>
    public interface IEmailMessage<TInterface> : IEmailMessageCore where TInterface : IEmailMessageCore
    {
        /// <summary>
        /// Adds from address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddFromAddress(IEmailAddress emailAddress);
        /// <summary>
        /// Adds from address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddFromAddress(string emailAddress, string name = null);
        /// <summary>
        /// Adds to address.
        /// </summary>
        /// <param name="recipient">The address.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddToAddress(IEmailRecipient recipient);
        /// <summary>
        /// Adds to address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddToAddress(string emailAddress, string name = null);
        /// <summary>
        /// Adds to addresses.
        /// </summary>
        /// <param name="recipients">The addresses.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddToAddresses(List<IEmailRecipient> recipients);
        /// <summary>
        /// Adds the cc address.
        /// </summary>
        /// <param name="recipient">The address.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddCcAddress(IEmailAddress recipient);
        /// <summary>
        /// Adds the cc address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddCcAddress(string emailAddress, string name = null);
        /// <summary>
        /// Adds the cc addresses.
        /// </summary>
        /// <param name="recipients">The addresses.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddCcAddresses(List<IEmailAddress> recipients);
        /// <summary>
        /// Adds the BCC address.
        /// </summary>
        /// <param name="recipient">The address.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddBccAddress(IEmailAddress recipient);
        /// <summary>
        /// Adds the BCC address.
        /// </summary>
        /// <param name="emailAddress">The address.</param>
        /// <param name="name">The name.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddBccAddress(string emailAddress, string name = null);
        /// <summary>
        /// Adds the BCC addresses.
        /// </summary>
        /// <param name="recipients">The addresses.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddBccAddresses(List<IEmailAddress> recipients);
        /// <summary>
        /// Sets the subject.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetSubject(string subject);
        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetText(string text);
        /// <summary>
        /// Sets the HTML.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetHtml(string html);
        /// <summary>
        /// Adds the attachments.
        /// </summary>
        /// <param name="attachment">The attachment.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddAttachments(IEmailAttachment attachment);
        /// <summary>
        /// Adds the attachments.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddAttachments(List<IEmailAttachment> attachments);
        /// <summary>
        /// Sets the template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetTemplate(string template);
        /// <summary>
        /// Sets the delivery time.
        /// </summary>
        /// <param name="deliveryTime">The delivery time.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetDeliveryTime(DateTime deliveryTime);
        /// <summary>
        /// Sets the test mode.
        /// </summary>
        /// <param name="testMode">if set to <c>true</c> [test mode].</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetTestMode(bool testMode);
        /// <summary>
        /// Sets the tracking.
        /// </summary>
        /// <param name="tracking">if set to <c>true</c> [tracking].</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetTracking(bool tracking);
        /// <summary>
        /// Sets the tracking clicks.
        /// </summary>
        /// <param name="tracking">if set to <c>true</c> [tracking].</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetTrackingClicks(bool tracking);
        /// <summary>
        /// Sets the tracking opens.
        /// </summary>
        /// <param name="tracking">if set to <c>true</c> [tracking].</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetTrackingOpens(bool tracking);
        /// <summary>
        /// Sets the reply to.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface SetReplyTo(string emailAddress);
        /// <summary>
        /// Adds the custom argument to attach data to the message (recipient custom arguments will override message level ones).
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddCustomArgument(string key, string value);
        /// <summary>
        /// Adds the custom arguments.
        /// </summary>
        /// <param name="customArguments">The custom arguments.</param>
        /// <returns>IEmailMessage.</returns>
        TInterface AddCustomArguments(Dictionary<string, string> customArguments);
    }
}