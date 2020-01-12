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

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 利用递归，从0，0点，开始向上下左右开始搜索
        /// 利用flag数组记录搜索过的节点，置为true。
        /// 利用count统计进入的格子个数
        /// 注意，这里在回溯的时候是不用将标记还原的
        /// </summary>

        int count = 0;

        public int Calc(int num) {
            int sum = 0;
            while(num > 0){
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        public void MovingCountImpl(int threshold, int rows, int cols, int row, int col, bool[,] flag) {

            if(row < 0 || row >= rows || col < 0 || col >= cols || flag[row, col]){
                return;
            }

            if(Calc(row) + Calc(col) > threshold){
                return;
            }
            count ++;
            flag[row, col] = true;
            MovingCountImpl(threshold, rows, cols, row, col + 1, flag);
            MovingCountImpl(threshold, rows, cols, row, col - 1, flag);
            MovingCountImpl(threshold, rows, cols, row + 1, col, flag);
            MovingCountImpl(threshold, rows, cols, row - 1, col, flag);
        }

        public int MovingCount(int threshold, int rows, int cols)
        {
            bool[,] flag = new bool[rows, cols];
            count = 0;
            MovingCountImpl(threshold, rows, cols, 0, 0, flag);
            return count;
        }
    
        public void Test() {

            int threshold = 9;
            int rows = 100;
            int cols = 100;

            Console.WriteLine(MovingCount(threshold, rows, cols));
        }
    }
}
