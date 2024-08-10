using System.Net.Mail;
using System.Net;

namespace Mockup;

public class Email
{
    public static void SendVerificationEmail(string recipientEmail, string code, string name)
    {
        try
        {
            using (var mail = new MailMessage())
            using (var smtpClient = new SmtpClient("smtp.mail.yahoo.com", 587)) // Port 465 for SSL
            {
                mail.From = new MailAddress("boxing4change@yahoo.com");
                mail.To.Add(recipientEmail);
                mail.Subject = "Verify Code Boxing4Change";
                mail.IsBodyHtml = true;
                mail.Body = code ;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("boxing4change@yahoo.com", "ofockljtepjrjqxa"); // Use app-specific password if 2FA is enabled
                smtpClient.EnableSsl = true; // Enable SSL for port 465

                smtpClient.Send(mail);

                Console.WriteLine("Verification email sent.");
            }
        }
        catch (SmtpException smtpEx)
        {
            Console.WriteLine($"SMTP error: {smtpEx.Message}");
            if (smtpEx.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {smtpEx.InnerException.Message}");
            }
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"IO error: {ioEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error: {ex.Message}");
        }
    }
}