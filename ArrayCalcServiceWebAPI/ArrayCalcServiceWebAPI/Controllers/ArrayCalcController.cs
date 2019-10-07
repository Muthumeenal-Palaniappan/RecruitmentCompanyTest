using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ArrayCalcServiceWebAPI.Controllers
{
    public class ArraycalcController : ApiController 
    {
        private readonly IArrayCalcRepoService _arrayCalcRepoService;
        public ArraycalcController(IArrayCalcRepoService arrayCalcRepoService)
        {
            _arrayCalcRepoService = arrayCalcRepoService?? throw new ArgumentNullException(nameof(arrayCalcRepoService));
        }
        [System.Web.Http.HttpGet]
        //GET: api/arraycalc/reverse
        public IHttpActionResult Reverse([FromUri] int[] productIds)
        {
                var errorMessage = GetModelStateError(ModelState);
            if (!string.IsNullOrEmpty(errorMessage))
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage));
            if(productIds==null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var reversedArray = _arrayCalcRepoService.Reverse(productIds);
            return Ok(reversedArray);
        }

        [System.Web.Http.HttpGet]
        //GET: api/arraycalc/DeletePart
        public IHttpActionResult DeletePart(int position,[FromUri] int[] productIds)
        {
                var errorMessage = GetModelStateError(ModelState);
                if (!string.IsNullOrEmpty(errorMessage))
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage));
                var returnValue = _arrayCalcRepoService.DeletePart(position, productIds);
                return Ok(returnValue);
        }


        private string GetModelStateError(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var builder = new StringBuilder(string.Empty);
                var errorState = modelState.Where(e => e.Value.Errors.Count > 0).ToList();
                errorState.ForEach(m => builder.Append(" " + m.Key + " : " + m.Value.Errors.First().ErrorMessage ));
                return builder.ToString();
            }
            return null;
        }
    }
}