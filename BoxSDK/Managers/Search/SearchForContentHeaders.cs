using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class SearchForContentHeaders {
        /// <summary>
        /// Extra headers that will be included in the HTTP request.
        /// </summary>
        public Dictionary<string, string?> ExtraHeaders { get; set; } = new Dictionary<string, string?>() {  };

        public SearchForContentHeaders() {
            
        }
    }
}