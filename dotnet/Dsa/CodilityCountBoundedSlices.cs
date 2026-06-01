namespace Dsa;

// https://app.codility.com/programmers/trainings/7/count_bounded_slices/
public class CodilityCountBoundedSlices
{
    // Time complexity: O(n * n) -> O(n²)
    // Space complexity: O(1)
    public static int Solution(int K, int[] A)
    {
        var count = 0;

        for (int i = 0; i < A.Length; i++)
        {
            var max = Int32.MinValue;
            var min = Int32.MaxValue;

            for (int j = i; j < A.Length; j++)
            {
                max = Math.Max(max, Math.Max(A[i], A[j]));
                min = Math.Min(min, Math.Min(A[i], A[j]));

                if (max - min > K)
                {
                    break;
                }

                count++;
            }
        }

        return count < 1_000_000 ? count : 1_000_000;
    }
}