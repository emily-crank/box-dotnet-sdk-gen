using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DictionaryExtensions;
using Fetch;
using Serializer;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class ListCollaborationsManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public ListCollaborationsManager() {
            
        }
        public async System.Threading.Tasks.Task<Collaborations> GetFileCollaborations(string fileId, GetFileCollaborationsQueryParamsArg? queryParams = default, GetFileCollaborationsHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetFileCollaborationsQueryParamsArg();
            headers = headers ?? new GetFileCollaborationsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", Utils.ToString(queryParams.Fields) }, { "limit", Utils.ToString(queryParams.Limit) }, { "marker", Utils.ToString(queryParams.Marker) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/files/", fileId, "/collaborations"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Collaborations>(response.Text);
        }

        public async System.Threading.Tasks.Task<Collaborations> GetFolderCollaborations(string folderId, GetFolderCollaborationsQueryParamsArg? queryParams = default, GetFolderCollaborationsHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetFolderCollaborationsQueryParamsArg();
            headers = headers ?? new GetFolderCollaborationsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", Utils.ToString(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/folders/", folderId, "/collaborations"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Collaborations>(response.Text);
        }

        public async System.Threading.Tasks.Task<Collaborations> GetCollaborations(GetCollaborationsQueryParamsArg queryParams, GetCollaborationsHeadersArg? headers = default) {
            headers = headers ?? new GetCollaborationsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "status", Utils.ToString(queryParams.Status) }, { "fields", Utils.ToString(queryParams.Fields) }, { "offset", Utils.ToString(queryParams.Offset) }, { "limit", Utils.ToString(queryParams.Limit) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/collaborations"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Collaborations>(response.Text);
        }

        public async System.Threading.Tasks.Task<Collaborations> GetGroupCollaborations(string groupId, GetGroupCollaborationsQueryParamsArg? queryParams = default, GetGroupCollaborationsHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetGroupCollaborationsQueryParamsArg();
            headers = headers ?? new GetGroupCollaborationsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "limit", Utils.ToString(queryParams.Limit) }, { "offset", Utils.ToString(queryParams.Offset) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/groups/", groupId, "/collaborations"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Collaborations>(response.Text);
        }

    }
}