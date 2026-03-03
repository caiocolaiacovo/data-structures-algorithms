namespace Dsa
{
    // https://leetcode.com/problems/range-sum-query-immutable/description/
    public class NumArrayBigOn
    {
        private int[] _nums;

        public NumArrayBigOn(int[] nums)
        {
            _nums = nums;
        }

        public int SumRange(int left, int right)
        {
            var sum = 0;
            for (int i = left; i <= right; i++)
            {
                sum += _nums[i];
            }
            return sum;
        }
    }

    public class NumArrayBigO1
    {
        private int[] _prefixSums = [];

        public NumArrayBigO1(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i - 1] + nums[i];
            }
            _prefixSums = nums;
        }

        public int SumRange(int left, int right)
        {
            if (left == 0)
            {
                return _prefixSums[right];
            }
            return _prefixSums[right] - _prefixSums[left - 1];
        }
    }

    public class RangeSumQuery303
    {
        public static void MainRangeSum()
        {
            //RangeSum
            NumArrayBigO1 obj = new NumArrayBigO1(new int[] { -2, 0, 3, -5, 2, -1 });
            // int param_1 = obj.SumRange(0, 2); // Expected output: 1
            int param_1 = obj.SumRange(2, 5); // Expected output: -1
            Console.WriteLine(param_1);
        }
    }
}

/**
Input
["NumArray", "sumRange", "sumRange", "sumRange"]
[[[-2, 0, 3, -5, 2, -1]], [0, 2], [2, 5], [0, 5]]
Output
[null, 1, -1, -3]

Explanation
NumArray numArray = new NumArray([-2, 0, 3, -5, 2, -1]);
numArray.sumRange(0, 2); // return (-2) + 0 + 3 = 1
numArray.sumRange(2, 5); // return 3 + (-5) + 2 + (-1) = -1
numArray.sumRange(0, 5); // return (-2) + 0 + 3 + (-5) + 2 + (-1) = -3

             l  r
[0, 1, 2, 3, 4, 5]
[0, 1, 3, 6,10,15]
             l  r
*/