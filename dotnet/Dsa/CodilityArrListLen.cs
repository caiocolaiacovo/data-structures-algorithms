namespace Dsa;

// https://app.codility.com/programmers/trainings/7/arr_list_len/
public class CodilityArrListLen
{
    // Time complexity: O(n) -> worst-case scenario, when all the array elements are present on the linked list
    // Space complexity: O(n) -> worst-case, when it will stack all the elements on the call stack
    public static int Solution(int[] A)
    {
        int iterate(int i)
        {
            if (i == -1)
            {
                return 1;
            }

            return 1 + iterate(A[i]);
        }

        return iterate(A[0]);
    }
}