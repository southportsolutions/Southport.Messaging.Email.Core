using System.Net.Http;
using Southport.Messaging.Email.Core.Recipient;

namespace Southport.Messaging.Email.Core.Result
{
    public interface IEmailResult
    {
        IEmailRecipient EmailRecipient { get; set; }
        HttpResponseMessage ResponseMessage { get; set; }
    }
}
