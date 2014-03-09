using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Commerce.Api.Controllers
{
    using System.Linq.Expressions;
    using System.Web.Http.OData.Query;

    using VirtoCommerce.Foundation.Catalogs.Model;
    using VirtoCommerce.Foundation.Data.Catalogs;
    using VirtoCommerce.Web.ApiClient.DataContracts;
    using VirtoCommerce.Web.ApiClient.DataContracts.Catalogs;

    public class ItemsController : ApiController
    {
        private EFCatalogRepository _repository = new EFCatalogRepository("VirtoCommerce");
        public static List<ItemResponse> items;

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Item, ItemResponse>> AsItemResponse =
            x => new ItemResponse
            {
                ItemId = x.ItemId,
                Name = x.Name,
                IsActive = x.IsActive
            };

        static ItemsController()
        {
        }        

        [HttpGet]
        public QueryResult<ItemResponse> GetItemsList(int skip = 0, int take = 10, string sortProperty = "", string sortDirection = "", string filter = "")
        {
            var list = _repository.Items.Take(100).Select(AsItemResponse).ToList();
            var result = new QueryResult<ItemResponse> { items = list };
            return result;
        }

        /* THIS METHOD ALLOWS TO QUERY UNDERLYING MODEL
        public IQueryable<ItemResponse> GetItemsList(ODataQueryOptions<Item> odataQuery)
        {
            var items = odataQuery.ApplyTo(_repository.Items.Take(5)).OfType<Item>();
            return items.Select(AsItemResponse);
        }
         * */

        [HttpPut]
        public void UpdateItem(ItemResponse item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Item cannot be null");
            }

            var prod = (from p in items where p.ItemId == item.ItemId select p).FirstOrDefault();

            if (prod != null)
            {
                prod.ItemId = item.ItemId;
                prod.Name = item.Name;
                prod.StartDate = item.StartDate;
            }
        }

        [HttpPost]
        public void AddItem(ItemResponse item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Item cannot be null");
            }

            items.Add(new ItemResponse
            {
                ItemId = items.Count.ToString(),
                Name = item.Name
            });
        }  
    }
}