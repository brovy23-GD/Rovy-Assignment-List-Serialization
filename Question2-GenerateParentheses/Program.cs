using System;
using System.Collections.Generic;

namespace Question2_GenerateParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Solution class
            // so we can call the GenerateParenthesis method.
            var solution = new Solution();

            // This is the number of parentheses pairs we want to generate.
            // Example: n = 3 means we want all valid combinations
            // made from 3 opening and 3 closing parentheses.
            int n = 3;

            // Call the method and store the returned list of valid combinations.
            IList<string> result = solution.GenerateParenthesis(n);

            // Print a heading so the user knows what the output represents.
            Console.WriteLine($"Valid parentheses combinations for n = {n}:");

            // Loop through the result list and print each valid combination.
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            // Pause the console so the window does not close right away.
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            // This list will store all completed valid parentheses combinations.
            var result = new List<string>();

            // Start the backtracking process with:
            // an empty current string,
            // 0 opening parentheses used,
            // 0 closing parentheses used.
            Backtrack(result, "", 0, 0, n);

            // Return the full list of valid combinations.
            return result;
        }

        private void Backtrack(List<string> result, string current, int openCount, int closeCount, int n)
        {
            // Base case:
            // If the current string length is 2 * n,
            // that means we have used all parentheses needed
            // and created one complete valid combination.
            if (current.Length == 2 * n)
            {
                result.Add(current);
                return;
            }

            // Choice 1:
            // If we still have opening parentheses left to use,
            // add "(" and continue building the string.
            if (openCount < n)
            {
                Backtrack(result, current + "(", openCount + 1, closeCount, n);
            }

            // Choice 2:
            // We can only add a closing parenthesis if
            // there are more opening parentheses than closing ones so far.
            // This keeps the string valid while we build it.
            if (closeCount < openCount)
            {
                Backtrack(result, current + ")", openCount, closeCount + 1, n);
            }
        }
    }
}