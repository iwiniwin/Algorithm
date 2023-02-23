/*
题目名称：
打印从1到最大的n位数

题目描述：
输入数字 n，按顺序打印出从 1 到最大的 n 位十进制数。比如输入 3，则打印出 1、2、3 一直到最大的 3 位数 999。
1. 用返回一个整数列表来代替打印
2. n 为正整数，0 < n <= 5

代码结构：
class Solution {
    public List<int> printNumbers (int n) {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace PrintNumbers {
    class Solution {
        public List<int> PrintNumbers (int n) {
            int num = 1;
            while(n -- > 0) {
                num *= 10;
            }

            List<int> result = new List<int>(num - 1);
            for(int i = 0; i < num - 1; i ++) {
                result.Add(i + 1);
            }
            return result;
        }

        public void Test()
        {
            int n = 1;
            foreach (var num in PrintNumbers(n))
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
