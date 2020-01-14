/*
题目名称：
剪绳子

题目描述：
给你一根长度为n的绳子，请把绳子剪成整数长的m段（m、n都是整数，n>1并且m>1），
每段绳子的长度记为k[0],k[1],...,k[m]。
请问k[0]xk[1]x...xk[m]可能的最大乘积是多少？
例如，当绳子的长度是8时，我们把它剪成长度分别为2、3、3的三段，此时得到的最大乘积是18。

输入描述：
输入一个数n，意义见题面。（2 <= n <= 60）

输出描述：
输出答案。

代码结构：
class Solution
{
    public int cutRope(int number)
    {
        // write code here
    }
}
*/
using System;
namespace CutRope {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 找规律，先列出n的前几项
        /// 2  1 * 1
        /// 3  1 * 2
        /// 4  2 * 2
        /// 5  2 * 3
        /// 6  3 * 3
        /// 7  2 * 2 * 3
        /// 8  2 * 3 * 3
        /// 9  3 * 3 * 3
        /// 10 2 * 2 * 3 * 3
        /// 11 2 * 3 * 3 * 3
        /// 可以发现除了特殊的n=2, n=3以外，其他值都是由2和3组成
        /// 问题在于如何确定2和3的个数
        /// 观察发现，2, 3的个数与 n / 3, n % 3 有关
        /// 2的个数要么是0个或1个或2个，不会是3个，因为当可以2 * 2 * 2 时应该用 3 * 3 表示
        /// 进一步总结可得n % 3 = 0 时 2的个数是0，3的个数是n/3
        /// n % 3 = 1时 2的个数是2，3的个数n/3 - 1
        /// 否则2的个数是1，3的个数是n/3
        /// </summary>

        public int CutRope(int number)
        {
            if(number == 2 || number == 3) return number - 1;
            int mod = number % 3;
            int div = number / 3;
            if(mod == 0) return (int)Math.Pow(3, div);
            else if(mod == 1) return 2 * 2 * (int)Math.Pow(3, div - 1);
            else return 2 * (int)Math.Pow(3, div); 
        }

        /// <summary>
        /// 解法2，贪婪算法
        /// 基本思路：
        /// 根据解法1列出的n的前几项，可以发现，对于每个大于4的值来说，都希望分出更多的3
        /// 比如5 希望分成 2 * 3
        /// 比如8 希望分成 5 * 3，再分成 2 * 3 * 3
        /// </summary>

        public int CutRope2(int number)
        {
            if(number == 2 || number == 3) return number - 1;
            int ret = 1;
            while(number > 4){
                ret *= 3;
                number -= 3;
            }
            return ret * number;
        }


    
        public void Test() {

            int number = 2;
            // number = 3;
            // number = 5;
            // number = 6;
            // number = 7;
            // number = 30;

            // Console.WriteLine(CutRope(number));
            Console.WriteLine(CutRope2(number));
        }
    }
}
