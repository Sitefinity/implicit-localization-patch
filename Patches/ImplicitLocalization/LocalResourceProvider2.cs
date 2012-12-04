using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web.Compilation;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    /// <summary>
    /// Represents implementation of standard ASP.NET local resource provider.
    /// </summary>
    public class LocalResourceProvider2 : IResourceProvider, IImplicitResourceProvider
    {
        #region Construction

        /// <summary>
        /// Creates a new instance of <see cref="LocalResourceProvider2"/> with the
        /// specified virtual path.
        /// </summary>
        /// <param name="virtualPath">
        /// The virtual path of the file for which the local resources should be obtained.
        /// </param>
        public LocalResourceProvider2(string virtualPath)
            : this(virtualPath, new ResourceFileResolver())
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="LocalResourceProvider2"/> with the
        /// specified virtual path and resource file resolver.
        /// </summary>
        /// <param name="virtualPath">
        /// The virtual path of the file for which the local resources should be obtained.
        /// </param>
        /// <param name="resolver">
        /// The instance of the <see cref="IResourceFileResolver"/> which will be used to
        /// resolve resource files associated with the file being represented by the virtual
        /// path argument.
        /// </param>
        public LocalResourceProvider2(string virtualPath, IResourceFileResolver resolver)
        {
            if (string.IsNullOrEmpty(virtualPath))
                throw new ArgumentNullException("virtualPath");

            this.virtualPath = virtualPath;
            this.resourceFileResolver = resolver;
        }

        #endregion

        #region IResourceProvider members

        /// <summary>
        /// Returns a resource object for the key and culture.
        /// </summary>
        /// <param name="resourceKey">The key identifying a particular resource.</param>
        /// <param name="culture">The culture identifying a localized value for the resource.</param>
        /// <returns>
        /// An <see cref="T:System.Object" /> that contains the resource value for
        /// the <paramref name="resourceKey" /> and <paramref name="culture" />.
        /// </returns>
        public object GetObject(string resourceKey, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(resourceKey))
                throw new ArgumentNullException("resourceKey");

            var resourceEnumerator = this.ResourceReader.GetEnumerator();
            while (resourceEnumerator.MoveNext())
            {
                var entry = resourceEnumerator.Entry;
                if(entry.Key.ToString().Equals(resourceKey, StringComparison.InvariantCultureIgnoreCase))
                    return entry.Value;
            }

            return null;
        }

        /// <summary>
        /// Gets an object to read resource values from a source.
        /// </summary>
        /// <returns>The <see cref="T:System.Resources.IResourceReader" /> associated with
        /// the current resource provider.</returns>
        public IResourceReader ResourceReader
        {
            get 
            { 
                var paths = this.resourceFileResolver.ResolveResourceFilePaths(this.virtualPath);
                return new LocalResourceReader2(paths);
            }
        }

        #endregion

        #region IImplicitResourceProvider

        /// <summary>
        /// Gets a collection of implicit resource keys as specified by the prefix.
        /// </summary>
        /// <param name="keyPrefix">The prefix of the implicit resource keys to be collected.</param>
        /// <returns>
        /// An <see cref="T:System.Collections.ICollection" /> of implicit resource
        /// keys.
        /// </returns>
        public ICollection GetImplicitResourceKeys(string keyPrefix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an object representing the value of the specified resource key.
        /// </summary>
        /// <param name="key">The resource key containing the prefix, filter, and property.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> that
        /// represents the culture for which the resource is localized.</param>
        /// <returns>
        /// An <see cref="T:System.Object" /> representing the localized value of
        /// an implicit resource key.
        /// </returns>
        public object GetObject(ImplicitResourceKey key, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private fields and constants

        private string virtualPath;
        private IResourceFileResolver resourceFileResolver;

        #endregion
    }
}