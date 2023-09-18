using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.IO;
using Box;

namespace Fetch
{
    /// <summary>
    /// Holds parameters used for http/s request.
    /// </summary>
    public class FetchOptions
    {
        /// <summary>
        /// Http/s Method as string.
        /// </summary>
        public string? Method { get; set; }

        /// <summary>
        /// Authentication type used for the request.
        /// </summary>
        public IAuth? Auth { get; set; }

        /// <summary>
        /// Body of the http/s request.
        /// </summary>
        public string? Body { get; set; }

        //TODO change to more specific type
        public Stream? FileStream { get; set; }

        /// <summary>
        /// Headers of the http/s request.
        /// </summary>
        public IReadOnlyDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Content type header of the http/s request.
        /// </summary>
        public string? ContentType { get; set; }

        internal HttpMethod _httpMethod
        {
            get
            {
                httpMethodsMap.TryGetValue(Method ?? "GET", out var tempMethod);
                return tempMethod!;
            }
        }

        //TODO still not used.
        public NetworkSession? NetworkSession { get; set; }

        public IReadOnlyDictionary<string, string>? Parameters { get; set; }

        //TODO implement usage
        public IReadOnlyCollection<MultipartItem>? MultipartData { get; set; }

        //TODO implement usage
        public string? ResponseFormat { get; set; }


        private static Dictionary<string, HttpMethod> httpMethodsMap = new Dictionary<string, HttpMethod>() {
            { "GET", HttpMethod.Get },
            { "POST", HttpMethod.Post },
            { "PUT", HttpMethod.Put },
            { "PATCH", HttpMethod.Patch },
            { "DELETE", HttpMethod.Delete },
            { "OPTIONS", HttpMethod.Options }
        };

        /// <summary>
        /// Creates FetchOptions from the parameters.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <param name="fileStream"></param>
        /// <param name="auth"></param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        public FetchOptions(string? method = null, string? body = null, Stream? fileStream = null, IAuth? auth = null, IReadOnlyDictionary<string, string>? headers = null, string? contentType = null, NetworkSession? networkSession = null, IReadOnlyDictionary<string, string>? parameters = null, IReadOnlyCollection<MultipartItem>? multipartData = null, string? responseFormat = null)
        {
            Method = method;
            Auth = auth;
            Body = body;
            FileStream = fileStream;
            Headers = headers ?? new ReadOnlyDictionary<string, string>(new Dictionary<string, string>());
            ContentType = contentType;
            NetworkSession = networkSession;
            Parameters = parameters;
            MultipartData = multipartData;
            ResponseFormat = responseFormat;
        }
    }
}