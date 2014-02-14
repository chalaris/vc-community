using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Web.CommerceManager.Common
{
    using System.Web.Mvc;
    using System.Web;
    using System.Web.Script.Serialization;

    public class JsonResultWithMaxJsonLimits : JsonResult
    {
        public JsonResultWithMaxJsonLimits()
        {
            this.MaxJsonLength = 0x200000;
            this.RecursionLimit = 100;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if ((this.JsonRequestBehavior == JsonRequestBehavior.DenyGet) && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            var response = context.HttpContext.Response;

            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data != null)
            {
                var serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = this.MaxJsonLength.Value;
                serializer.RecursionLimit = this.RecursionLimit.Value;
                response.Write(serializer.Serialize(this.Data));
            }
        }
    }
}
