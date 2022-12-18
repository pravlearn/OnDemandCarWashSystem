using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CarWashWebApplication.Repository
{
    public class ServiceRepository
    {
        HttpClient client;
        public ServiceRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiurl"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }

    }
}