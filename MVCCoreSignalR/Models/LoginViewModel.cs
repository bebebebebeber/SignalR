using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekStore.Data.ViewModels
{
    public class LoginViewModel
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string Captcha { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> EnternalLogins  { get; set; }
    }
}
