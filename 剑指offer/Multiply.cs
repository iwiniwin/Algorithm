/*
题目名称：
构建乘积数组

题目描述：
给定一个数组A[0,1,...,n-1],请构建一个数组B[0,1,...,n-1],其中B中的元素B[i]=A[0]*A[1]*...*A[i-1]*A[i+1]*...*A[n-1]。不能使用除法。

代码结构：
class Solution
{
    public int[] multiply(int[] A)
    {
        // write code here
    }
}
*/
using System;
namespace Multiply {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 对于每个元素B[i]
        /// 先计算i左边的元素乘积 B[i] = B[0] * B[1] * B[2] * ... * B[i - 1]
        /// 再计算i右边的元素乘积 B[i] = B[i + 1] * B[i + 2] * ... * B[n - 1]
        /// 再把两边的乘积相乘
        /// </summary>

        public int[] Multiply(int[] A)
        {
            if (A == null) return A;
            int[] B = new int[A.Length];
            int ret = 1;
            for(int i = 0; i < A.Length; ret *= A[i ++]){
                B[i] = ret;
            }
            ret = 1;
            for(int i = A.Length - 1; i >= 0; ret *= A[i --]) {
                B[i] *= ret;
            }
            return B;
        }

        public void Print(int[] array) {
            foreach (int item in array)
            {   
                Console.WriteLine(item);
            }
        } 

        public void Test() {

            int[] A = new int[]{1, 2, 3, 4};
            // A = new int[]{1, 2, 3, 4, 5};
            // A = new int[]{0};
            // A = new int[]{0, 1};

            Print(Multiply(A));
        }
    }
}
