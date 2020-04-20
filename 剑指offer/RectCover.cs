/*
题目名称：
矩形覆盖

题目描述：
我们可以用2*1的小矩形横着或者竖着去覆盖更大的矩形。
请问用n个2*1的小矩形无重叠地覆盖一个2*n的大矩形，总共有多少种方法？

比如n=3时，2*3的矩形块有3种覆盖方法

代码结构：
class Solution
{
    public int rectCover(int number)
    {
        // write code here
    }
}
*/
using System;
namespace RectCover {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 用n个2*1的小矩形无重叠地覆盖一个2*n的大矩形，假设有F(n)种方法
        /// 可以先用一个2*1的小矩形，竖着覆盖大矩形，则还剩下2*(n-1)的大矩形需要覆盖，即有F(n-1)种方法
        /// 也可以先用一个2*1的小矩形，横着覆盖大矩形。则还剩下2*(n-2)的大矩形需要覆盖，即有F(n-2)种方法
        /// 由以上两种情况可知，F(n) = F(n - 1) + F(n - 2)，这不就是斐波那契数列嘛
        /// 所以求斐波那契数列的解法都可以用于这道题 详情可参考 Fibonacci.cs 文件
        /// 这里给出简单的递归解法，其余斐波那契数列解法不再赘述
        /// 图文介绍 https://www.cnblogs.com/iwiniwin/p/11006962.html
        /// </summary>

        public int RectCover(int number)
        {
            if(number <= 2) return number;
            return RectCover(number - 1) + RectCover(number - 2);
        }

        public void Test() {

            int number = 3;
            // number = 2;
            // number = 1;
            // number = 0;

            Console.WriteLine(RectCover(number));
        }
    }
}
