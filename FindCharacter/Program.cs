using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** 
 * Return the smallest character that is strictly larger than the search character, 
 * If no such character exists, return the smallest character in the array
 * @param sortedStr : sorted list of letters, sorted in ascending order.
 * @param c : character for which we are searching.
 * Given the following inputs we expect the corresponding output:
 * ['c', 'f', 'j', 'p', 'v'], 'a' => 'c'
 * ['c', 'f', 'j', 'p', 'v'], 'c' => 'f'
 * ['c', 'f', 'j', 'p', 'v'], 'k' => 'p'
 * ['c', 'f', 'j', 'p', 'v'], 'z' => 'c' // The wrap around case
 * ['c', 'f', 'k'], 'f' => 'k'
 * ['c', 'f', 'k'], 'c' => 'f'
 * ['c', 'f', 'k'], 'd' => 'f'
 */
namespace Findchar
{
    class Program
    {
        static void Main(string[] args)
        {
            // 'c', 'f', 'j', 'p', 'v'

            char[] input = {'c', 'f', 'j', 'p', 'v'};

            Console.WriteLine("Output is {0}", find_ins_point(input, 'z'));
        }


        static char find_ins_point(char[] sortedStr, char c)
        {

            return find_ins_point_helper(sortedStr, c, sortedStr[0]);
        }

        static char find_ins_point_helper(char[] sortedStr, char c, char firstchar)
        {
            string sortedString = new string(sortedStr);

            if (string.IsNullOrEmpty(sortedString))
            {
                return '\0';
            }

            if (sortedString.Length == 1)
            {
                if (c < sortedString[0])
                {
                    return sortedString[0];
                }

                return firstchar;
            }


            int start = 0;
            int end = sortedString.Length - 1;

            // int middlecharIndex = (sortedString.Length - 1) / 2;
            int middlecharIndex = (start + end) / 2;

            char middleChar = sortedString[middlecharIndex];

            if (c == middleChar)
            {
                return sortedString[middlecharIndex + 1];
            }
            else if (c < middleChar)
            {
                return find_ins_point_helper(sortedString.Substring(0, middlecharIndex  - start + 1).ToArray(), c, firstchar);
            }
            else
            {
                return find_ins_point_helper(sortedString.Substring(middlecharIndex + 1, end - middlecharIndex).ToArray(), c, firstchar);
            }
        }

    }
}
