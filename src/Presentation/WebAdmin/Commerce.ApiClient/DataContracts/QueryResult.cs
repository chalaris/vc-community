using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Web.ApiClient.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Model for query result, including total count
    /// </summary>
    /// <typeparam name="TResult">The type of items returned for the query.</typeparam>
    [DataContract(Namespace = "http://schemas.virtocommerce.com/1.0")]
    public class QueryResult<TResult>
    {
        /// <summary>
        /// Gets or sets the list of items returned by a query.
        /// </summary>
        [DataMember]
        public IList<TResult> items { get; set; }

        /// <summary>
        /// Gets or sets the total count of items, before paging is applied, after filtering is applied.
        /// </summary>
        [DataMember]
        public int? filteredTotalCount { get; set; }

        /// <summary>
        /// Gets or sets the total count of items, before paging and filtering is applied.
        /// </summary>
        [DataMember]
        public int? totalCount { get; set; }
    }
}
