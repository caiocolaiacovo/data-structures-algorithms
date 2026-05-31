namespace Dsa;

public class Backtracking
{
    // n = number of chars per string
    // c = number of letters on the array
    // 
    // Time complexity: O(n * c^n)
    //  The "c^n" part:
    //  AA AB
    //  BA BB
    //  2 x 2 = 4 = 2^2
    // 
    //  For 3 chars per string:
    //  AAA AAB ABA ABB
    //  BAA BAB BBA BBB
    //  2 x 4 = 8 = 2^3
    //
    // Space complexity: O(n * c^n)
    public static IList<string> GenerateStrings(int n, IList<string> letters)
    {
        var result = new List<string>();

        void backtracking(string path)
        {
            if (path.Count() == n)
            {
                result.Add(path);
                return;
            }

            foreach (var letter in letters)
            {
                path = $"{path}{letter}";
                backtracking(path);
                path = path[..^1];
            }
        }

        backtracking("");

        return result;
    }
}

// n = 2
// path = "" | "A"
// value = "A" | "AA"
//            i
// letters = [A, B]
// result = [ AA, ]