namespace Bookbox.Service.Email
{
    public class MailDataWithAttachment : MailData
    {
        public required IFormFileCollection EmailAttachments { get; set; }
    }
}
