using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtoCommerce.Web.CommerceManager.Controllers.Mocks
{
    using VirtoCommerce.Web.CommerceManager.Models;

    public class CatalogServiceMock
    {
        private List<ListItemModel> _Items;

        public CatalogServiceMock()
        {
            _Items = new List<ListItemModel>();
            for (int index = 1; index < 100; index++)
            {
                _Items.Add(new ListItemModel() { Name = String.Format("Product A #{0}", index), ItemId = index.ToString(), AvailableFrom = DateTime.Now, ExpiresOn = DateTime.Now.AddDays(5)});
            }
            
        }

        public ListItemModel[] GetItems(string outline, int count, int startingRecordIndex)
        {
            return _Items.AsQueryable().Skip(startingRecordIndex).Take(count).ToArray();
        }
        //public ItemListModel
    }
}