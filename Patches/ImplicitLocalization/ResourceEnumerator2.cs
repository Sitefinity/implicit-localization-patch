using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public class ResourceEnumerator2 : IDictionaryEnumerator, IEnumerator
    {
        public DictionaryEntry Entry
        {
            get { throw new NotImplementedException(); }
        }

        public object Key
        {
            get { throw new NotImplementedException(); }
        }

        public object Value
        {
            get { throw new NotImplementedException(); }
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
    }
}