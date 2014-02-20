using System.Diagnostics.Tracing;
using System.Threading.Tasks;

namespace VirtoCommerce.Slab
{
    public class VCKeywords
    {
        public const int Page = 1;
        public const int DataBase =  2;
        public const int Diagnostic =  4;
        public const int Perf =  8;

        public const string EventSourceName = "VirtoCommerce";
    }


    [EventSource(Name = VCKeywords.EventSourceName)]
    public class VirtoCommerceEventSource : EventSource
    {
        public class Keywords
        {
            public const EventKeywords Page = (EventKeywords)1;
            public const EventKeywords DataBase = (EventKeywords)VCKeywords.DataBase;
            public const EventKeywords Diagnostic = (EventKeywords)VCKeywords.Diagnostic;
            public const EventKeywords Perf = (EventKeywords)VCKeywords.Perf;
        }

        public class Tasks
        {
            public const EventTask Page = (EventTask)1;
            public const EventTask DBQuery = (EventTask)2;
        }

        private static readonly VirtoCommerceEventSource _log = new VirtoCommerceEventSource();
        public static VirtoCommerceEventSource Log { get { return _log; } }

        [Event(1, Message = "Application Failure: {0}, task: {1}", Version = 1,
        Level = EventLevel.Critical, Keywords = Keywords.Diagnostic | Keywords.Page, Task = Tasks.DBQuery)]
        public void TaskFailure(string message, string taskName)
        {
            this.WriteEvent(1, message, taskName);
        }

        [Event(2, Message = "Starting up.", Keywords = Keywords.Diagnostic,
        Level = EventLevel.Informational)]
        public void Startup()
        {
            this.WriteEvent(2);
        }
    }

    [EventSource(Name = VCKeywords.EventSourceName+"-Catalog")]
    public class VirtoCommerceCatalogEventSource : VirtoCommerceEventSource
    {
        private static readonly VirtoCommerceCatalogEventSource _log = new VirtoCommerceCatalogEventSource();
        public static VirtoCommerceCatalogEventSource Log { get { return _log; } }

        [Event(1, Message = "Application Failure: {0}",
        Level = EventLevel.Critical, Keywords = Keywords.Diagnostic)]
        public void Error(string message)
        {
            if (IsEnabled())
            {
                this.WriteEvent(1, message);
            }
        }

        [Event(2, Message = "Starting up.", Keywords = Keywords.Perf, Level = EventLevel.Informational)]
        public void Init()
        {
            this.WriteEvent(2);
        }
    }
}
