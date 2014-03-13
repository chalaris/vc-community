using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtoCommerce.Web.CommerceManager.Models
{
    public partial class ListItemModel
    {
        public string ItemId { get; set; }
        public string Name { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime ExpiresOn { get; set; }
        
        public ListItemModel()
        {
        }
    }
}