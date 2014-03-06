﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtoCommerce.Foundation.Search.Model;
using System.Runtime.Serialization;

namespace VirtoCommerce.Foundation.Search
{
    public interface ISearchCriteria
    {
        string DocumentType { get; }
        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <value>The cache key.</value>
        string CacheKey { get; }

        /// <summary>
        /// Gets or sets the starting record.
        /// </summary>
        /// <value>The starting record.</value>
        int StartingRecord { get; set; }

        /// <summary>
        /// Gets or sets the records to retrieve.
        /// </summary>
        /// <value>The records to retrieve.</value>
        int RecordsToRetrieve { get; set; }

        /// <summary>
        /// Gets the sorts.
        /// </summary>
        /// <value>The sorts.</value>
        SearchSort Sort { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        /// <value>The locale.</value>
        string Locale { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        string Currency { get; set; }

        /// <summary>
        /// Gets the key field.
        /// </summary>
        /// <value>The key field.</value>
        string KeyField { get; }

		/// <summary>
		/// Gets the outline field.
		/// </summary>
		/// <value>The outline field.</value>
		string OutlineField { get; }

        /// <summary>
        /// Gets the browsing outline field.
        /// </summary>
        /// <value>The outline field.</value>
        string BrowsingOutlineField { get; }

        /// <summary>
        /// Gets the filters.
        /// </summary>
        /// <value>The filters.</value>
        ISearchFilter[] Filters { get; }

        /// <summary>
        /// Adds the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        void Add(ISearchFilter filter);

        ISearchFilterValue[] CurrentFilterValues { get; }

        ISearchFilter[] CurrentFilters { get; }

        /// <summary>
        /// Gets the active filter fields.
        /// </summary>
        /// <value>The active filter fields.</value>
        string[] CurrentFilterFields { get; }

        /// <summary>
        /// Adds the specified filter.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        void Add(ISearchFilter filter, ISearchFilterValue value);


    }
}
