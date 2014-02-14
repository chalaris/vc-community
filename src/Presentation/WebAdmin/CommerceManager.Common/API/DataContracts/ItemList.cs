using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Web.CommerceManager.Common.DataContracts
{
    using System.Runtime.Serialization;

    using VirtoCommerce.Web.CommerceManager.Common.API;

    [CollectionDataContract(Name = "Products", ItemName = "Product", Namespace = Constants.DataContractNamespaces.Default)]
    public class ItemList
    {
        /// <summary>
        /// Gets or sets the structure that contains extra data.
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
