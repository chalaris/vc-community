namespace VirtoCommerce.Web.CommerceManager.Common
{
    using System.Web.Configuration;
    using System.Web.Script.Serialization;

    public static class JavaScriptSerializerExtensions
    {
        private static object syncLock = new object();
        private static volatile ScriptingJsonSerializationSection scriptJsonSerializationSection;
        public static ScriptingJsonSerializationSection GetScriptingJsonSerializationSection()
        {
            if (scriptJsonSerializationSection == null)
            {
                lock (syncLock)
                {
                    if (scriptJsonSerializationSection == null)
                    {
                        var webConfiguration = WebConfigurationManager.OpenWebConfiguration("/");

                        // Get the object related to the <system.web.extensions> section
                        scriptJsonSerializationSection = (ScriptingJsonSerializationSection)webConfiguration.GetSection("system.web.extensions/scripting/webServices/jsonSerialization");
                    }
                }
            }

            return scriptJsonSerializationSection;
        }

        public static JavaScriptSerializer CreateJavaScriptSerializer()
        {
            // Create Serializer and initialize it with the right settings
            var configSection = GetScriptingJsonSerializationSection();
            var javascriptSerializer = new JavaScriptSerializer();
            javascriptSerializer.MaxJsonLength = configSection.MaxJsonLength;
            javascriptSerializer.RecursionLimit = configSection.RecursionLimit;

            return javascriptSerializer;
        }
    }
}
