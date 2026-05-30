namespace Dsa;

public class FibonacciDp
{
    // Time complexity: O(2^n) exponential -> the call tree grows by two (left + right) every iteraction
    // Space complexity: O(n) -> the call stack will have basically the same size as the number (DFS)
    public static int Fibonacci(int number)
    {
        static int fib(int number)
        {
            if (number <= 1)
            {
                return number;
            }

            return fib(number - 1) + fib(number - 2);
        }

        return fib(number);
    }

    // Time complexity: O(2n) -> O(n) -> every number added to the fibonacci grows 2 nodes on the call tree
    // Space complexity: O(n) -> basically the heigth of the call tree
    public static int FibonacciWithDp(int number)
    {
        var memo = new Dictionary<int, int>();

        static int fib(int number, Dictionary<int, int> memo)
        {
            if (number <= 1)
            {
                return number;
            }

            if (memo.TryGetValue(number, out var value))
            {
                return value;
            }

            var newValue = fib(number - 1, memo) + fib(number - 2, memo);
            memo.Add(number, newValue);

            return newValue;
        }

        return fib(number, memo);
    }
}