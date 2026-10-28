public class Solution
{
    private static readonly Random Rng = new();

    public int[] SortArray(int[] nums)
    {
        QuickSort(nums, 0, nums.Length - 1);
        return nums;
    }

    private void QuickSort(int[] nums, int low, int high)
    {
        if (low >= high) return; // 0 ou 1 elemento

        int p = Partition(nums, low, high);
        QuickSort(nums, low, p - 1);   // lado dos menores
        QuickSort(nums, p + 1, high);  // lado dos maiores
    }

    // Lomuto: usa o último elemento como pivô
    private int Partition(int[] nums, int low, int high)
    {
        int randomIndex = Rng.Next(low, high + 1);
        (nums[randomIndex], nums[high]) = (nums[high], nums[randomIndex]); // pivô aleatório vai para o fim

        int pivot = nums[high];
        int i = low; // próxima posição livre para um "menor que o pivô"

        for (int j = low; j < high; j++)
        {
            if (nums[j] < pivot)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                i++;
            }
        }

        (nums[i], nums[high]) = (nums[high], nums[i]); // pivô na posição final
        return i;
    }
}