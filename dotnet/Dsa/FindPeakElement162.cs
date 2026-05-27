namespace Dsa;

// https://leetcode.com/problems/find-peak-element/
public class FindPeakElement162
{
    // Time complexity: O(log n) -> it discards half of the array/subset every single iteraction
    // Space complexity: O(1) -> it doesn't create extra space in memory
    public static int FindPeakElement(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] > nums[mid + 1])
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}


//  0 1 2 3 4  5 6
//          ml r
// [1,2,1,3,5, 6,4]