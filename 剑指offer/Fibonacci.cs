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

补充：
斐波那契数列指的是这样一个数列：1、1、2、3、5、8、13、21、34、……，因数学家列昂纳多·斐波那契以兔子繁殖为例子而引入，故又称为兔子数列
*/
using System;
namespace Fibonacci {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 斐波那契数列可以用公式表示为F(n) = F(n-1) + F(n-2)
        /// 在不考虑效率的情况下可以直接使用递归求得
        /// </summary>

        public int Fibonacci(int n)
        {
            if(n == 0 || n == 1){
                return n;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /// <summary>
        /// 解法2， 动态规划
        /// 基本思路：
        /// 递归的思想是自顶向下的，Fn的求解基于Fn-1和Fn-2，Fn-1的求解又基于Fn-2和Fn-3等等依次类推。
        /// 而现在我们可以反过来，自底向上，在已知F1 = 1，F2 = 1的情况下求解F3，再利用F3和F2求解F4直到求出Fn。
        /// 即不使用递归，使用循环迭代的方式。我们可以给这种方式起一个高大上的名字，动态规划。
        /// 动态规划介绍 https://www.cnblogs.com/iwiniwin/p/10798884.html
        /// </summary>

        public int Fibonacci2(int n)
        {
            int i = 0, j = 1;
            while(n -- > 0){
                i = i + j;
                j = i - j;
            }
            return i;
        }

        /// <summary>
        /// 解法3，矩阵的快速幂
        /// 基本思路：
        /// 首先归纳出斐波那契数列和矩阵的关系
        /// 我们已知斐波那契第n项，Fn = F(n - 1) + F(n - 2)，可以将它们转换成如下所示的矩阵形式
        /// 
        ///     Fn              Fn-1 + Fn-2            Fn-1 * 1 + Fn-2 * 1        1  1       Fn-1
        /// [        ]  =  [                    ] = [                      ]  = [      ] * [      ]
        ///     Fn-1                Fn-1               Fn-1 * 1 + Fn-2 * 0        1  0       Fn-2
        /// 
        /// 进而推导出
        /// 
        ///     Fn           1  1                   F1
        /// [        ]  =  [      ]的 n - 1次方 * [     ]
        ///     Fn-1         1  0                   F0
        /// 
        /// 然后直接编程计算矩阵乘法以及矩阵快速幂并代入公式即可
        /// 快速幂以及详细推导过程介绍 https://www.cnblogs.com/iwiniwin/p/10798884.html
        /// </summary>

        public int[,] multiply(int[,] m1, int[,] m2){
            return new int[,]{
                {m1[0, 0] * m2[0, 0] + m1[0, 1] * m2[1, 0], m1[0, 0] * m2[0, 1] + m1[0, 1] * m2[1, 1]},
                {m1[1, 0] * m2[0, 0] + m1[1, 1] * m2[1, 0], m1[1, 0] * m2[0, 1] + m1[1, 1] * m2[1, 1]},
            };
        }

        public int[,] pow(int[,] matrix, int n){
            int[,] ret = new int[,]{{1, 0}, {0, 1}};
            while(n > 0){
                if((n & 1) > 0) {
                    ret = multiply(ret, matrix);
                }
                n = n >> 1;
                matrix = multiply(matrix, matrix);
            }
            return ret;
        }

        public int Fibonacci3(int n)
        {
            int[,] unit = new int[,]{{1, 1}, {1, 0}};
            int[,] matrix = new int[,]{{1, 0}, {0, 0}};
            int[,] ret = multiply(pow(unit, n - 1), matrix);
            return n == 0 ? 0 : ret[0, 0];
        }

        public void Test() {

            int n = 0; // 0
            n = 1; // 1
            n = 2; // 1
            n = 3; // 2
            n = 4; // 3

            n = 39;

            // Console.WriteLine(Fibonacci(n));
            // Console.WriteLine(Fibonacci2(n));
            Console.WriteLine(Fibonacci3(n));
        }
    }
}
