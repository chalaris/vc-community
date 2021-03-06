﻿using System;
using System.Web.Mvc;
using VirtoCommerce.Client.Globalization;
using VirtoCommerce.Web.Client.Helpers;

namespace VirtoCommerce.Web.Client.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Localizes the HTML.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="format">The format.</param>
        /// <returns>localized MvcHtmlString.</returns>
        public static MvcHtmlString LocalizeHtml(this string source, params object[] format)
        {
            return new MvcHtmlString(string.Format(source.Localize((string)null), format));
        }

        /// <summary>
        /// Titles the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public static string Title(this string title)
        {
            return Title(title, "{0} | {1}");
        }

        /// <summary>
        /// Titles the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="formatString">The format string.</param>
        /// <returns></returns>
        public static string Title(this string title, string formatString)
        {
            var storeName = StoreHelper.CustomerSession.StoreName;
            return String.IsNullOrEmpty(storeName) ? title : String.Format(formatString, title, storeName);
        }

    }
}