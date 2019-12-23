/*
题目名称：
不用加减乘除做加法

题目描述：
写一个函数，求两个整数之和，要求在函数体内不得使用+、-、*、/四则运算符号。

代码结构：
class Solution
{
    public int Add(int num1, int num2)
    {
        // write code here
    }
}
*/
using System;
namespace Add {

    class Solution {

        /// <summary>
        /// 解法，位运算
        /// 基本思路：
        /// 以十进制加法为例，36 + 78
        /// 加法过程可以分为三步：
        /// 1. 不考虑进位，相加各位的值。得到 04
        /// 2. 计算进位（该位有进位则为1，无进位则为0）。得到 11。再左移一位。最终得到 110
        /// 3. 使用得到的两个值，重复上面两步。 04 + 110 得到 114
        /// 二进制同理也可以使用上面3步模拟加法
        /// 1. 不考虑进位，相加各位的值。这里不能使用加法，使用异或运算代替。00得0 01得1 11得0
        /// 2. 计算进位。这里利用与运算得到。00得0 01得0 11得1(进位)
        /// 负数是使用补码表示，所以同样适用上述算法
        /// </summary>

        public int Add(int num1, int num2)
        {
            while(num2 != 0){
                int temp = num1 ^ num2;
                num2 &= num1;
                num2 <<= 1;
                num1 = temp;
            }
            return num1;
        }

        public void Test() {

            int num1 = 1;
            // num1 = 0;
            num1 = -6;

            int num2 = 4;
            num2 = -3;
            // num2 = 0;

            Console.WriteLine(Add(num1, num2));
        }
    }
}
