using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dynamic.core;
using System.Linq;
using Microsoft.CSharp;
using Extensions;
using System.Diagnostics;

namespace tests
{
    [TestClass]
    public class MockDataTests
    {
        [TestMethod]
        public void TestSeekOnDynamicList()
        {
            var lst = MockData.GetList();
            Assert.IsNotNull(lst);
            Assert.IsTrue(lst.Count > 0);
            string errorMessage = null;
            object din = null;

            try
            {
                din = MockData.GetElementById(lst, 1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            Assert.IsNull(errorMessage);
            Assert.IsNotNull(din);
        }

        [TestMethod]
        public void TestReproveSeekOnDynamicList()
        {
            var lst = MockData.GetList();
            Assert.IsNotNull(lst);
            Assert.IsTrue(lst.Count > 0);
            string errorMessage = null;
            object din = null;

            try
            {
                din = lst.Where(obj => obj.Id == 1).FirstOrDefault();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            Assert.IsNotNull(errorMessage);
            Assert.IsNull(din);
        }

        [TestMethod]
        public void TestSeekFromAnotherProject()
        {
            var lst = MockData.GetList();
            Assert.IsNotNull(lst);
            Assert.IsTrue(lst.Count > 0);
            string errorMessage = null;
            object din = null;

            try
            {
                din = lst.GetValueFromDynamicList("Id", "Name", "1");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            Assert.IsNull(errorMessage);
            Assert.IsNotNull(din);
            Trace.Write(din.ToString());
        }
    }
}
