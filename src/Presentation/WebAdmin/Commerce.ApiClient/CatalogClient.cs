using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Web.ApiClient
{
    using System.Net.Http;

    using VirtoCommerce.Web.ApiClient.DataContracts;
    using VirtoCommerce.Web.ApiClient.DataContracts.Catalogs;
    using VirtoCommerce.Web.ApiClient.Utilities;

    public class CatalogClient : BaseClient, ICatalogClient
    {
        protected class RelativePaths
        {
            public const string Items = "items";
        }

        //public const string AdminItems = RegisteredPath + "/products";

        /// <summary>
        /// Initializes a new instance of the AdminManagementClient class.
        /// </summary>
        /// <param name="adminBaseEndpoint">Admin endpoint</param>
        /// <param name="token">Access token</param>
        public CatalogClient(Uri adminBaseEndpoint, string token)
            : base(adminBaseEndpoint, new TokenMessageProcessingHandler(token))
        {
        }

        /// <summary>
        /// Initializes a new instance of the AdminManagementClient class.
        /// </summary>
        /// <param name="adminBaseEndpoint">Admin endpoint</param>
        /// <param name="token">Access token</param>
        public CatalogClient(Uri adminBaseEndpoint, MessageProcessingHandler handler)
            : base(adminBaseEndpoint, handler)
        {
            
        }

        /// <summary>
        /// List items matching the given query
        /// </summary>
        public Task<QueryResult<ItemResponse>> ListItemsAsync(Query query)
        {
            return this.GetAsync<QueryResult<ItemResponse>>(this.CreateRequestUri(RelativePaths.Items, query.GetQueryString()));
        }

    }

    public interface ICatalogClient
    {
    }
}
