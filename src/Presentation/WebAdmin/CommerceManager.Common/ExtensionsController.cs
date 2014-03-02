using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Web.CommerceManager.Common
{
    using System.Web.Configuration;
    using System.Web.Mvc;

    public abstract class ExtensionController : AsyncController
    {
        private const string TAGHEADER = "x-vc-tag";

        /// <summary>
        /// Gets or sets an arbitrary value used to exchange information
        /// between the client and the server.
        /// </summary>
        protected string Tag
        {
            get
            {
                if (this.Response.Headers[TAGHEADER] != null)
                {
                    return this.Response.Headers[TAGHEADER];
                }
                else if (this.Request.Headers[TAGHEADER] != null)
                {
                    return this.Request.Headers[TAGHEADER];
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                this.Response.Headers[TAGHEADER] = value;
            }
        }

        /// <summary>Converts data to a data set and returns it as Json</summary>
        /// <param name="data">Data to placed in the data set</param>
        /// <param name="namePropertyName">Name of the name property used for data merging</param>
        /// <param name="pollingInterval">How long the data should be considered valid for when polling at normal speed</param>
        /// <param name="fastPollingInterval">How long the data should be considered valid for when polling at increased speed</param>
        /// <param name="isComplete">Indicates whether the data set is complete or partial</param>
        /// <returns>JSON</returns>
        protected JsonResult JsonDataSet(object data, string namePropertyName = null, TimeSpan? pollingInterval = null, TimeSpan? fastPollingInterval = null, bool isComplete = true)
        {
            return this.Json(new PortalDataSet(data, namePropertyName, pollingInterval, fastPollingInterval, isComplete: isComplete), JsonRequestBehavior.AllowGet); // TODO: change to port behaviour
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return this.Json(data, contentType, contentEncoding, /*JsonRequestBehavior.DenyGet*/ JsonRequestBehavior.AllowGet); // TODO: change to port behaviour
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            var configSection = JavaScriptSerializerExtensions.GetScriptingJsonSerializationSection();
            return new JsonResultWithMaxJsonLimits { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior, MaxJsonLength = configSection.MaxJsonLength, RecursionLimit = configSection.RecursionLimit };
        }
    }
}
