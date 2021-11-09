using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfHostWebAPIConsoleApp
{
    class WebApiMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //create a task with response message 
            //what task? Response message
            var task = new Task<HttpResponseMessage>(() =>
            {
                //create a messare response object and send this message back
                //message handler
                HttpResponseMessage message = new HttpResponseMessage();
                message.Content = new StringContent("I am a response!");
                return message;
            });

            task.Start();
            return task;

        }
    }
}
