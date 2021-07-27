namespace Southport.Messaging.Email.Core
{
    public interface IEmailMessageFactory
    {
        IEmailMessageCore Create();
        
    }
}