namespace Bookbox.Service.Email
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
        bool SendHTMLMail(MailData htmlMailData);
        bool SendMailWithAttachment(MailDataWithAttachment mailData);
    }

}
