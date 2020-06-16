using Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL
{
    public class APICredentialsBLL
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class CommonMethods
    {
        string clsName = "CommonMethods";
        public bool ValidateRequest(APICredentialsBLL objAPICredentials)
        {
            string funcName = "ValidateRequest";
            bool IsValidate = false;
            Logger.Logger.Information(clsName,funcName, "objAPICredentials", JsonConvert.SerializeObject(objAPICredentials));
            try
            {
                if (objAPICredentials.UserName == CommonObjects.GetCongifValue(ConfigKeys.UserName) && objAPICredentials.Password == CommonObjects.GetCongifValue(ConfigKeys.Password))
                    IsValidate = true;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteErrorLog(clsName,funcName,ex);
                throw;
            }
            Logger.Logger.Information(clsName,funcName,"IsValidate",IsValidate.ToString());
            return IsValidate;
        }

        public string NumberFormat(int num)
        {
            string funcName = "NumberFormat";
            string FormattedString = "";
            try
            {
                if (num >= 100000000)
                {
                    FormattedString = (num / 1000000).ToString("#,0M");
                }
                else if (num >= 10000000)
                {
                    FormattedString = (num / 1000000).ToString("0.#") + "M";
                }
                else if (num >= 100000)
                {
                    FormattedString = (num / 1000).ToString("#,0K");
                }
                else if (num >= 10000)
                {
                    FormattedString = (num / 1000).ToString("0.#") + "K";
                }
                else
                {
                    FormattedString = num.ToString("#,0");
                }
            }
            catch (Exception ex) {
                Logger.Logger.WriteErrorLog(clsName, funcName, ex);
            }
            Logger.Logger.Information(clsName, funcName, "FormattedString", FormattedString);
            return FormattedString;
        }

    }
}
