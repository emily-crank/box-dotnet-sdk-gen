using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using StringExtensions;
using DictionaryExtensions;
using Serializer;
using Fetch;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen;

namespace Box.Sdk.Gen.Managers {
    public class TrashedWebLinksManager : ITrashedWebLinksManager {
        public IAuthentication? Auth { get; set; } = default;

        public NetworkSession NetworkSession { get; set; }

        public TrashedWebLinksManager(NetworkSession networkSession = default) {
            NetworkSession = networkSession ?? new NetworkSession();
        }
        /// <summary>
        /// Restores a web link that has been moved to the trash.
        /// 
        /// An optional new parent ID can be provided to restore the  web link to in case
        /// the original folder has been deleted.
        /// </summary>
        /// <param name="webLinkId">
        /// The ID of the web link.
        /// Example: "12345"
        /// </param>
        /// <param name="requestBody">
        /// Request body of restoreWeblinkFromTrash method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of restoreWeblinkFromTrash method
        /// </param>
        /// <param name="headers">
        /// Headers of restoreWeblinkFromTrash method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<TrashWebLinkRestored> RestoreWeblinkFromTrashAsync(string webLinkId, RestoreWeblinkFromTrashRequestBody? requestBody = default, RestoreWeblinkFromTrashQueryParams? queryParams = default, RestoreWeblinkFromTrashHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            requestBody = requestBody ?? new RestoreWeblinkFromTrashRequestBody();
            queryParams = queryParams ?? new RestoreWeblinkFromTrashQueryParams();
            headers = headers ?? new RestoreWeblinkFromTrashHeaders();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/2.0/web_links/", StringUtils.ToStringRepresentation(webLinkId)), new FetchOptions(method: "POST", parameters: queryParamsMap, headers: headersMap, data: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<TrashWebLinkRestored>(response.Data);
        }

        /// <summary>
        /// Retrieves a web link that has been moved to the trash.
        /// </summary>
        /// <param name="webLinkId">
        /// The ID of the web link.
        /// Example: "12345"
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of getTrashedWebLinkById method
        /// </param>
        /// <param name="headers">
        /// Headers of getTrashedWebLinkById method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<TrashWebLink> GetTrashedWebLinkByIdAsync(string webLinkId, GetTrashedWebLinkByIdQueryParams? queryParams = default, GetTrashedWebLinkByIdHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            queryParams = queryParams ?? new GetTrashedWebLinkByIdQueryParams();
            headers = headers ?? new GetTrashedWebLinkByIdHeaders();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/2.0/web_links/", StringUtils.ToStringRepresentation(webLinkId), "/trash"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<TrashWebLink>(response.Data);
        }

        /// <summary>
        /// Permanently deletes a web link that is in the trash.
        /// This action cannot be undone.
        /// </summary>
        /// <param name="webLinkId">
        /// The ID of the web link.
        /// Example: "12345"
        /// </param>
        /// <param name="headers">
        /// Headers of deleteTrashedWebLinkById method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task DeleteTrashedWebLinkByIdAsync(string webLinkId, DeleteTrashedWebLinkByIdHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            headers = headers ?? new DeleteTrashedWebLinkByIdHeaders();
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/2.0/web_links/", StringUtils.ToStringRepresentation(webLinkId), "/trash"), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
        }

    }
}