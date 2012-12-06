using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitefinityWebApp.Patches.ImplicitLocalization;

namespace ImplicitLocalizationPatch.Test
{
    [TestClass]
    public class LocalResourceProvider2_Should
    {
        [TestMethod]
        public void ThrowAnException_WhenClassIsConstructedWithoutAVirtualPath()
        {
            try
            {
                var resourceProvider = new LocalResourceProvider2(null);
                Assert.Fail("ArgumentNullException was supposed to be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("virtualPath", ex.ParamName);
            }
        }

        [TestMethod]
        public void AssignVirtualPathToPrivateField_WhenClassIsConstructed()
        {
            string virtualPath = "~/page.aspx";
            var resourceProvider = new LocalResourceProvider2(virtualPath);

            var fieldInfo = resourceProvider.GetType().GetField("virtualPath", BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldValue = fieldInfo.GetValue(resourceProvider);
            Assert.AreEqual(virtualPath, fieldValue.ToString());
        }

        [TestMethod]
        public void AssignResolverFieldToDefaultResolver_WhenConstructorWithoutResolverHasBeenCalled()
        {
            string virtualPath = "~/page.aspx";
            var resourceProvider = new LocalResourceProvider2(virtualPath);

            var fieldInfo = resourceProvider.GetType().GetField("resourceFileResolver", BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldValue = fieldInfo.GetValue(resourceProvider);

            Assert.IsNotNull(fieldValue);
            Assert.IsInstanceOfType(fieldValue, typeof(ResourceFileResolver));
        }

        [TestMethod]
        public void ThrowAnException_WhenGetObjectIsCalledWithNoKeySpecified()
        {
            var resourceProvider = new LocalResourceProvider2("~/Page1.aspx");
            try
            {
                resourceProvider.GetObject(string.Empty, CultureInfo.InvariantCulture);
                Assert.Fail("ArgumentNullException was supposed to be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("resourceKey", ex.ParamName);
            }
        }

        [TestMethod]
        [DeploymentItem("Page1.aspx.resx")]
        [DeploymentItem("Page1.aspx.bg.resx")]
        [DeploymentItem("Page1.aspx.hr-HR.resx")]
        public void RetrieveTheObjectForTheExistingKeyAndInvariantCulture()
        {
            var resourceFileResolverMock = new ResourceFileResolverMock(new string[]
            {
                "Page1.aspx.resx",
                "Page1.aspx.bg.resx",
                "Page1.aspx.hr-HR.resx"
            });
            var resourceProvider = new LocalResourceProvider2("Page1.aspx", resourceFileResolverMock);
            
            Assert.AreEqual("Hello universe!", resourceProvider.GetObject("Label2.Text", CultureInfo.InvariantCulture));
            Assert.AreEqual("Hello world!", resourceProvider.GetObject("Literal1.Text", CultureInfo.InvariantCulture));
        }

        [TestMethod]
        [DeploymentItem("Page1.aspx.resx")]
        [DeploymentItem("Page1.aspx.bg.resx")]
        [DeploymentItem("Page1.aspx.hr-HR.resx")]
        public void RetrieveTheObjectForExistingKeyAndExistingCulture()
        {
            var resourceFileResolverMock = new ResourceFileResolverMock(new string[]
            {
                "Page1.aspx.resx",
                "Page1.aspx.bg.resx",
                "Page1.aspx.hr-HR.resx"
            });
            var resourceProvider = new LocalResourceProvider2("Page1.aspx", resourceFileResolverMock);

            Assert.AreEqual("Hello universe! HR", resourceProvider.GetObject("Label2.Text", CultureInfo.GetCultureInfo("hr-HR")));
            Assert.AreEqual("Hello world! HR", resourceProvider.GetObject("Literal1.Text", CultureInfo.GetCultureInfo("hr-HR")));
        }

        [TestMethod]
        public void ThrowAnException_WhenGetImplicitResourceKeysIsCalledAndKeyPrefixIsNull()
        {
            var localResourceProvider = new LocalResourceProvider2("~/file");

            try
            {
                localResourceProvider.GetImplicitResourceKeys(null);
                Assert.Fail("ArgumentNullException was supposed to be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("keyPrefix", ex.ParamName);
            }
        }

        [TestMethod]
        public void ReturnOnlyImplicitResourceKeysWithCulturesSetAsFilter_WhenGetImplicitResourcesKeysIsCalled()
        {
            var availableResources = new List<LocalizationEntry>();
            availableResources.Add(new LocalizationEntry()
            {
                Key = "Key1",
                Value = "Val1"
            });

            availableResources.Add(new LocalizationEntry()
            {
                Key = "Label.Key1",
                Value = "Val1"
            });

            availableResources.Add(new LocalizationEntry()
            {
                Key = "Label.Key1",
                Value = "Val2",
                Culture = "de"
            });

            availableResources.Add(new LocalizationEntry()
            {
                Key = "Literal.Key1",
                Value = "Val2",
                Culture = "de"
            });
            
            var locResProvider = new LocalResourceProvider2Wrapper("~/file", availableResources);
            var implicitKeys = locResProvider.GetImplicitResourceKeys("Label") as List<ImplicitResourceKey>;

            Assert.AreEqual(2, implicitKeys.Count);
            
            var key1 = implicitKeys[0];
            Assert.AreEqual("Label", key1.KeyPrefix);
            Assert.AreEqual("Key1", key1.Property);
            Assert.AreEqual("", key1.Filter);

            var key2 = implicitKeys[1];
            Assert.AreEqual("Label", key2.KeyPrefix);
            Assert.AreEqual("Key1", key2.Property);
            Assert.AreEqual("de", key2.Filter);
        }

    }
}
