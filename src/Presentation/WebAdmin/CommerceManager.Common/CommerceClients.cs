namespace VirtoCommerce
{
    /// <summary>
    /// The CloudClients class provides a common location for service client
    /// discovery.  It can be accessed via CommerceContext.Clients.  The
    /// VirtoCommerce namespace should be imported when used because
    /// CommerceClients is intended to be the target of extension methods by each
    /// service client.
    /// </summary>
    /// <remarks>
    /// All service client libraries should add CreateXYZClient() extension
    /// methods on static classes declared in the VirtoCommerce
    /// namespace.  This will allow any library loaded in a project to be
    /// easily discovered via CommerceContext.Clients without developers having to
    /// figure out which namespaces to import, etc.  You may also add extension
    /// methods that create 
    /// <para/>
    /// This class is used as a static class (internal constructor) but not declared
    /// as such so it can be the target of extension methods.
    /// </remarks>
    public sealed class CommerceClients
    {
        /// <summary>
        /// Initializes a new instance of the CommerceClients class.
        /// </summary>
        internal CommerceClients()
        {
        }
    }
}
