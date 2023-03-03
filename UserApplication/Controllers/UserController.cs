using Infrastructure.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserApplication.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetOtp(int userId)
        {
            //var otp = 0;
            using (var httpClient = new HttpClient())
            {
                var otp = 0;
                var isErrorMessage = false;
                var errorMessage = "";

                var dateTime = DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture);
                var requestParameters = string.Format("?userId={0}&dateTime={1}", userId, dateTime);
                var response = httpClient.GetAsync(string.Format(Constant.UserApiBaseUrl+ Constant.UserSecurityApiGetOtpUrl + requestParameters)).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    isErrorMessage = true;
                    errorMessage = "Error while processing the Reqest";
                }
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    isErrorMessage = true;
                    errorMessage = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    otp = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);
                }
                var result = new { IsErrorMessage = isErrorMessage, ErrorMessage = errorMessage, Otp = otp };
                return Json(result);
            }
        }
        [HttpGet]
        public IActionResult IsOtpAlreadyGenrated(int userId)
        {
            using (var httpClient = new HttpClient())
            {
                var isExist = false;
                var isErrorMessage = false;
                var errorMessage = "";
                var requestParameters = string.Format("?userId={0}", userId);
                var response = httpClient.GetAsync(string.Format(Constant.UserApiBaseUrl+Constant.UserSecurityApiIsOtpAlreadyGenratedUrl + requestParameters)).Result;                
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    isErrorMessage = true;
                    errorMessage = "Error while processing the Reqest";
                }
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    isErrorMessage = true;
                    errorMessage = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    isExist = Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
                }
                var result = new { IsErrorMessage = isErrorMessage, ErrorMessage = errorMessage, isExist = isExist };
                return Json(result);
            }
        }
    }
}
