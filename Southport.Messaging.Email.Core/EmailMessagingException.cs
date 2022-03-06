using System;

namespace Southport.Messaging.Email.Core
{
    public class EmailMessagingException : Exception
    {
        public EmailMessagingException(string message) : base(message){}
    }
}
