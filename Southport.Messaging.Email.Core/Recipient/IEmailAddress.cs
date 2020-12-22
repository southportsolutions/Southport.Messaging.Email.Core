namespace Southport.Messaging.Email.Core.Recipient
{
    public interface IEmailAddress
    {
        string Name { get; set; }
        string Address { get; set; }
        bool Validate();
        string ToString();
    }
}