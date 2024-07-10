using Box.Sdk.Gen;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen.Internal;

namespace Box.Sdk.Gen.Managers {
    public class UploadFileVersionRequestBody {
        /// <summary>
        /// The additional attributes of the file being uploaded. Mainly the
        /// name and the parent folder. These attributes are part of the multi
        /// part request body and are in JSON format.
        /// 
        /// <Message warning>
        /// 
        ///   The `attributes` part of the body must come **before** the
        ///   `file` part. Requests that do not follow this format when
        ///   uploading the file will receive a HTTP `400` error with a
        ///   `metadata_after_file_contents` error code.
        /// 
        /// </Message>
        /// </summary>
        public UploadFileVersionRequestBodyAttributesField Attributes { get; }

        /// <summary>
        /// The content of the file to upload to Box.
        /// 
        /// <Message warning>
        /// 
        ///   The `attributes` part of the body must come **before** the
        ///   `file` part. Requests that do not follow this format when
        ///   uploading the file will receive a HTTP `400` error with a
        ///   `metadata_after_file_contents` error code.
        /// 
        /// </Message>
        /// </summary>
        public System.IO.Stream File { get; }

        public string? FileFileName { get; init; }

        public string? FileContentType { get; init; }

        public UploadFileVersionRequestBody(UploadFileVersionRequestBodyAttributesField attributes, System.IO.Stream file) {
            Attributes = attributes;
            File = file;
        }
    }
}