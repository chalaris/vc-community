using FunctionalTests.TestHelpers;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Utility;
using VirtoCommerce.Slab;
using Xunit;

namespace FunctionalTests.Logging
{
    public class SlabTest : TestBase
    {
        [Fact]
        public void ShouldValidateEventSource()
        {
       //     VirtoCommerceEventSource.Log.Startup();
      //      VirtoCommerceEventSource.Log.Failure("Test exception");
           EventSourceAnalyzer.InspectAll(VirtoCommerceEventSource.Log);
           EventSourceAnalyzer.InspectAll(VirtoCommerceCatalogEventSource.Log);

            
        }

        [Fact]
        public void CustomEventsTest()
        {
            VirtoCommerceEventSource.Log.Startup();
            VirtoCommerceCatalogEventSource.Log.TaskFailure("Catalog crashed somewhere","some query");
        }
    }
}
