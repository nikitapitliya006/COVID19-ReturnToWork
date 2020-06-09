using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Reflection;

namespace BackToWorkFunctions.Helper
{
   
    public class Common
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static void SendEmail(string DestEmail, string SrcEmail, string AuthorName, string ReceipientName, string AssessmentLink, string SendGridAPIKey)
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

                var EmailResponse = EmailClient.SendEmailAsync(EmailMessage);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static void SendEmailWithQRCode(string DestEmail, string SrcEmail, string AuthorName, string RecipientName, string imageBase64Encoding, string SendGridAPIKey)
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

        public static void GenerateQRCode(string GUID)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(GUID, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                //convert bitmap to png in MemoryStream
                byte[] resultQR = null;
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, ImageFormat.Png);
                    resultQR = stream.ToArray();
                }
                string resultQRBase64 = Convert.ToBase64String(resultQR);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}