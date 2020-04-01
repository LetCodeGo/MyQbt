using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace QbtWebAPI
{
    public static partial class API
    {
        private static async Task<HttpResponseMessage> Get(
            HttpClient client, string requestUri)
        {
            try
            {
                var reply = await client.GetAsync(requestUri);
                if (!reply.IsSuccessStatusCode)
                {
                    if (reply.StatusCode != HttpStatusCode.Unauthorized)
                        RaiseDisconnectedEvent();
                    throw new QBTException(
                        reply.StatusCode, await reply.Content.ReadAsStringAsync());
                }
                return reply;
            }

            catch (HttpRequestException)
            {
                return null;
            }

            catch (TaskCanceledException)
            {
                RaiseDisconnectedEvent();
                return null;
            }
        }

        private static async Task<HttpResponseMessage> Post(
            HttpClient client, string requestUri, StringContent content = null)
        {
            try
            {
                var reply = await client.PostAsync(requestUri, content);
                if (!reply.IsSuccessStatusCode)
                {
                    if (reply.StatusCode != HttpStatusCode.Unauthorized)
                        RaiseDisconnectedEvent();
                    throw new QBTException(
                        reply.StatusCode, await reply.Content.ReadAsStringAsync());
                }
                return reply;
            }

            catch (HttpRequestException ex)
            {
                throw ex;
            }

            catch (TaskCanceledException ex)
            {
                RaiseDisconnectedEvent();
                throw ex;
            }
        }

        private static async Task<HttpResponseMessage> Post(
            HttpClient client, string requestUri, MultipartFormDataContent content)
        {
            try
            {
                var reply = await client.PostAsync(requestUri, content);
                if (!reply.IsSuccessStatusCode)
                {
                    if (reply.StatusCode != HttpStatusCode.Unauthorized)
                        RaiseDisconnectedEvent();
                    throw new QBTException(
                        reply.StatusCode, await reply.Content.ReadAsStringAsync());
                }
                return reply;
            }

            catch (HttpRequestException ex)
            {
                throw ex;
            }

            catch (TaskCanceledException ex)
            {
                RaiseDisconnectedEvent();
                throw ex;
            }
        }

        private static string ListToString(List<string> stringList, char separator)
        {
            string returnString = "";
            foreach (string element in stringList)
                returnString += element + separator;
            returnString = returnString.Remove(returnString.Length - 1);

            return returnString;
        }

        private static string ListToString(List<Uri> uris, char separator)
        {
            string returnString = "";
            foreach (Uri element in uris)
                returnString += element.ToString() + separator;
            returnString = returnString.Remove(returnString.Length - 1);

            return returnString;
        }

        private static StringContent ToStringContent(string text)
        {
            return new StringContent(
                text, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
        }
    }
}
