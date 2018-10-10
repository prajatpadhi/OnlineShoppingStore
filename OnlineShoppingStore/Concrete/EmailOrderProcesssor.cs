using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingStore.Repository;
using OnlineShoppingStore.Models;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace OnlineShoppingStore.Concrete
{
    public class EmailOrderProcesssor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcesssor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, ShippingDetails details)
        {
            using (var smtpClient=new SmtpClient())
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
               


               StringBuilder body=new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");
                foreach(CartLine c in cart.ReturnCart)
                {
                    var total = c.product.Price * c.Quantity;
                    body.AppendFormat("{0}   x   {1}   (subtotal: {2:c})\n", c.product.Name, c.product.Price, total);
                }
                body.AppendFormat("Total Price: ({0})", cart.ComputeTotalPrice());

                body.AppendFormat("Total order value: {0:c}",
                    cart.ComputeTotalPrice())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(details.Name)
                    .AppendLine(details.Line1)
                    .AppendLine(details.Line2 ?? "")
                    .AppendLine(details.Line3 ?? "")
                    .AppendLine(details.City)
                    .AppendLine(details.State ?? "")
                    .AppendLine(details.Country)
                    .AppendLine(details.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}",
                        details.GiftWrap ? "Yes" : "No");
                MailMessage message = new MailMessage(new MailAddress(emailSettings.MailFromAddress).Address,
                    new MailAddress(emailSettings.MailToAddress).Address, "Order successfully placed", body.ToString());
                smtpClient.Send(message);
            }
        }
    }
}