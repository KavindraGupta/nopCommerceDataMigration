using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Helper
{
    public static class ApiCall
    {
        async public static Task<HttpResponseMessage> PostGenericMessage<T>(string apiEndpoint, string userName, string password, T typeofYourClass) where T : class
        {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password)));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("uri");

                var postTask = client.PostAsJsonAsync(apiEndpoint, typeofYourClass);
                return await postTask;
            }

        }
    }
}
