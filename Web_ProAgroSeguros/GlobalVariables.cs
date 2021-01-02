using AspCoreConsumingWebApi.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Mvc
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        private static readonly IConfiguration _Configure;

        static GlobalVariables()
        {
            ApplicationSettings.WebApiUrl = _Configure.GetValue<string>("WebAPIBaseUrl");

            //WebApiClient.BaseAddress = new Uri("http://localhost:64028/api/");
            WebApiClient.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}