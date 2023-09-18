using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DictionaryExtensions;
using Fetch;
using Serializer;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class StoragePoliciesManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public StoragePoliciesManager() {
            
        }
        public async System.Threading.Tasks.Task<StoragePolicies> GetStoragePolicies(GetStoragePoliciesQueryParamsArg? queryParams = default, GetStoragePoliciesHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetStoragePoliciesQueryParamsArg();
            headers = headers ?? new GetStoragePoliciesHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", Utils.ToString(queryParams.Fields) }, { "marker", Utils.ToString(queryParams.Marker) }, { "limit", Utils.ToString(queryParams.Limit) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/storage_policies"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<StoragePolicies>(response.Text);
        }

        public async System.Threading.Tasks.Task<StoragePolicy> GetStoragePolicyById(string storagePolicyId, GetStoragePolicyByIdHeadersArg? headers = default) {
            headers = headers ?? new GetStoragePolicyByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/storage_policies/", storagePolicyId), new FetchOptions(method: "GET", headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<StoragePolicy>(response.Text);
        }

    }
}