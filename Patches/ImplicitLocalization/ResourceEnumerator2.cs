using System;
using System.Collections;
using System.Linq;
using System.Xml;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public class ResourceEnumerator2 : IDictionaryEnumerator
    {
        #region Construction

        /// <summary>
        /// Creates a new instance of the <see cref="ResourceEnumerator2"/> type for the
        /// provided resourceFilePaths.
        /// </summary>
        /// <param name="resourceFilePaths"></param>
        public ResourceEnumerator2(string[] resourceFilePaths)
        {
            if (resourceFilePaths == null)
                throw new ArgumentNullException("resourceFilePaths");

            if (resourceFilePaths.Length == 0)
                throw new ArgumentException("At least one resource file path must be passed.");

            this.resourceFilePaths = resourceFilePaths;
        }

        #endregion

        #region IDictionaryEnumerator members

        /// <summary>
        /// Gets both the key and the value of the current dictionary entry.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.DictionaryEntry" /> containing both
        /// the key and the value of the current dictionary entry.</returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.IDictionaryEnumerator" />
        /// is positioned before the first entry of the dictionary or after the last entry.
        /// </exception>
        public DictionaryEntry Entry
        {
            get 
            {
                return new DictionaryEntry(this.key, this.value);
            }
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

        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        /// <returns>The current element in the collection.</returns>
        public object Current
        {
            get 
            {
                return this.Entry;
            }
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The collection was modified
        /// after the enumerator was created. </exception>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element;
        /// false if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (this.xmlReader == null)
                this.xmlReader = XmlReader.Create(this.resourceFilePaths[0]);

            this.key = null;
            this.value = null;

            while (this.xmlReader.Read())
            {
                if (this.xmlReader.NodeType == XmlNodeType.Element && this.xmlReader.Name == "data")
                {
                    this.xmlReader.MoveToAttribute("name");
                    this.key = this.xmlReader.Value;

                    while (this.xmlReader.Read())
                    {
                        if (this.xmlReader.NodeType == XmlNodeType.Element && this.xmlReader.Name == "value")
                        {
                            this.xmlReader.Read();
                            this.value = this.xmlReader.Value;
                        }
                        if (this.xmlReader.NodeType == XmlNodeType.EndElement && this.xmlReader.Name == "data")
                            break;
                    }
                    break;
                }
            }

            if (this.xmlReader.EOF)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            // close the reader; go back to the first file
            throw new NotImplementedException();
        }

        #endregion

        #region Private fields and constants

        private object key;
        private object value;
        private XmlReader xmlReader;
        private string[] resourceFilePaths;

        #endregion 
    }
}