using Microsoft.Extensions.Options;
using MimeKit;
using System.Diagnostics;
using MailKit.Net.Smtp;


namespace Bookbox.Service.Email
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;
        }

        public bool SendMail(MailData mailData)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    emailMessage.From.Add(new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail));
                    emailMessage.To.Add(new MailboxAddress(mailData.EmailToName, mailData.EmailToId));

                    /* emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "emedofelix@gmail.com"));
                     emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "emedofelix@gmail.com"));
     */
                    emailMessage.Subject = mailData.EmailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = mailData.EmailBody;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        mailClient.Connect(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        mailClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                        mailClient.Send(emailMessage);
                        mailClient.Disconnect(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }
        }

        public bool SendHTMLMail(MailData htmlMailData)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    Debug.WriteLine(htmlMailData);
                    MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);

                    MailboxAddress emailTo = new MailboxAddress(htmlMailData.EmailToName, htmlMailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Subject = htmlMailData.EmailSubject;
                    /*
                    string filePath = Directory.GetCurrentDirectory() + "\\Templates\\Hello.html";
                    string emailTemplateText = File.ReadAllText(filePath);

                    emailTemplateText = string.Format(emailTemplateText, htmlMailData.EmailToName, DateTime.Today.Date.ToShortDateString());
                    */

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.HtmlBody = htmlMailData.EmailBody;
                    //emailBodyBuilder.TextBody = "Plain Text goes here to avoid marked as spam for some email servers.";

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        Debug.WriteLine($"Sending to... {htmlMailData.EmailToId}");
                        Debug.WriteLine($"Sending to... {_mailSettings.Server}");
                        Debug.WriteLine($"Sending to... {_mailSettings.Port}");
                        Debug.WriteLine($"Sending to... {MailKit.Security.SecureSocketOptions.StartTls}");
                        //mailClient.Capabilities &= ~SmtpCapabilities.Chunking;
                        //mailClient.Capabilities &= ~SmtpCapabilities.BinaryMime;
                        mailClient.SslProtocols = System.Security.Authentication.SslProtocols.None;
                        mailClient.Connect(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        mailClient.Authenticate(_mailSettings.SenderEmail, _mailSettings.Password);
                        mailClient.Send(emailMessage);
                        mailClient.Disconnect(true);
                    }
                }
                Debug.WriteLine("Email Sent success");

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SendMailWithAttachment(MailDataWithAttachment mailData)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    // you can add the CCs and BCCs here.
                    //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                    //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                    emailMessage.Subject = mailData.EmailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = mailData.EmailBody;

                    if (mailData.EmailAttachments != null)
                    {
                        foreach (var attachmentFile in mailData.EmailAttachments)
                        {
                            if (attachmentFile.Length == 0)
                            {
                                continue;
                            }

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                attachmentFile.CopyTo(memoryStream);
                                var attachmentFileByteArray = memoryStream.ToArray();

                                emailBodyBuilder.Attachments.Add(attachmentFile.FileName, attachmentFileByteArray, ContentType.Parse(attachmentFile.ContentType));
                            }
                        }
                    }

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        mailClient.Connect(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        mailClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                        mailClient.Send(emailMessage);
                        mailClient.Disconnect(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }
        }

    }
}
