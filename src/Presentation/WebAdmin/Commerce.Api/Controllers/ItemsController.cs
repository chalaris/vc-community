using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Commerce.Api.Controllers
{
    using VirtoCommerce.Foundation.Data.Catalogs;
    using VirtoCommerce.Web.ApiClient.DataContracts;
    using VirtoCommerce.Web.ApiClient.DataContracts.Catalogs;

    public class ItemsController : ApiController
    {
        private EFCatalogRepository _repository = new EFCatalogRepository("VirtoCommerce");
        public static List<Item> items;

        static ItemsController()
        {
            items = new List<Item>();
            items.Add(new Item { ItemId = "0", Name = "XBOX"});
            items.Add(new Item { ItemId = "1", Name = "Surface" });
            items.Add(new Item { ItemId = "3", Name = "Kinect" });
        }        

        [HttpGet]
        public QueryResult<Item> GetItemsList()
        {
            var list = _repository.Items.Take(100).Select(x => new Item() { ItemId = x.ItemId, Name = x.Name }).ToList();
            var result = new QueryResult<Item> { items = list };
            return result;
        }

        [HttpPut]
        public void UpdateItem(Item item)
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
        public void AddItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Item cannot be null");
            }

            items.Add(new Item
            {
                ItemId = items.Count.ToString(),
                Name = item.Name
            });
        }  

        /*
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
         * */
    }
}