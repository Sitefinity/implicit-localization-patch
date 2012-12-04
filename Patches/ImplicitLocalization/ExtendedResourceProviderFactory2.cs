using System;
using System.Linq;
using System.Web.Compilation;
using Telerik.Sitefinity.Localization;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    /// <summary>
    /// Factory for creating resource providers.
    /// </summary>
    public class ExtendedResourceProviderFactory2 : ExtendedResourceProviderFactory
    {
        /// <summary>
        /// Creates a local resource provider. 
        /// </summary>
        /// <returns>
        /// An <see cref="System.Web.Compilation.IResourceProvider" />.
        /// </returns>
        /// <param name="virtualPath">
        /// The path to a resource file.
        /// </param>
        public override IResourceProvider CreateLocalResourceProvider(string virtualPath)
        {
            if (string.IsNullOrEmpty(virtualPath))
                throw new ArgumentNullException("virtualPath");

            return new LocalResourceProvider2(virtualPath);
        }
    }
}