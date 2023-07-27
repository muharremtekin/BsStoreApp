using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Services.Contracts;

namespace Services.Concrete
{

    public class MailManager : IMailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public MailManager()
        {
            _smtpServer = "smtp.gmail.com";
            _smtpPort = 587;
            _smtpUsername = "muharremtknn@gmail.com";
            _smtpPassword = "qjdnjozzejnwelzq";
        }


        public void SendEmail(List<string> toEmails, string subject, string body, bool isHtml = false)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("System Mail", _smtpUsername));

            foreach (var toEmail in toEmails)
            {
                message.To.Add(new MailboxAddress("TO EMAIL", toEmail));
            }

            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = body
            };

            if (isHtml)
            {
                bodyBuilder.HtmlBody = body;
            }

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(_smtpServer, _smtpPort, SecureSocketOptions.Auto);

                client.Authenticate(_smtpUsername, _smtpPassword);

                client.Send(message);

                client.Disconnect(true);
            }
        }

        public void SendEmailAsync(string toEmail, string subject, string body, bool isHtml = false)
        {
            throw new NotImplementedException();
        }

        public void SendEmailWithAttachments(string toEmail, string subject, string body, byte[] pdfBytes, byte[] excelBytes, bool isHtml = false)
        {
            if (pdfBytes == null || excelBytes == null)
            {
                throw new ArgumentNullException("pdfBytes or excelBytes");
            }
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("System", _smtpUsername));
            message.To.Add(new MailboxAddress("Yetkili", address: toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = body
            };

            if (isHtml)
            {
                bodyBuilder.HtmlBody = body;
            }

            bodyBuilder.Attachments.Add("Report.pdf", pdfBytes, ContentType.Parse("application/pdf"));
            bodyBuilder.Attachments.Add("Report.xlsx", excelBytes, ContentType.Parse("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));



            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(_smtpServer, _smtpPort, SecureSocketOptions.Auto);

                client.Authenticate(_smtpUsername, _smtpPassword);

                client.Send(message);

                client.Disconnect(true);
            }
        }
    }

}
