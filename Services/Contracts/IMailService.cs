namespace Services.Contracts
{
    public interface IMailService
    {
        // E-posta gönderme metodu
        void SendEmailAsync(string toEmail, string subject, string body, bool isHtml = false);

        // E-posta gönderme metodu (birden fazla alıcıya)
        void SendEmail(List<string> toEmails, string subject, string body, bool isHtml = false);

        // E-posta gönderme metodu (dosya ekleriyle birlikte)
        void SendEmailWithAttachments(string toEmail, string subject, string body, byte[] pdfBytes, byte[] excelBytes, bool isHtml = false);
    }
}
