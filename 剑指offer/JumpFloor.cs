/*
题目名称：
跳台阶

题目描述：
一只青蛙一次可以跳上1级台阶，也可以跳上2级。求该青蛙跳上一个n级的台阶总共有多少种跳法（先后次序不同算不同的结果）。

代码结构：
class Solution
{
    public int JumpFloor(int number)
    {
        // write code here
    }
}
*/
using System;
namespace JumpFloor {

    class Solution {

        /// <summary>
        /// 对于n级台阶，设一共有F(n)种跳法
        /// 第一次青蛙可以选择跳1级，则剩下的跳法就是F(n-1) 
        /// 青蛙也可以选择跳2级，则剩下的跳法就是F(n-2)    
        /// 即F(n) = F(n-1) + F(n-2)，这不就是斐波那契数列嘛
        /// 所以求斐波那契数列的解法都可以用于这道题 详情可参考 Fibonacci.cs 文件
        /// 这里给出简单的递归解法，其余斐波那契数列解法不再赘述
        /// </summary>

        public int JumpFloor(int number)
        {
            if(number <= 2){
                return number;
            }
            return JumpFloor(number - 1) + JumpFloor(number - 2);
        }

        public void Test() {

            int number = 0;
            number = 2;
            number = 3;
            number = 4;
            number = 39;

            Console.WriteLine(JumpFloor(number));
        }
    }
}
