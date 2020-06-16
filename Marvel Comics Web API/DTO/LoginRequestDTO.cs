using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_Comics_Web_API.DTO
{
    public class LoginRequestDTO
    {
        public APICredentials APICredentials { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordRequestDTO
    {
        public APICredentials APICredentials { get; set; }
        public int UserID { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class APICredentials { 
        public string APIUserName { get; set; }
        public string APIPassword { get; set; }
    } 
}