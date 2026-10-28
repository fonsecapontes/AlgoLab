public int[] SortArray(int[] nums)
{
    if (nums.Length <= 1) return nums;

    var temp = new int[nums.Length];

    MergeSort(nums, temp, 0, nums.Length - 1);
    return nums;
}

private void MergeSort(int[] nums, int[] temp, int left, int right)
{
    if (left >= right) return; // 0 ou 1 elemento: já ordenado

    int mid = left + (right - left) / 2;
    MergeSort(nums, temp, left, mid);       // ordena a metade esquerda
    MergeSort(nums, temp, mid + 1, right);  // ordena a metade direita
    Merge(nums, temp, left, mid, right);    // junta as duas
}

private void Merge(int[] nums, int[] temp, int left, int mid, int right)
{
    int i = left, j = mid + 1, k = left;

    while (i <= mid && j <= right)
        temp[k++] = nums[i] <= nums[j] ? nums[i++] : nums[j++]; // <= mantém estável

    while (i <= mid)   temp[k++] = nums[i++]; // sobras da esquerda
    while (j <= right) temp[k++] = nums[j++]; // sobras da direita

    for (k = left; k <= right; k++)
        nums[k] = temp[k]; // copia de volta
}