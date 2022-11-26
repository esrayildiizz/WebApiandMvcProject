using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;


namespace UI
{
    public static class GlobalVaribles
    {
        public static HttpClient WebApClient = new HttpClient(); //git url ye bağlan 



        static GlobalVaribles()
        {
            WebApClient.BaseAddress = new Uri("https://localhost:44351//api/"); 
            WebApClient.DefaultRequestHeaders.Clear();
            WebApClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }


    }
}