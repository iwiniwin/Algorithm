/*
题目名称：
数值的整数次方

题目描述：
给定一个double类型的浮点数base和int类型的整数exponent。求base的exponent次方。

保证base和exponent不同时为0

代码结构：
class Solution
{
    public double Power(double thebase, int exponent)
    {
        // write code here
    }
}
*/
using System;
namespace Power {

    class Solution {

        /// <summary>
        /// 解法，快速幂
        /// 基本思路：
        /// 求解整数m的n次方，一般是m ^ n = m * m * m .....，连乘n次，算法复杂度是O(n)
        /// 这样的算法效率太低，我们可以通过减少相乘的次数来提高算法效率，即快速幂
        /// 对于n我们可以用二进制表示，以14为例，14 = 1110
        /// m ^ (14) = m ^ (1110) = m ^ (2 ^ 3 * 1) * m ^ (2 ^ 2 * 1) * m ^ (2 ^ 1 * 1) * m ^ (2 ^ 0 * 0)
        /// = m ^ (8 * 1) * m ^ (4 * 1) * m ^ (2 * 1) * m ^ (1 * 0) = m ^ 8 * m ^ 4 * m ^ 2 * 1
        /// 可以发现这样的规律，指数n的二进制从低位到高位依次对应底数m的1次方，2次方，4次方，8次方...，
        /// 当该二进制位是1的时候，则乘以底数对应的次方数，如果该二进制位是0，则表示乘以1
        /// 注意：代码中使用了long y = exponent; 需要将exponent转换为long类型
        /// 是因为exponent可以等于-2147483648（int类型的最小值），直接进行-exponent
        /// 会导致越界（int类型最大值是2147483647），出现错误的结果
        /// 斐波那契数列中的快速幂解法介绍 https://www.cnblogs.com/iwiniwin/p/10798884.html 
        /// </summary>

        public double Power(double thebase, int exponent)
        {
            if(thebase == 0) return 0;
            long y = exponent;
            if(y < 0){
                thebase = 1 / thebase;
                y = -y;
            } 
            
            double ret = 1;
            while(y > 0){
                if((y & 1) == 1){
                    ret *= thebase;
                }
                thebase *= thebase;
                y >>= 1;
            }
            return ret;
        }

        public void Test() {

            double thebase = 3;
            thebase = 0;
            thebase = -3;
            thebase = 0.5;
            thebase = 2;
            

            int exponent = 4;
            exponent = 3;
            // exponent = -3;
            // exponent = 0;
            exponent = -2147483648;

            Console.WriteLine(Power(thebase, exponent));
        }
    }
}
