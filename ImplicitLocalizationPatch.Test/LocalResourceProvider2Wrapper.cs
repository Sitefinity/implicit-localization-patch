using System;
using System.Collections.Generic;
using System.Linq;
using SitefinityWebApp.Patches.ImplicitLocalization;

namespace ImplicitLocalizationPatch.Test
{
    public class LocalResourceProvider2Wrapper : LocalResourceProvider2
    {
        public LocalResourceProvider2Wrapper(string virtualPath, List<LocalizationEntry> cache)
            : base(virtualPath)
        {
            this.cache = cache;
        }

        protected override List<LocalizationEntry> Cache
        {
            get
            {
                return this.cache;
            }
        }

        private List<LocalizationEntry> cache;
    }
}
