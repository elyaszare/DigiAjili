﻿using System;
using System.Net;
using System.Net.Mail;

namespace _0_Framework.Application.Email
{
    public class EmailService : IEmailService
    {
        public string SendEmail(string toAddress, string subject, string body)
        {
            var result = "Message Sent Successfully..!!";
            var senderID = "elyas@elyaszare.ir";
            const string senderPassword = "Ez1298Ez";
            try
            {
                var smtp = new SmtpClient
                {
                    Host = "elyaszare.ir",
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderID, senderPassword),
                    Timeout = 30000
                };
                var message = new MailMessage(senderID, toAddress, subject, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
                var a = ex.Message;
            }

            return result;
        }
    }
}