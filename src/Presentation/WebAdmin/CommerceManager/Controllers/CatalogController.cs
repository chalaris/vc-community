using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtoCommerce.Web.CommerceManager.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using VirtoCommerce.Web.CommerceManager.Common;
    using VirtoCommerce.Web.CommerceManager.Models;

    public class CatalogController : ExtensionController
    {
        /// <summary>
        /// Gets all Products.
        /// </summary>
        [ActionName("Items")]
        public async Task<JsonResult> GetAllItems()
        {
            try
            {
                var itemModels = new[]
                                     {
                                         new ItemModel() { Name = "Item 1", ItemId = Guid.NewGuid().ToString() },
                                         new ItemModel() { Name = "Item 2", ItemId = Guid.NewGuid().ToString() }
                                     };
                //var productModels = productNames.Select(d => new ProductModel(d)).ToList();
                return this.JsonDataSet(itemModels);
            }
            catch (HttpRequestException)
            {
                // Returns an empty collection if the HTTP request to the API fails 
                return null;
                //return this.JsonDataSet(new ItemList());
            }
        }  
	}
}