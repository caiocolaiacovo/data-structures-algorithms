namespace Dsa;

// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
public class LetterCombinationsPhoneNumber17
{
    // Time complexity: O(n * 4^n)
    //  
    //  The "4^n" part:
    //  input is "79" (n=2). Digit 7 maps to[p, q, r, s] and digit 9 maps to[w, x, y, z].
    //  
    //  Possible combinations:
    //  pw, px, py, pz
    //  qw, qx, qy, qz
    //  rw, rx, ry, rz
    //  sw, sx, sy, sz
    //
    //  4 x 4 = 16 combinations = 4². For n digits where each maps to 4 letters, it gets 4^n combinations.
    //  
    //  The "n" part:
    //  level 0: "" -> "p"     (creates string of length 1)
    //  level 1: "p" -> "pw"   (creates string of length 2)
    //  level 2: path.Length == digits.Length -> adds "pw" to result

    //  Each $"{path}{letter}" allocates a new string. So to fully build one combination of length n, you pay O(n) across the levels that led to it
    // 
    //  Space complexity: O(n * 4^n) -> it allocates all the results (4^n) and the call stack for concat the result (n)
    public static IList<string> LetterCombinations(string digits)
    {
        var map = new Dictionary<string, string[]>{
            { "2", new string[] { "a", "b", "c" }},
            { "3", new string[] { "d", "e", "f" }},
            { "4", new string[] { "g", "h", "i" }},
            { "5", new string[] { "j", "k", "l" }},
            { "6", new string[] { "m", "n", "o" }},
            { "7", new string[] { "p", "q", "r", "s" }},
            { "8", new string[] { "t", "u", "v" }},
            { "9", new string[] { "w", "x", "y", "z" }}
        };

        var result = new List<string>();

        void backtracking(int index, string path)
        {
            if (path.Count() == digits.Count())
            {
                result.Add(path);
                return;
            }

            foreach (var letter in map[digits.ElementAt(index).ToString()])
            {
                backtracking(index + 1, $"{path}{letter}");
            }
        }

        backtracking(0, "");

        return result;
    }
}