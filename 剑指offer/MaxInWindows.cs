/*
题目名称：
滑动窗口的最大值

题目描述：
给定一个数组和滑动窗口的大小，找出所有滑动窗口里数值的最大值。
例如，如果输入数组{2,3,4,2,6,2,5,1}及滑动窗口的大小3，那么一共存在6个滑动窗口，
他们的最大值分别为{4,4,6,6,6,5}； 
针对数组{2,3,4,2,6,2,5,1}的滑动窗口有以下6个： 
{[2,3,4],2,6,2,5,1}， {2,[3,4,2],6,2,5,1}， {2,3,[4,2,6],2,5,1}， 
{2,3,4,[2,6,2],5,1}， {2,3,4,2,[6,2,5],1}， {2,3,4,2,6,[2,5,1]}。

代码结构：
class Solution
{
    public int[] maxInWindows(int[] num, int size)
    {
        // write code here
    }
}
*/
using System;
namespace MaxInWindows {

    class Solution {

        public int[] MaxInWindows(int[] num, int size)
        {
            return new int[]{1, 2, 3};
        }

        public void Print(int[] num) {
            foreach(int i in num){
                Console.WriteLine(i);
            }
        }

        public void Test() {

            int[] num = new int[]{};

            int size = 3;

            Print(MaxInWindows(num, size));
        }
    }
}
