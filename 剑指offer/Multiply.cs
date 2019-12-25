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

        public int[] Multiply(int[] A)
        {
            int[] B = new int[]{6, 6};
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

            Print(Multiply(A));
        }
    }
}
