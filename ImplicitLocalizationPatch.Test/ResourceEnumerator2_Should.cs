using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitefinityWebApp.Patches.ImplicitLocalization;

namespace ImplicitLocalizationPatch.Test
{
    [TestClass]
    public class ResourceEnumerator2_Should
    {
        [TestMethod]
        public void ThrownAnException_WhenConstructedWithResourceFilePathsArgumentBeingNull()
        {
            try
            {
                new ResourceEnumerator2(null);
                Assert.Fail("ArgumentNullException should have been thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("resourceFilePaths", ex.ParamName);
            }
        }

        [TestMethod]
        public void ThrowAnException_WhenConstructedWithEmptyArrayOfResourceFilePaths()
        {
            try
            {
                new ResourceEnumerator2(new string[0]);
                Assert.Fail("ArgumentException should have been thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("At least one resource file path must be passed.", ex.Message);
            }
        }

        [TestMethod]
        public void ReturnDictionaryEntryWithCurrentKeyAndValue_WhenEntryPropertyGetterIsInvoked()
        {
            string[] paths = new string[] { "/file1" };
            var resEnumerator = new ResourceEnumerator2(paths);

            var keyFieldValue = "Key1";
            var valueFieldValue = "Value1";

            FieldInfo keyField = resEnumerator.GetType().GetField("key", BindingFlags.Instance | BindingFlags.NonPublic);
            keyField.SetValue(resEnumerator, keyFieldValue);

            FieldInfo valueField = resEnumerator.GetType().GetField("value", BindingFlags.Instance | BindingFlags.NonPublic);
            valueField.SetValue(resEnumerator, valueFieldValue);

            var entry = resEnumerator.Entry;
            Assert.AreEqual(entry.Key, keyFieldValue);
            Assert.AreEqual(entry.Value, valueFieldValue);
        }

        [TestMethod]
        public void ReturnKeyField_WhenKeyPropertyGetterIsInvoked()
        {
            string[] paths = new string[] { "/file1" };
            var resEnumerator = new ResourceEnumerator2(paths);

            var fieldValue = "Key1";
            FieldInfo keyField = resEnumerator.GetType().GetField("key", BindingFlags.Instance | BindingFlags.NonPublic);
            keyField.SetValue(resEnumerator, fieldValue);

            Assert.AreEqual(fieldValue, resEnumerator.Key);
        }

        [TestMethod]
        public void ReturnValueField_WhenValuePropertyGetterIsInvoked()
        {
            string[] paths = new string[] { "/file1" };
            var resEnumerator = new ResourceEnumerator2(paths);

            var fieldValue = "Value1";
            FieldInfo valueField = resEnumerator.GetType().GetField("value", BindingFlags.Instance | BindingFlags.NonPublic);
            valueField.SetValue(resEnumerator, fieldValue);

            Assert.AreEqual(fieldValue, resEnumerator.Value);
        }

        [TestMethod]
        public void ReturnCurrentDictionaryEntry_WhenCurrentPropertyGetterIsInvoked()
        {
            string[] paths = new string[] { "/file1" };
            var resEnumerator = new ResourceEnumerator2(paths);

            var keyFieldValue = "Key1";
            var valueFieldValue = "Value1";

            FieldInfo keyField = resEnumerator.GetType().GetField("key", BindingFlags.Instance | BindingFlags.NonPublic);
            keyField.SetValue(resEnumerator, keyFieldValue);

            FieldInfo valueField = resEnumerator.GetType().GetField("value", BindingFlags.Instance | BindingFlags.NonPublic);
            valueField.SetValue(resEnumerator, valueFieldValue);

            var entry = (DictionaryEntry)resEnumerator.Current;
            Assert.AreEqual(entry.Key, keyFieldValue);
            Assert.AreEqual(entry.Value, valueFieldValue);
        }

        [TestMethod]
        [DeploymentItem("Page1.aspx.resx")]
        public void ReadTheEntriesFromTheResourceFile_WhenFileExist()
        {
            var resEnumerator = new ResourceEnumerator2(new string[] { "Page1.aspx.resx" });

            // make sure first entry exists
            Assert.IsTrue(resEnumerator.MoveNext());
            Assert.AreEqual("Label2.Text", resEnumerator.Entry.Key);
            Assert.AreEqual("Hello universe!", resEnumerator.Entry.Value);

            // make sure second entry exists
            Assert.IsTrue(resEnumerator.MoveNext());
            Assert.AreEqual("Literal1.Text", resEnumerator.Entry.Key);
            Assert.AreEqual("Hello world!", resEnumerator.Entry.Value);

            // make sure there is no thrid entry
            Assert.IsFalse(resEnumerator.MoveNext());
        }

    }
}
