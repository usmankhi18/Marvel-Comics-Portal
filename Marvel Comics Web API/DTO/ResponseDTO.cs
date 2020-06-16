using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_Comics_Web_API.DTO
{
    public class ResponseDTO
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public ResponseData ResponseData { get; set; }
    }

    public class ResponseData
    {
        public LoginResponse LoginResp { get; set; }
    }

    public class LoginResponse
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string MobileNo { get; set; }
        public string DateOfBirth { get; set; }
        public string Country { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
    }
}