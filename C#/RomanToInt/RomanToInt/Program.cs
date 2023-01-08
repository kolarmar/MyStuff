using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToInt
{
    internal class Program
    {
        static int RomanToInt(string s)
        {
            int result = 0;
            int sLen = s.Length;

            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);

            int current = 0;
            int last = 0;

            for(int i = sLen - 1; i >= 0; i--)
            {
                current = map[s[i]];

                if (current < last)
                {
                    result -= current;
                }
                else
                {
                    result += current;
                }

                last = current;
            }

            return result;
        }



        static void Main(string[] args)
        {
        }
    }
}
