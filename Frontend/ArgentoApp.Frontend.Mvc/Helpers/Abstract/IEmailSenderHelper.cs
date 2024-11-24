using System;
using ArgentoApp.Frontend.Mvc.Models.Email;

namespace ArgentoApp.Frontend.Mvc.Helpers.Abstract;


public interface IEmailSenderHelper
{
    Task SendEmailAsync(SendEmailModel model);
}
