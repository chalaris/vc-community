namespace VirtoCommerce
{
    /// <summary>
    /// The Context class is your primary entry point for getting started
    /// with Virto Commerce client libraries.  Context.Clients contains
    /// helpful methods to create any of the clients currently referenced in
    /// your project (be sure to import the VirtoCommerce namespace so
    /// you import its extension methods).  Context.Configuration allows
    /// you to easily retrieve configuration settings across a variety of 
    /// platform appropriate sources.
    /// </summary>
    /// <remarks>
    /// The Context class is static to make it easier to use, but all
    /// other classes should be instances so they can be targeted by extension
    /// methods given the layered approach of our client libraries.
    /// </remarks>
    public static class Context
    {
        /// <summary>
        /// Initializes static members of the <see cref="Context" /> class.
        /// </summary>
        static Context()
        {
            Clients = new CommerceClients();
            //Configuration = new CommerceConfiguration();
        }

        /// <summary>
        /// Gets an object providing a common location for service client
        /// discovery.  The VirtoCommerce namespace should be imported
        /// when used because CommerceClients is intended to be the target of
        /// extension methods by each service client library.
        /// </summary>
        public static CommerceClients Clients { get; private set; }

        /// <summary>
        /// Gets utilities for easily retrieving configuration settings across
        /// a variety of platform appropriate sources.
        /// </summary>
        //public static CommerceConfiguration Configuration { get; private set; }
    }
}
