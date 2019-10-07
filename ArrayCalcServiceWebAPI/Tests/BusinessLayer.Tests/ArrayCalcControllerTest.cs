
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLayer.Tests
{
    [TestClass]
    public class ArrayCalcControllerTest
    {
        private IArrayCalcRepoService arrayCalcRepoService;

        [TestInitialize]
        public void TestInit()
        {
            arrayCalcRepoService = new ArrayCalcRepoService();

        }
        [TestMethod]
        public void Reverse_HappyPath()
        {
            int[] inputProductIds = new int[] { 1, 2, 3, 4, 5 };
            int[] returnProductIds = new int[] { 5, 4, 3, 2, 1 };

            int[] returValue = arrayCalcRepoService.Reverse(inputProductIds);
            CollectionAssert.AreEqual(returnProductIds, returValue);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Reverse_NullInput()
        {
            
            int[] inputProductIds = null;
            var returValue = arrayCalcRepoService.Reverse(inputProductIds);

        }


      }
}
