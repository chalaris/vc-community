namespace VirtoCommerce.Web.ApiClient.DataContracts.Catalogs
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [CollectionDataContract(Name = "Items", ItemName = "item", Namespace = Constants.DataContractNamespaces.Default)]
    public class ItemList : List<ItemResponse>, IExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the structure that contains extra data.
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
