using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ArrayCalcRepoService : IArrayCalcRepoService
    {
        //private readonly IArrayCalcRepoService _arrayCalcRepoService;
        //public ArrayCalcRepoService()
        //{
        //    _arrayCalcRepoService = arrayCalcRepoService;
        //}
        public int[] DeletePart(int position, int[] productIds)
        {
            int[] returnArray = new int[productIds.Length - 1];
            int j = 0;
            for (int i = 0; i <= returnArray.Length; i++)
            {
                if (i != position - 1)
                {
                    returnArray[j] = productIds[i];
                    j++;
                }
            }
            return returnArray;
        }

        public int[] Reverse(int[] productIds)
        {
            if (productIds == null) throw new ArgumentNullException(nameof(productIds));
            int[] reversedArrray = new int[productIds.Length];
            for (int sourceIndex = productIds.Length - 1, destIndex = 0; sourceIndex >= 0; sourceIndex--, destIndex++)
                reversedArrray[destIndex] = productIds[sourceIndex];

            return reversedArrray;
        }
    }
}
