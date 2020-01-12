/*
题目名称：
机器人的运动范围

题目描述：
地上有一个m行和n列的方格。
一个机器人从坐标0,0的格子开始移动，每一次只能向左，右，上，下四个方向移动一格，
但是不能进入行坐标和列坐标的数位之和大于k的格子。 
例如，当k为18时，机器人能够进入方格（35,37），因为3+5+3+7 = 18。
但是，它不能进入方格（35,38），因为3+5+3+8 = 19。
请问该机器人能够达到多少个格子？

代码结构：
class Solution
{
    public int movingCount(int threshold, int rows, int cols)
    {
        // write code here
    }
}
*/
using System;
namespace MovingCount {

    class Solution {

        public int MovingCount(int threshold, int rows, int cols)
        {
            return 1;
        }
    
        public void Test() {

            int threshold = 0;
            int rows = 0;
            int cols = 0;

            Console.WriteLine(MovingCount(threshold, rows, cols));
        }
    }
}
