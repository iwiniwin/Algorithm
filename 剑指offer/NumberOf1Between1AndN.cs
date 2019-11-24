/*
题目名称：
整数中1出现的次数（从1到n整数中1出现的次数）

题目描述：
求出1~13的整数中1出现的次数,并算出100~1300的整数中1出现的次数？
为此他特别数了一下1~13中包含1的数字有1、10、11、12、13因此共出现6次,但是对于后面问题他就没辙了。
ACMer希望你们帮帮他,并把问题更加普遍化,
可以很快的求出任意非负整数区间中1出现的次数（从1 到 n 中1出现的次数）。

代码结构：
class Solution
{
    public int NumberOf1Between1AndN_Solution(int n)
    {
        // write code here
    }
}
*/
using System;
namespace NumberOf1Between1AndN {
    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 逐一考察1~n的每一个数里有多少个1。每个数字可以通过对10求余来判断最后一位是否为1
        /// 时间复杂度是n*ln(n)
        /// </summary>
        public int NumberOf1Between1AndN_Solution(int n)
        {
            int count = 0;
            for(int i = 1; i < n + 1; i ++){
                int m = i;
                while(m > 0){
                    if(m % 10 == 1){
                        count ++;
                    }
                    m = m / 10;
                }
            }
            return count;
        }

        public void Test() {
            Console.WriteLine(NumberOf1Between1AndN_Solution(11));
        }

    }
}
