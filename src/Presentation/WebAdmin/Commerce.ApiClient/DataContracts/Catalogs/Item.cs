using System;

namespace VirtoCommerce.Web.ApiClient.DataContracts.Catalogs
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = Constants.DataContractNamespaces.Default)]
    public class Item : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public string ItemId {get; set; }

        [DataMember(Order = 2)]
        public string Name {get; set; }

        [DataMember(Order = 3)]
        public DateTime StartDate { get; set; }

        [DataMember(Order = 4)]
        public DateTime? EndDate{get; set; }

        [DataMember(Order = 4)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the extension data.
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
