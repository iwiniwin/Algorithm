/*
题目名称：
求1+2+3+...+n

题目描述：
求1+2+3+...+n，要求不能使用乘除法、for、while、if、else、switch、case等关键字及条件判断语句（A?B:C）。

代码结构：
class Solution
{
    public int Sum_Solution(int n)
    {
        // write code here
    }
}
*/
using System;
namespace Sum {

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 使用递归代替循环，使用逻辑与的短路特性来终止递归
        /// </summary>

        public int Sum_Solution(int n)
        {
            bool ret = n > 1 && ((n +=Sum_Solution(n - 1)) > 1);
            return n;
        }


        public void Test() {

            int n = 3;
            n = 1;
            n = 5;

            Console.WriteLine(Sum_Solution(n));
        }
    }
}
