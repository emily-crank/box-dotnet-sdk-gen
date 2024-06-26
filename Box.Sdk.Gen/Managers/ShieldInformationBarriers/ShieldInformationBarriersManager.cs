using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Box.Sdk.Gen;
using System.Text.Json.Serialization;
using Serializer;
using DictionaryExtensions;
using StringExtensions;
using Fetch;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Managers {
    public class ShieldInformationBarriersManager : IShieldInformationBarriersManager {
        public IAuthentication? Auth { get; init; }

        public NetworkSession NetworkSession { get; }

        public ShieldInformationBarriersManager(NetworkSession networkSession = default) {
            NetworkSession = networkSession ?? new NetworkSession();
        }
        /// <summary>
        /// Get shield information barrier based on provided ID.
        /// </summary>
        /// <param name="shieldInformationBarrierId">
        /// The ID of the shield information barrier.
        /// Example: "1910967"
        /// </param>
        /// <param name="headers">
        /// Headers of getShieldInformationBarrierById method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<ShieldInformationBarrier> GetShieldInformationBarrierByIdAsync(string shieldInformationBarrierId, GetShieldInformationBarrierByIdHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            headers = headers ?? new GetShieldInformationBarrierByIdHeaders();
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/2.0/shield_information_barriers/", StringUtils.ToStringRepresentation(shieldInformationBarrierId)), new FetchOptions(networkSession: this.NetworkSession) { Method = "GET", Headers = headersMap, ResponseFormat = "json", Auth = this.Auth, CancellationToken = cancellationToken }).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<ShieldInformationBarrier>(response.Data);
        }

        /// <summary>
        /// Change status of shield information barrier with the specified ID.
        /// </summary>
        /// <param name="requestBody">
        /// Request body of updateShieldInformationBarrierStatus method
        /// </param>
        /// <param name="headers">
        /// Headers of updateShieldInformationBarrierStatus method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<ShieldInformationBarrier> UpdateShieldInformationBarrierStatusAsync(UpdateShieldInformationBarrierStatusRequestBody requestBody, UpdateShieldInformationBarrierStatusHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            headers = headers ?? new UpdateShieldInformationBarrierStatusHeaders();
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/2.0/shield_information_barriers/change_status"), new FetchOptions(networkSession: this.NetworkSession) { Method = "POST", Headers = headersMap, Data = SimpleJsonSerializer.Serialize(requestBody), ContentType = "application/json", ResponseFormat = "json", Auth = this.Auth, CancellationToken = cancellationToken }).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<ShieldInformationBarrier>(response.Data);
        }

        /// <summary>
        /// Retrieves a list of shield information barrier objects
        /// for the enterprise of JWT.
        /// </summary>
        /// <param name="queryParams">
        /// Query parameters of getShieldInformationBarriers method
        /// </param>
        /// <param name="headers">
        /// Headers of getShieldInformationBarriers method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<ShieldInformationBarriers> GetShieldInformationBarriersAsync(GetShieldInformationBarriersQueryParams? queryParams = default, GetShieldInformationBarriersHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            queryParams = queryParams ?? new GetShieldInformationBarriersQueryParams();
            headers = headers ?? new GetShieldInformationBarriersHeaders();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "marker", StringUtils.ToStringRepresentation(queryParams.Marker) }, { "limit", StringUtils.ToStringRepresentation(queryParams.Limit) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/2.0/shield_information_barriers"), new FetchOptions(networkSession: this.NetworkSession) { Method = "GET", Parameters = queryParamsMap, Headers = headersMap, ResponseFormat = "json", Auth = this.Auth, CancellationToken = cancellationToken }).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<ShieldInformationBarriers>(response.Data);
        }

        /// <summary>
        /// Creates a shield information barrier to
        /// separate individuals/groups within the same
        /// firm and prevents confidential information passing between them.
        /// </summary>
        /// <param name="requestBody">
        /// Request body of createShieldInformationBarrier method
        /// </param>
        /// <param name="headers">
        /// Headers of createShieldInformationBarrier method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<ShieldInformationBarrier> CreateShieldInformationBarrierAsync(CreateShieldInformationBarrierRequestBody requestBody, CreateShieldInformationBarrierHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            headers = headers ?? new CreateShieldInformationBarrierHeaders();
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/2.0/shield_information_barriers"), new FetchOptions(networkSession: this.NetworkSession) { Method = "POST", Headers = headersMap, Data = SimpleJsonSerializer.Serialize(requestBody), ContentType = "application/json", ResponseFormat = "json", Auth = this.Auth, CancellationToken = cancellationToken }).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<ShieldInformationBarrier>(response.Data);
        }

    }
}