/*
题目名称：
螺旋矩阵

题目描述：
给定一个包含 m x n 个元素的矩阵（m 行, n 列），请按照顺时针螺旋顺序，返回矩阵中的所有元素。

示例 1:
输入:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
输出: [1,2,3,6,9,8,7,4,5]

示例 2:
输入:
[
  [1, 2, 3, 4],
  [5, 6, 7, 8],
  [9,10,11,12]
]
输出: [1,2,3,4,8,12,11,10,9,5,6,7]

代码结构：
public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {

    }
}

题目链接：
https://leetcode-cn.com/problems/spiral-matrix/
*/
using System;
using System.Collections.Generic;
namespace SpiralOrder {

    class Solution {

        public IList<int> SpiralOrder(int[][] matrix) {
            return new List<int>(){1, 2};
        }

        public void Print(IList<int> list){
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
        }

        public void Test() {
            int[][] matrix = new int[][]{
                new int[]{1, 2, 3},
                new int[]{4, 5, 6},
                new int[]{7, 8, 9},
            };

            Print(SpiralOrder(matrix));
        }
    }
}
