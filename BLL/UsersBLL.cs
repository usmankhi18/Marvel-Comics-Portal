using Cryptography;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL
{
   public class UsersBLL
    {
        string clsName = "UsersBLL";
        public DataTable GetLogin(MarvelBLL objMarvelBLL, APICredentialsBLL credentials)
        {
            string funcName = "GetLogin";
            Logger.Logger.Information(clsName, funcName, "UserName", credentials.UserName);
            DataTable dtRecord = new DataTable();
            try
            {
                using (SqlCommand sqlComm = new SqlCommand("proc_GetLogin"))
                {
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@Email", credentials.UserName);
                    sqlComm.Parameters.AddWithValue("@Password", MD5.CreateMd5Hash(credentials.Password));
                    dtRecord = objMarvelBLL.GetData(sqlComm);
                    Logger.Logger.Information(clsName, funcName, "dtRecord.Rows.Count", dtRecord.Rows.Count.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteErrorLog(clsName, funcName, ex);
                throw new Exception(string.Format("Error occured while Login : {0}", ex.Message), ex);
            }
            return dtRecord;
        }

        public bool ChangePassword(MarvelBLL objMarvelBLL, APICredentialsBLL credentials)
        {
            string funcName = "ChangePassword";
            bool isReset = false;
            Logger.Logger.Information(clsName, funcName);
            DataTable dtRecord = new DataTable();
            try
            {
                using (SqlCommand sqlComm = new SqlCommand("proc_ChangePassword"))
                {
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@UserID", int.Parse(credentials.UserName));
                    sqlComm.Parameters.AddWithValue("@Password", MD5.CreateMd5Hash(credentials.Password));
                    dtRecord = objMarvelBLL.GetData(sqlComm);
                    Logger.Logger.Information(clsName, funcName, "dtRecord.Rows.Count", dtRecord.Rows.Count.ToString());
                    if (dtRecord.Rows.Count > 0)
                    {
                        isReset = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteErrorLog(clsName, funcName, ex);
                throw new Exception(string.Format("Error occured while Change Password : {0}", ex.Message), ex);
            }
            Logger.Logger.Information(clsName, funcName, "isReset", isReset.ToString());
            return isReset;
        }

        public bool CheckPassword(MarvelBLL objMarvelBLL, APICredentialsBLL credentials)
        {
            string funcName = "CheckPassword";
            DataTable dtRecord = new DataTable();
            bool isReset = false;
            try
            {
                using (SqlCommand sqlComm = new SqlCommand("proc_CheckPassword"))
                {
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@UserID", int.Parse(credentials.UserName));
                    sqlComm.Parameters.AddWithValue("@Password", MD5.CreateMd5Hash(credentials.Password));
                    dtRecord = objMarvelBLL.GetData(sqlComm);
                    Logger.Logger.Information(clsName, funcName, "dtRecord.Rows.Count", dtRecord.Rows.Count.ToString());
                    if (dtRecord.Rows.Count > 0)
                    {
                        if (dtRecord.Rows[0]["IsActive"].ToString() == "Exist") {
                            isReset = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteErrorLog(clsName, funcName, ex);
                throw new Exception(string.Format("Error occured while Check Password : {0}", ex.Message), ex);
            }
            Logger.Logger.Information(clsName, funcName, "isReset", isReset.ToString());
            return isReset;
        }
    }
}
