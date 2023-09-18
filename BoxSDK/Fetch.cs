using Microsoft.Extensions.DependencyInjection;
using Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Fetch
{
    static class ContentTypes
    {
        public const string FormUrlEncoded = "application/x-www-form-urlencoded";
    }

    /// <summary>
    /// Static HttpClient.
    /// </summary>
    public static class SimpleHttpClient
    {
        static IHttpClientFactory _clientFactory;

        static SimpleHttpClient()
        {
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            if (httpClientFactory == null)
            {
                throw new Exception("Unable to create HttpClient. Cannot get an IHttpClientFactory instance from a ServiceProvider.");
            }
            _clientFactory = httpClientFactory;
        }

        /// <summary>
        /// Executes http/s request.
        /// </summary>
        /// <param name="resource">Target url of a request.</param>
        /// <param name="options">Request options of a request.</param>
        /// <returns>A http/s Response as a FetchResponse.</returns>
        public static async Task<FetchResponse> Fetch(string resource, FetchOptions options)
        {
            var client = _clientFactory.CreateClient();

            var url = resource;

            if (options.Parameters != null)
            {
                url = string.Join("?", resource, string.Join('&', options.Parameters.Select(q => $"{HttpUtility.UrlEncode(q.Key)}={HttpUtility.UrlEncode(q.Value)}")));
            }

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = options._httpMethod,
                RequestUri = new Uri(url),
                Content = options.Body != null ? new StringContent(options.Body) : default
            };

            foreach (var header in options.Headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }

            if (options.Auth != null)
            {
                var token = await options.Auth.RetrieveToken();
                httpRequestMessage.Headers.Add("Authorization", $"Bearer {token.AccessTokenField}");
            }

            if (options.ContentType == ContentTypes.FormUrlEncoded)
            {
                var deserialized = SimpleJsonConverter.Deserialize<Dictionary<string, string>>(options.Body);
                httpRequestMessage.Content = new FormUrlEncodedContent(deserialized);
            }

            var response = await client.SendAsync(httpRequestMessage);

            var statusCode = (int)response.StatusCode;
            var textResponse = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"StatusCode: {statusCode}. Message: {textResponse}.");
            }

            return new FetchResponse() { Status = statusCode, Text = textResponse };
        }
    }
}