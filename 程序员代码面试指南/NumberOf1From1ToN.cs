using System;
namespace NumberOf1From1ToN {
    class Solution {

        public int NumberOf1From1ToN(){
            Console.WriteLine("mmmm");
            string s = Console.ReadLine();
            Console.WriteLine("llll");
            int n = int.Parse(s);
            int count = 0;
            for(int i = 1; i <= n; i = i *10){
                count += n / (i * 10) * i + Math.Min(Math.Max(0, n % (i * 10) - i + 1), i);
            }
            return count;
        }

        public void Test() {
            Solution s = new Solution();
            Console.WriteLine(NumberOf1From1ToN());
        }

    }
}