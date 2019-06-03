using System.Net.Mail;
using System;

/*
*
* Sample code do send mail using smpt and C#
* Note: doesn't work if gmail is locked by security reasos or two factor authentication
* 03/06/2019
*
*/

public class Program {
	public static void Main(string[] args) {
		MailMessage mail = new MailMessage("vladimir.rech@meifacil.com", "rechvladimir@hotmail.com");
		mail.Subject = "this is a test email.";
		mail.Body = "this is my test email body";
		SmtpClient client = new SmtpClient("vladimir.rech@meifacil.com", 587);
		client.Host = "smtp.gmail.com";
		client.Port = 587;
		client.EnableSsl = true;
		client.DeliveryMethod = SmtpDeliveryMethod.Network;
		client.UseDefaultCredentials = false;
		client.Credentials = new System.Net.NetworkCredential("vladimir.rech", "_vL4d1m1r/");
		client.Send(mail);
	}
}