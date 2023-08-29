using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DictionaryExtensions;
using Fetch;
using Serializer;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CommentsManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public CommentsManager() {
            
        }
        public async System.Threading.Tasks.Task<Comments> GetFileComments(string fileId, GetFileCommentsQueryParamsArg? queryParams = default, GetFileCommentsHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetFileCommentsQueryParamsArg();
            headers = headers ?? new GetFileCommentsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", Utils.ToString(queryParams.Fields) }, { "limit", Utils.ToString(queryParams.Limit) }, { "offset", Utils.ToString(queryParams.Offset) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/files/", fileId, "/comments"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Comments>(response.Text);
        }

        public async System.Threading.Tasks.Task<CommentFull> GetCommentById(string commentId, GetCommentByIdQueryParamsArg? queryParams = default, GetCommentByIdHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetCommentByIdQueryParamsArg();
            headers = headers ?? new GetCommentByIdHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", Utils.ToString(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/comments/", commentId), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<CommentFull>(response.Text);
        }

        public async System.Threading.Tasks.Task<CommentFull> UpdateCommentById(string commentId, UpdateCommentByIdRequestBodyArg? requestBody = default, UpdateCommentByIdQueryParamsArg? queryParams = default, UpdateCommentByIdHeadersArg? headers = default) {
            requestBody = requestBody ?? new UpdateCommentByIdRequestBodyArg();
            queryParams = queryParams ?? new UpdateCommentByIdQueryParamsArg();
            headers = headers ?? new UpdateCommentByIdHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", Utils.ToString(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/comments/", commentId), new FetchOptions(method: "PUT", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<CommentFull>(response.Text);
        }

        public async System.Threading.Tasks.Task DeleteCommentById(string commentId, DeleteCommentByIdHeadersArg? headers = default) {
            headers = headers ?? new DeleteCommentByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/comments/", commentId), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession));
        }

        public async System.Threading.Tasks.Task<Comment> CreateComment(CreateCommentRequestBodyArg requestBody, CreateCommentQueryParamsArg? queryParams = default, CreateCommentHeadersArg? headers = default) {
            queryParams = queryParams ?? new CreateCommentQueryParamsArg();
            headers = headers ?? new CreateCommentHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", Utils.ToString(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/comments"), new FetchOptions(method: "POST", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Comment>(response.Text);
        }

    }
}