using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public interface ITrashedItemsManager {
        public IAuthentication? Auth { get; set; }

        public NetworkSession NetworkSession { get; set; }

        public System.Threading.Tasks.Task<Items> GetTrashedItemsAsync(GetTrashedItemsQueryParams? queryParams = default, GetTrashedItemsHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null);

    }
}