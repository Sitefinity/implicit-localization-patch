using System;
using System.Collections;
using System.Linq;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public class ResourceEnumerator2 : IDictionaryEnumerator
    {
        #region IDictionaryEnumerator members

        public DictionaryEntry Entry
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the key of the current dictionary entry.
        /// </summary>
        /// <returns>The key of the current element of the enumeration.</returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator" />
        /// is positioned before the first entry of the dictionary or after the last entry.
        /// </exception>
        public object Key
        {
            get 
            {
                return this.key;
            }
        }

        /// <summary>
        /// Gets the value of the current dictionary entry.
        /// </summary>
        /// <returns>The value of the current element of the enumeration.</returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator" />
        /// is positioned before the first entry of the dictionary or after the last entry.
        /// </exception>
        public object Value
        {
            get 
            {
                return this.value;
            }
        }

        public object Current
        {
            get { throw new NotImplementedException(); }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private fields and constants

        private object key;
        private object value;

        #endregion 
    }
}