namespace BusinessLayer
{
    public interface IArrayCalcRepoService
    {
        int[] Reverse(int[] productIds);

        int[] DeletePart(int position,int[] productIds);
    }
}