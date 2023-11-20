using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Box;
using Box.Schemas;
using Box.Managers;

namespace Box.Tests.Integration {
    [TestClass]
    public class CommentsManagerTests {
        public BoxClient client { get; }

        public CommentsManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task Comments() {
            const int fileSize = 256;
            string fileName = Utils.GetUUID();
            System.IO.Stream fileByteStream = Utils.GenerateByteStream(size: fileSize);
            const string parentId = "0";
            Files uploadedFiles = await client.Uploads.UploadFileAsync(requestBody: new UploadFileRequestBodyArg(attributes: new UploadFileRequestBodyArgAttributesField(name: fileName, parent: new UploadFileRequestBodyArgAttributesFieldParentField(id: parentId)), file: fileByteStream)).ConfigureAwait(false);
            string fileId = uploadedFiles.Entries![0].Id;
            Comments comments = await client.Comments.GetFileCommentsAsync(fileId: fileId).ConfigureAwait(false);
            Assert.IsTrue(comments.TotalCount == 0);
            const string message = "Hello there!";
            CommentFull newComment = await client.Comments.CreateCommentAsync(requestBody: new CreateCommentRequestBodyArg(message: message, item: new CreateCommentRequestBodyArgItemField(id: fileId, type: CreateCommentRequestBodyArgItemFieldTypeField.File))).ConfigureAwait(false);
            Assert.IsTrue(newComment.Message == message);
            Assert.IsTrue(newComment.IsReplyComment == false);
            Assert.IsTrue(newComment.Item!.Id == fileId);
            CommentFull newReplyComment = await client.Comments.CreateCommentAsync(requestBody: new CreateCommentRequestBodyArg(message: message, item: new CreateCommentRequestBodyArgItemField(id: newComment.Id!, type: CreateCommentRequestBodyArgItemFieldTypeField.Comment))).ConfigureAwait(false);
            Assert.IsTrue(newReplyComment.Message == message);
            Assert.IsTrue(newReplyComment.IsReplyComment == true);
            const string newMessage = "Hi!";
            await client.Comments.UpdateCommentByIdAsync(commentId: newReplyComment.Id!, requestBody: new UpdateCommentByIdRequestBodyArg() { Message = newMessage }).ConfigureAwait(false);
            Comments newComments = await client.Comments.GetFileCommentsAsync(fileId: fileId).ConfigureAwait(false);
            Assert.IsTrue(newComments.TotalCount == 2);
            Assert.IsTrue(newComments.Entries![1].Message == newMessage);
            CommentFull receivedComment = await client.Comments.GetCommentByIdAsync(commentId: newComment.Id!).ConfigureAwait(false);
            Assert.IsTrue(receivedComment.Message! == newComment.Message!);
            await client.Comments.DeleteCommentByIdAsync(commentId: newComment.Id!).ConfigureAwait(false);
            await Assert.That.IsExceptionAsync(async() => await client.Comments.GetCommentByIdAsync(commentId: newComment.Id!).ConfigureAwait(false));
            await client.Files.DeleteFileByIdAsync(fileId: fileId).ConfigureAwait(false);
        }

    }
}