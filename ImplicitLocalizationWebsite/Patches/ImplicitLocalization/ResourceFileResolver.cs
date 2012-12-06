using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public class ResourceFileResolver : IResourceFileResolver
    {
        public string[] ResolveResourceFilePaths(string virtualPath)
        {
            string fileName = VirtualPathUtility.GetFileName(virtualPath);
            string path = VirtualPathUtility.GetDirectory(virtualPath);
            path += "App_LocalResources/";
            return Directory.GetFiles(HostingEnvironment.MapPath(path), String.Concat(fileName, "*.resx"));
        }
    }
}