namespace CodeInterview.Algorithms;

public static class BinarySearch
{
    public static int Run(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        int mid;

        while (left <= right)
        {
            mid = (right + left) / 2;

            if (nums[mid] < target) // Target is greater. Search on right half
            {
                left = mid + 1;
            }
            else if (nums[mid] > target) // Target is smaller. Search on left half
            {
                right = mid - 1;
            }
            else if (nums[mid] == target)
            {
                return mid;
            }
        }

        // If we reach here, then the element was not present
        return -1;
    }   
}
