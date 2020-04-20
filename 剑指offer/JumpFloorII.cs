/*
题目名称：
变态跳台阶

题目描述：
一只青蛙一次可以跳上1级台阶，也可以跳上2级……它也可以跳上n级。求该青蛙跳上一个n级的台阶总共有多少种跳法。

代码结构：
class Solution
{
    public int jumpFloorII(int number)
    {
        // write code here
    }
}

想法：
当拿到一道题时，不知道怎么下手去解题，毫无头绪时，试着找找规律，可能会有惊喜
*/
using System;
namespace JumpFloorII {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 列出结果的前几项，找找规律，可能会有意想不到的收获
        /// 对于1级台阶，青蛙只有1 = 2^0种跳法
        /// 对于2级台阶，青蛙有2 = 2^1种跳法（分别是{1,1}, {2}）
        /// 对于3级台阶，青蛙有4 = 2^2种跳法（分别是{1,1,1}, {1,2}, {2,1}, {3}）
        /// 对于4级台阶，青蛙有8 = 2^3种跳法（分别是{1,1,1,1}, {1,1,2}, {1,2,1}, {2,1,1}, {2,2}, {1,3}, {3,1}, {4}）
        /// 不难发现，对于n级台阶，总跳法数是2^(n-1)
        /// 最终这道题被转换成如何求解2^(n-1)，可以使用整数的快速幂解题
        /// 详细介绍 https://www.cnblogs.com/iwiniwin/p/10807310.html
        /// </summary>

        public int JumpFloorII(int number){
            if(number <= 0) return 0;
            int n = number - 1;
            int m = 2;
            int ret = 1;
            while(n > 0){
                if((n & 1) > 0){
                    ret *= m;
                }
                m *= m;
                n >>= 1;
            }
            return ret;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 对于求解2^(n-1)，可以继续优化，利用左移运算，只使用一行代码就可以得到2^(n-1)
        /// 对于数字1，左移1位二进制表示是10，即2 = 2^1
        /// 左移2位是100，即4 = 2^2
        /// 左移3位是1000，即8 = 2^3
        /// 以此类推，左移n位，就是2^n
        /// </summary>

        public int JumpFloorII2(int number)
        {
            return number > 0 ? 1 << (number - 1) : 0;
        }

        public void Test() {

            int number = 3;
            // number = 5;
            // number = 1;
            // number = 0;

            // Console.WriteLine(JumpFloorII(number));
            Console.WriteLine(JumpFloorII2(number));
        }
    }
}
