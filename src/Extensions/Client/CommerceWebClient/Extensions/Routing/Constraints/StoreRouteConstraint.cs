﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VirtoCommerce.Client;
using VirtoCommerce.Foundation.AppConfig.Model;
using VirtoCommerce.Web.Client.Helpers;

namespace VirtoCommerce.Web.Client.Extensions.Routing.Constraints
{

    /// <summary>
    /// Route constraint checks if store exists in database
    /// </summary>
    public class StoreRouteConstraint : BaseRouteConstraint
    {
        /// <summary>
        /// Gets the catalog client.
        /// </summary>
        /// <value>The catalog client.</value>
        private StoreClient StoreClient
        {
            get { return DependencyResolver.Current.GetService<StoreClient>(); }
        }

        protected override bool IsMatch(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {

            if (routeDirection == RouteDirection.UrlGeneration)
            {
                return true;
            }

            if (!base.IsMatch(httpContext, route, parameterName, values, routeDirection))
            {
                return false;
            }

            var encoded = values[parameterName].ToString();
            var decoded = SettingsHelper.SeoDecode(encoded, SeoUrlKeywordTypes.Store, values.ContainsKey(Constants.Language) ? values[Constants.Language] as string : null);
            var dbStore = StoreClient.GetStoreById(decoded);

            if (dbStore == null)
            {
                return false;
            }

            if (values.ContainsKey(Constants.Language))
            {
                try
                {
                    var culture = CultureInfo.CreateSpecificCulture(values[Constants.Language].ToString());
                    if (!dbStore.Languages.Any(l => l.LanguageCode.Equals(culture.Name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        //Store does not support this language
                        return false;
                    }
                }
                catch
                {
                    //Language is not valid
                    return false;
                }
            }

            return true;
        }
    }
}
