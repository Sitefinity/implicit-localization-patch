using System;
using System.Collections;
using System.Linq;
using System.Resources;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public class LocalResourceReader2 : IResourceReader
    {
        #region IResourceReader members

        /// <summary>
        /// Closes the resource reader after releasing any resources associated
        /// with it.
        /// </summary>
        public void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an <see cref="T:System.Collections.IDictionaryEnumerator" />
        /// of the resources for this reader.
        /// </summary>
        /// <returns>A dictionary enumerator for the resources for this reader.</returns>
        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be
        /// used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}