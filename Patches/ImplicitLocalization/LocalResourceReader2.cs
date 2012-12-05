using System;
using System.Collections;
using System.Linq;
using System.Resources;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public class LocalResourceReader2 : IResourceReader
    {
        #region Construction

        public LocalResourceReader2(string[] resourceFilePaths)
            : this(resourceFilePaths, new KeyFormatter())
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="LocalResourceReader2"/>.
        /// </summary>
        /// <param name="resourceFilePaths">
        /// The array of resource file paths that should be read.
        /// </param>
        public LocalResourceReader2(string[] resourceFilePaths, IKeyFormatter keyFormatter)
        {
            if (resourceFilePaths == null)
                throw new ArgumentNullException("resourceFilePaths");

            if (resourceFilePaths.Length == 0)
                throw new ArgumentException("At least one resource file path must be passed.");

            if (keyFormatter == null)
                throw new ArgumentNullException("keyFormatter");

            this.keyFormatter = keyFormatter;
            this.resourceFilePaths = resourceFilePaths;
        }

        #endregion

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
            return new ResourceEnumerator2(this.resourceFilePaths, this.keyFormatter);
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

        #region Private fields and constants

        private string[] resourceFilePaths;
        private IKeyFormatter keyFormatter;

        #endregion
    }
}