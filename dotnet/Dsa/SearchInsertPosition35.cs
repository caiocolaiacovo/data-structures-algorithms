namespace Dsa;

// https://leetcode.com/problems/search-insert-position/description/
public class SearchInsertPosition35
{
    // Time complexity: O(log n) -> half of the array is discarted on every iteraction
    // Space complexity: O(1) -> no extra space is created
    public static int SearchInsert(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (target == nums[mid])
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}

//  0  1  2  3
//  l  rm                                 
// [1, 3, 5, 6]
// target = 2