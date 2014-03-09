using System;

namespace VirtoCommerce.Web.ApiClient.DataContracts.Catalogs
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = Constants.DataContractNamespaces.Default)]
    public class ItemResponse
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
    }
}
