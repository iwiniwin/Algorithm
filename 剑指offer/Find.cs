/*
题目名称：
二维数组中的查找

题目描述：
在一个二维数组中（每个一维数组的长度相同），每一行都按照从左到右递增的顺序排序，
每一列都按照从上到下递增的顺序排序。请完成一个函数，输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。

代码结构：
class Solution
{
    public bool Find(int target, int[][] array)
    {
        // write code here
    }
}
*/
using System;
namespace Find {

    class Solution {

        public bool Find(int target, int[][] array)
        {
            return false;
        }

        public void Test() {

            int target = 0;
            int[][] array = new int[][]{new int[]{}, new int[]{}};

            Console.WriteLine(Find(target, array));
        }
    }
}
