using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
namespace BackToWorkFunctions.Helper
{   
    public static class NotificationHelper
    {
        public static void SendEmail(string DestEmail, string SrcEmail, string AuthorName, string AssessmentLink, string SendGridAPIKey)
        {
            try
            {
                var EmailClient = new SendGridClient(SendGridAPIKey);
                var EmailMessage = new SendGridMessage();

                EmailMessage.SetFrom(new EmailAddress(SrcEmail, AuthorName));
                EmailMessage.AddTo(DestEmail);
                EmailMessage.SetSubject("Return To Work: Today's Assessment");
                var MessageContent = "<p>Please take today's screening assessment before going to work, Thank you! \n\n <a href='" + AssessmentLink + "'>COVID-19 Return to Work Assessment</a> </p>";
                EmailMessage.AddContent(MimeType.Html, MessageContent);

                var EmailResponse = EmailClient.SendEmailAsync(EmailMessage).ConfigureAwait(false);
/*                Console.Write(EmailResponse.StatusCode);*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static void SendEmailWithQRCode(string DestEmail, string SrcEmail, string AuthorName, string imageBase64Encoding, string SendGridAPIKey)
        {
            try
            {
                var EmailClient = new SendGridClient(SendGridAPIKey);
                
                var EmailMessage = new SendGridMessage();
                EmailMessage.SetFrom(new EmailAddress(SrcEmail, AuthorName));
                EmailMessage.AddTo(DestEmail);
                EmailMessage.SetSubject("Return To Work: QR Code with Assessment Results");
                var MessageContent = "<p>Thank you for taking Screening Assessment. Please use the QR Code attached to show at your facility entrance.\n\n </p>";                
                EmailMessage.AddAttachment("qrcode.png", imageBase64Encoding);
                EmailMessage.AddContent(MimeType.Html, MessageContent);

                var EmailResponse = EmailClient.SendEmailAsync(EmailMessage);
                Console.Write(EmailResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static void GenerateQRCode(string GUIDforQR)
        {
            try
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(GUIDforQR, QRCodeGenerator.ECCLevel.Q);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);
                        byte[] resultQR = null;
                        using (MemoryStream stream = new MemoryStream())
                        {
                            qrCodeImage.Save(stream, ImageFormat.Png);
                            resultQR = stream.ToArray();
                        }
                        string resultQRBase64 = Convert.ToBase64String(resultQR);
                    }                    
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}