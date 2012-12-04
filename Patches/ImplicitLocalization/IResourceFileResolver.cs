using System;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public interface IResourceFileResolver
    {
        string[] ResolveResourceFilePaths(string virtualPath);
    }
}