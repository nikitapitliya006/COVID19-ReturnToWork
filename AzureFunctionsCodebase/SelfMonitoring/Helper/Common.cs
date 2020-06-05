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

namespace BackToWorkFunctions.Helper
{
    public class Common
    {
        //check if email address is valid 
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static async Task<bool> SendEmail(string DestEmail, string SrcEmail, string AuthorName, string ReceipientName, string AssessmentLink, string SendGridAPIKey)
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

                var EmailResponse = await EmailClient.SendEmailAsync(EmailMessage);
                Console.Write(EmailResponse);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public static async Task<bool> SendEmailWithQRCode(string DestEmail, string SrcEmail, string AuthorName, string ReceipientName, string imageBase64Encoding, string SendGridAPIKey)
        {
            try
            {
                var EmailClient = new SendGridClient(SendGridAPIKey);
                
                var EmailMessage = new SendGridMessage();
                EmailMessage.SetFrom(new EmailAddress(SrcEmail, AuthorName));
                EmailMessage.AddTo(DestEmail);
                EmailMessage.SetSubject("Return To Work: QR Code with Assessment Results");
                var MessageContent = "<p>Thank you for taking Screening Assessment. Here is the QR Code to show at your facility entrance.\n\n </p>";
                EmailMessage.AddContent(MimeType.Html, MessageContent);

                //QRCode image embed                

                var EmailResponse = await EmailClient.SendEmailAsync(EmailMessage);
                Console.Write(EmailResponse);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public static bool GenerateQRCode(string GUID)
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

                Console.WriteLine("QR Code generated");
                var qrCode1 = new FileContentResult(resultQR, "image/png");

                //SendEmailWithQRCode()

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}