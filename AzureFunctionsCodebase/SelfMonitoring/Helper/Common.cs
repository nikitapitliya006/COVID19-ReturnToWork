using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

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
                //< a href = "http://www.google.com" > Google </ a >
                 //var MessageContent = "<p><a href='" + AssessmentLink + "'>" + ", here </a> please take today's screening assessment before going to work </p>";
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
    }
}