using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace UI
{
    public static class GlobalVariables
    {
        public static HttpClient webApiHttpClient = new HttpClient();

        static GlobalVariables()
        {
            webApiHttpClient.BaseAddress = new Uri("http://localhost:56576/api/");
            webApiHttpClient.DefaultRequestHeaders.Clear();
            webApiHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}