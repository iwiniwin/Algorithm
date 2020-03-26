/*
题目名称：
斐波那契数列

题目描述：
大家都知道斐波那契数列，现在要求输入一个整数n，请你输出斐波那契数列的第n项（从0开始，第0项为0）。
n<=39

代码结构：
class Solution
{
    public int Fibonacci(int n)
    {
        // write code here
    }
}
*/
using System;
namespace Fibonacci {

    class Solution {

        public int Fibonacci(int n)
        {
            if(n == 0 || n == 1){
                return n;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public void Test() {

            int n = 0; // 0
            n = 1; // 1
            n = 2; // 1
            n = 3; // 2
            n = 4; // 3

            n = 39;

            Console.WriteLine(Fibonacci(n));
        }
    }
}
