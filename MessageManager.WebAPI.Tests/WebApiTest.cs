/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MessageManager.WebAPI.Tests
{
    [TestFixture]
    public class WebApiTest
    {
        [Test]
        public static void MessageWebAPI()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9283/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                //HttpResponseMessage messages = await client.GetAsync("api/Message/GetMessagesBySendUser/张三");
                string messages = await client.GetStringAsync("api/Message/GetMessagesBySendUser/张三");
            }
        }
    }
}
