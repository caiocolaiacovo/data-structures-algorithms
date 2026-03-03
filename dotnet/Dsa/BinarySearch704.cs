namespace Dsa
{
    // https://leetcode.com/problems/binary-search/description/
    public class BinarySearch704
    {
        public static void MainBinarySearch()
        {
            // // Expected output: 4
            // int[] nums = new int[] { -1, 0, 3, 5, 9, 12 };
            // int target = 9;
            // Expected output: -1
            int[] nums = new int[] { -1, 0, 3, 5, 9, 12 };
            int target = 2;
            var result = Search(nums, target);
            Console.WriteLine(result); 
        }

        // Time complexity: O(log n) -> it's not necessary to check all the elements, we can discard half of the array in each iteration
        // Space complexity: O(1)
        public static int Search(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length - 1;

            while (l <= r)
            {
                int middle = r + l / 2;

                if (nums[middle] > target) //target is on the left
                {
                    r = middle - 1;
                }
                else if (nums[middle] < target)//target is on the right
                {
                    l = middle + 1;
                }
                else //found
                {
                    return middle;
                }
            }
            return -1;
        }
    }
}