using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DictionaryExtensions;
using Fetch;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class DownloadsManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public DownloadsManager() {
            
        }
        public async System.Threading.Tasks.Task<System.IO.Stream> DownloadFile(string fileId, DownloadFileQueryParamsArg? queryParams = default, DownloadFileHeadersArg? headers = default) {
            queryParams = queryParams ?? new DownloadFileQueryParamsArg();
            headers = headers ?? new DownloadFileHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "version", Utils.ToString(queryParams.Version) }, { "access_token", Utils.ToString(queryParams.AccessTokenField) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "range", Utils.ToString(headers.Range) }, { "boxapi", Utils.ToString(headers.Boxapi) } }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/files/", fileId, "/content"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "binary", auth: this.Auth, networkSession: this.NetworkSession));
            return response.Content;
        }

    }
}