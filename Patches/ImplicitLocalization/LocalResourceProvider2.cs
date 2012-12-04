using System;
using System.Collections;
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
        /// <param name="virtualPath"></param>
        public LocalResourceProvider2(string virtualPath)
        {
            
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an object to read resource values from a source.
        /// </summary>
        /// <returns>The <see cref="T:System.Resources.IResourceReader" /> associated with
        /// the current resource provider.</returns>
        /// <value></value>
        public IResourceReader ResourceReader
        {
            get 
            { 
                throw new NotImplementedException(); 
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
    }
}