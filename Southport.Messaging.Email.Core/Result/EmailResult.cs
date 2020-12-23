using System.Net.Http;
using Southport.Messaging.Email.Core.Recipient;

namespace Southport.Messaging.Email.Core.Result
{
    public class EmailResult : IEmailResult
    {
        public EmailResult(IEmailRecipient emailRecipient, HttpResponseMessage responseMessage)
        {
            EmailRecipient = emailRecipient;
            ResponseMessage = responseMessage;
        }
        public IEmailRecipient EmailRecipient { get; set; }
        public HttpResponseMessage ResponseMessage { get; set; }
    }
}