using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitefinityWebApp.Patches.ImplicitLocalization;

namespace ImplicitLocalizationPatch.Test
{
    [TestClass]
    public class ExtendedResourceProviderFactory2_Should
    {
        [TestMethod]
        public void ThrowAnException_WhenCreateLocalResourceProviderIsCalledWithEmptyArgument()
        {
            var factory = new ExtendedResourceProviderFactory2();
            try
            {
                factory.CreateLocalResourceProvider(null);
                Assert.Fail("ArgumentNullException was not thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("virtualPath", ex.ParamName);
            }
        }

        [TestMethod]
        public void ReturnANewInstanceOfLocalResourceProvider2_WhenCreateLocalResourceProviderIsCalledWithVirtualPathArgument()
        {
            var factory = new ExtendedResourceProviderFactory2();
            var provider = factory.CreateLocalResourceProvider("~/path");

            Assert.IsNotNull(provider);
            Assert.IsInstanceOfType(provider, typeof(LocalResourceProvider2));
        }

    }
}
