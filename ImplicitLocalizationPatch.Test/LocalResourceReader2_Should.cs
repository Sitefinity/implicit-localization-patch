using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitefinityWebApp.Patches.ImplicitLocalization;

namespace ImplicitLocalizationPatch.Test
{
    [TestClass]
    public class LocalResourceReader2_Should
    {
        [TestMethod]
        public void ThrowException_WhenInstanceIsConstructedWithResourceFilePathsArgumentBeingNull()
        {
            try
            {
                new LocalResourceReader2(null);
                Assert.Fail("ArgumentNullException was supposed to be thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("resourceFilePaths", ex.ParamName);
            }
        }

        [TestMethod]
        public void ThrowException_WhenInstanceIsConstructedWithResourceFilePathsArgumentsBeingEmptyArray()
        {
            try
            {
                new LocalResourceReader2(new string[0]);
                Assert.Fail("ArgumentException was supposed to be thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("At least one resource file path must be passed.", ex.Message);
            }
        }

        [TestMethod]
        public void AssignResourceFilePathsField_WhenInstanceIsConstructed()
        {
            var filePaths = new string[] { "file1.aspx" };
            var resourceReader = new LocalResourceReader2(filePaths);

            var fieldInfo = resourceReader.GetType().GetField("resourceFilePaths", BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldValue = fieldInfo.GetValue(resourceReader);

            Assert.AreEqual(filePaths, fieldValue);
        }

    }
}
