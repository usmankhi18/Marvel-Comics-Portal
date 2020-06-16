using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using System.Data;
using Newtonsoft.Json;
using Logger;
using Utilities;
using Marvel_Comics_Web_API.DTO;

namespace Marvel_Comics_Web_API.Controllers
{
    public class UserController : ApiController
    {
        string clsName = "UserController";
        [HttpPost]
        [Route("api/user/GetLogin")]
        public ResponseDTO GetLogin(LoginRequestDTO request)
        {
            string funcName = "GetMemberLogin";
            Logger.Logger.FuncOpen(clsName, funcName, "request", JsonConvert.SerializeObject(request));
            ResponseDTO res = new ResponseDTO();
            using (MarvelBLL objMarvelBLL = new MarvelBLL())
            {
                try
                {
                    APICredentialsBLL credentialsBLL = new APICredentialsBLL();
                    credentialsBLL.UserName = request.APICredentials.APIUserName;
                    credentialsBLL.Password = request.APICredentials.APIPassword;
                    if (!new CommonMethods().ValidateRequest(credentialsBLL))
                    {
                        res.ResponseCode = ResponseCodes.Failed;
                        res.ResponseMessage = ResponseMessages.InvalidCredentials;
                    }
                    else if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                    {
                        res.ResponseCode = ResponseCodes.Failed;
                        res.ResponseMessage = ResponseMessages.InvalidData;
                    }
                    else
                    {
                        APICredentialsBLL credentials = new APICredentialsBLL();
                        credentials.UserName = request.Email;
                        credentials.Password = request.Password;
                        DataTable dtRecord = new UsersBLL().GetLogin(objMarvelBLL, credentials);
                        LoginResponse login = new LoginResponse();
                        if (dtRecord.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtRecord.Rows)
                            {
                                login.UserID = int.Parse(row["UserID"].ToString());
                                login.Email = row["Email"].ToString();
                                login.UserName = row["UserName"].ToString();
                                login.FirstName = row["MemberName"].ToString();
                                login.LastName = row["LastName"].ToString();
                                login.IsActive = bool.Parse(row["IsActive"].ToString());
                                login.MobileNo = row["MobileNo"].ToString();
                                login.Gender = row["Gender"].ToString();
                            }
                            res.ResponseCode = ResponseCodes.Success;
                            res.ResponseMessage = ResponseMessages.Success;
                        }


                        else
                        {
                            res.ResponseCode = ResponseCodes.Success;
                            res.ResponseMessage = ResponseMessages.LoginFailed;

                        }
                        res.ResponseData = new ResponseData();
                        res.ResponseData.LoginResp = login;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Logger.WriteErrorLog(clsName, funcName, ex);
                    res.ResponseCode = ResponseCodes.Failed;
                    res.ResponseMessage = ex.Message;
                }

            }
            Logger.Logger.Information(clsName, funcName, "Response", JsonConvert.SerializeObject(res));
            Logger.Logger.FuncClose(clsName, funcName);
            return res;
        }

        [HttpPost]
        [Route("api/user/ChangePassword")]
        public ResponseDTO ChangePassword(ChangePasswordRequestDTO request)
        {
            string funcName = "ChangePassword";
            Logger.Logger.FuncOpen(clsName, funcName, "request", JsonConvert.SerializeObject(request));
            ResponseDTO res = new ResponseDTO();
            using (MarvelBLL objMarvelBLL = new MarvelBLL())
            {
                try
                {
                    APICredentialsBLL credentialsBLL = new APICredentialsBLL();
                    credentialsBLL.UserName = request.APICredentials.APIUserName;
                    credentialsBLL.Password = request.APICredentials.APIPassword;
                    if (!new CommonMethods().ValidateRequest(credentialsBLL))
                    {
                        res.ResponseCode = ResponseCodes.Failed;
                        res.ResponseMessage = ResponseMessages.InvalidCredentials;
                    }
                    else if (request.UserID <= 0)
                    {
                        res.ResponseCode = ResponseCodes.Failed;
                        res.ResponseMessage = ResponseMessages.InvalidUser;
                    }
                    else if (string.IsNullOrWhiteSpace(request.UserID.ToString()) || string.IsNullOrWhiteSpace(request.CurrentPassword) || string.IsNullOrWhiteSpace(request.NewPassword))
                    {
                        res.ResponseCode = ResponseCodes.Failed;
                        res.ResponseMessage = ResponseMessages.InvalidData;
                    }
                    else
                    {
                        APICredentialsBLL credentials = new APICredentialsBLL();
                        credentials.UserName = request.UserID.ToString();
                        credentials.Password = request.CurrentPassword;
                        if (new UsersBLL().CheckPassword(objMarvelBLL, credentials)) {
                            APICredentialsBLL credential = new APICredentialsBLL();
                            credential.UserName = request.UserID.ToString();
                            credential.Password = request.NewPassword;
                            if (new UsersBLL().ChangePassword(objMarvelBLL, credential))
                            {
                                res.ResponseCode = ResponseCodes.Success;
                                res.ResponseMessage = ResponseMessages.Success;
                            }
                            else
                            {
                                res.ResponseCode = ResponseCodes.Success;
                                res.ResponseMessage = ResponseMessages.InvalidUser;

                            }
                        }
                        else {
                            res.ResponseCode = ResponseCodes.Success;
                            res.ResponseMessage = ResponseMessages.IncorrectCurrent;
                        }
                        res.ResponseData = new ResponseData();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Logger.WriteErrorLog(clsName, funcName, ex);
                    res.ResponseCode = ResponseCodes.Failed;
                    res.ResponseMessage = ex.Message;
                }

            }
            Logger.Logger.Information(clsName, funcName, "Response", JsonConvert.SerializeObject(res));
            Logger.Logger.FuncClose(clsName, funcName);
            return res;
        }
    }
}
