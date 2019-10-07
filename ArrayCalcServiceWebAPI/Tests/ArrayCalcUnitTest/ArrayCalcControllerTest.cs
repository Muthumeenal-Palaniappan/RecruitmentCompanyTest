
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using ArrayCalcServiceWebAPI.Controllers;
using System;
using System.Web.Http;
using System.Web.Http.Results;

namespace ArrayCalcUnitTest
{
    [TestClass]
    public class ArrayCalcControllerTest
    {
        private ArrayCalcRepoService arrayCalcRepoService;
        private Mock<IArrayCalcRepoService> mockArrayCalcRepoService;
        private ArraycalcController arraycalcController;

        [TestInitialize]
        public void TestInit()
        {
             //arrayCalcRepoService = new ArrayCalcRepoService();
             mockArrayCalcRepoService = new Mock<IArrayCalcRepoService>();
            arraycalcController = new ArraycalcController(mockArrayCalcRepoService.Object);

        }
        [TestMethod]
        public void Reverse_HappyPath()
        {
            int[] inputProductIds = new int[] { 1, 2, 3, 4, 5 };
            int[] returnProductIds = new int[] { 5, 4, 3, 2, 1 };

            //mockArrayCalcRepoService.Setup(x => x.Reverse(inputProductIds)).Returns(returnProductIds);
            // int[] returValue = arrayCalcRepoService.Reverse(inputProductIds);
            //CollectionAssert.AreEqual(returnProductIds, returValue);

            mockArrayCalcRepoService.Setup(x => x.Reverse(inputProductIds)).Returns(returnProductIds);
            OkNegotiatedContentResult<int[]> responseMessage = (OkNegotiatedContentResult<int[]>)arraycalcController.Reverse(inputProductIds);
            CollectionAssert.AreEqual(returnProductIds,responseMessage.Content);

        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void Reverse_NullInput()
        {
            
            int[] inputProductIds = null;
            var returValue = arraycalcController.Reverse(inputProductIds);

        }


      }
}
