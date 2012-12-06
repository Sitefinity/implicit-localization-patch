using System;
using System.Linq;
using SitefinityWebApp.Patches.ImplicitLocalization;

namespace ImplicitLocalizationPatch.Test
{
    public class ResourceFileResolverMock : IResourceFileResolver
    {
        public ResourceFileResolverMock(string[] resourceFilePaths)
        {
            this.resourceFilePaths = resourceFilePaths;
        }

        public string[] ResolveResourceFilePaths(string virtualPath)
        {
            return this.resourceFilePaths;
        }

        private string[] resourceFilePaths;
    }
}
