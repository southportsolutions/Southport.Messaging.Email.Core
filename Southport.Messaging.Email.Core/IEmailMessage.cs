using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Southport.Messaging.Email.Core.EmailAttachments;
using Southport.Messaging.Email.Core.Recipient;

namespace Southport.Messaging.Email.Core
{
    public interface IEmailMessage
    {
        IEmailAddress FromAddress { get; }
        string From { get; }
        IEnumerable<IEmailRecipient> ToAddresses { get; }
        IEnumerable<IEmailRecipient> ToAddressesValid { get; }
        IEnumerable<IEmailRecipient> ToAddressesInvalid { get; }
        IEnumerable<IEmailRecipient> CcAddresses { get; set; }
        IEnumerable<IEmailRecipient> CcAddressesValid { get; }
        IEnumerable<IEmailRecipient> CcAddressesInvalid { get; }
        IEnumerable<IEmailRecipient> BccAddresses { get; set; }
        IEnumerable<IEmailRecipient> BccAddressesValid { get; }
        IEnumerable<IEmailRecipient> BccAddressesInvalid { get; }

        string Subject { get; }
        string Text { get; }
        string Html { get; }
        List<EmailAttachment> Attachments { get; }
        string TemplateId { get; }
        DateTime? DeliveryTime { get; }
        bool? TestMode { get; }
        bool Tracking { get; }
        bool TrackingClicks { get; }
        bool TrackingOpens { get; }
        Dictionary<string, string> CustomArguments { get; }
        IEmailMessage AddFromAddress(IEmailRecipient address);
        IEmailMessage AddFromAddress(string address, string name = null);
        IEmailMessage AddToAddress(IEmailRecipient address);
        IEmailMessage AddToAddress(string address, string name = null);
        IEmailMessage AddToAddresses(List<IEmailRecipient> addresses);
        IEmailMessage AddCcAddress(IEmailRecipient address);
        IEmailMessage AddCcAddress(string address, string name = null);
        IEmailMessage AddCcAddresses(List<IEmailRecipient> addresses);
        IEmailMessage AddBccAddress(IEmailRecipient address);
        IEmailMessage AddBccAddress(string address, string name = null);
        IEmailMessage AddBccAddresses(List<IEmailRecipient> addresses);
        IEmailMessage SetSubject(string subject);
        IEmailMessage SetText(string text);
        IEmailMessage SetHtml(string html);
        IEmailMessage AddAttachments(IEmailAttachment attachment);
        IEmailMessage AddAttachments(List<IEmailAttachment> attachments);
        IEmailMessage SetTemplate(string template);
        IEmailMessage SetTemplateVersion(string templateVersion);
        IEmailMessage SetTemplateText(string templateText);
        IEmailMessage SetDeliveryTime(DateTime deliveryTime);
        IEmailMessage SetTestMode(bool testMode);
        IEmailMessage SetTracking(bool tracking);
        IEmailMessage SetTrackingClicks(bool tracking);
        IEmailMessage SetTrackingOpens(bool tracking);
        IEmailMessage SetReplyTo(string emailAddress);
        IEmailMessage AddCustomArgument(string key, string value);
        IEmailMessage AddCustomArguments(Dictionary<string, string> customArguments);
        Task<HttpResponseMessage> Send(CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> Send(string domain, CancellationToken cancellationToken = default);
    }
}