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

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 1  2  3  4
        /// 5  6  7  8
        /// 9  10 11 12
        /// 13 14 15 16
        /// 顺时针打印就是将矩阵按圈顺时针循环打印，比如上面的4x4矩阵可以看成是循环两圈
        /// 分别是外圈1,2,3,4,8,12,16,15,14,13,9,5和内圈6,7,11,10
        /// 每一圈又可以分成四个部分
        /// 分别是从左到右遍历第一行，从上到下遍历最后一列，
        /// 从右到左遍历最后一行，从下到上遍历第一列
        /// 注意处理每部分不要重复遍历相同元素即可
        /// </summary>

        public List<int> PrintMatrix(int[][] matrix)
        {
            List<int> list = new List<int>();
            int offset = 0, row = matrix.Length, col = matrix[0].Length;
            while(offset < row && offset < col){
                for(int i = offset; i < col; i ++)
                    list.Add(matrix[offset][i]);
                for(int i = offset + 1; i < row; i ++)
                    list.Add(matrix[i][col - 1]);
                for(int i = col - 2; i >= offset && offset != row - 1; i --)
                    list.Add(matrix[row - 1][i]);
                for(int i = row - 2; i > offset && offset != col - 1; i --)
                    list.Add(matrix[i][offset]);
                offset ++;
                row --;
                col --;
            }
            return list;
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

            // matrix = new int[][]{
            //     new int[]{1, 2, 3, 4},
            //     new int[]{5, 6, 7, 8},
            //     new int[]{9, 10, 11, 12},
            //     new int[]{13, 14, 15, 16},
            // };

            // matrix = new int[][]{
            //     new int[]{1, 2, 3},
            //     new int[]{4, 5, 6},
            // };

            //  matrix = new int[][]{
            //     new int[]{1, 2},
            //     new int[]{3, 4},
            //     new int[]{5, 6},
            // };

            // matrix = new int[][]{
            //     new int[]{1},
            //     new int[]{2},
            //     new int[]{3},
            //     new int[]{4},
            //     new int[]{5},
            // };

            // matrix = new int[][]{
            //     new int[]{1, 2, 3, 4, 5},
            // };
           
            Print(PrintMatrix(matrix));
        }
    }
}
