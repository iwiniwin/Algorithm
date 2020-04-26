/*
题目名称：
顺时针打印矩阵

题目描述：
输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字，
例如，如果输入如下4 X 4矩阵： 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 
则依次打印出数字1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10.

代码结构：
class Solution
{
    public List<int> printMatrix(int[][] matrix)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace PrintMatrix {

    class Solution {

        public List<int> PrintMatrix(int[][] matrix)
        {
            return null;
        }

        public void Print(List<int> list){
            if(list == null){
                Console.WriteLine("null");
                return;
            }
            foreach(int item in list){
                Console.WriteLine(item);
            }
        }

        public void Test() {

            int[][] matrix = new int[][]{
                new int[]{1, 2},
                new int[]{3, 4},
            };
           
            Print(PrintMatrix(matrix));
        }
    }
}
