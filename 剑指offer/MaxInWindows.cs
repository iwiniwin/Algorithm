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
using System.Collections.Generic;
namespace MaxInWindows {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 最直观的解法，针对每一个size大小的窗口，都重新计算出最大值
        /// 但效率不高，没有利用好前面窗口已经算出的最大值
        /// </summary>

        public int[] MaxInWindows(int[] num, int size)
        {
            if(num == null || num.Length < size || size <= 0) {
                return new int[]{};
            }
            int[] ret = new int[num.Length - size + 1];
            for(int i = 0; i < num.Length - size + 1; i ++){
                int max = num[i];
                for(int j = 1; j < size; j ++){
                    if(num[i + j] > max){
                        max = num[i + j];
                    }
                }
                ret[i] = max;
            }
            return ret;
        }

        /// <summary>
        /// 解法2，双端队列
        /// 基本思路：
        /// 利用双端队列的首部记录每个窗口的最大值
        /// 每新增一个元素
        /// 1. 从队列首部开始判断，每个元素是否已经超出窗口范围，是的话移除
        /// 2. 从队列尾部开始判断，新增的元素是否比队列内的元素大，是的话移除（保证队列首部一定是最大值）
        /// 3. 将新增的元素从尾部加入队列
        /// </summary>

        public int[] MaxInWindows2(int[] num, int size)
        {
            if(num == null || size <= 0 || num.Length < size){
                return new int[]{};
            }
            int[] ret = new int[num.Length - size + 1];
            LinkedList<int> list = new LinkedList<int>();
            for(int i = 0; i < num.Length; i ++){
                while(list.Count > 0 && i - size >= list.First.Value) list.RemoveFirst();
                while(list.Count > 0 && num[i] >= num[list.Last.Value]) list.RemoveLast();
                list.AddLast(i);
                if(i - size + 1 >= 0){
                    ret[i - size + 1] = num[list.First.Value];
                }
            }
            return ret;
        }

        public void Print(int[] num) {
            if(num == null){
                Console.WriteLine("null");
                return;
            }
            foreach(int i in num){
                Console.WriteLine(i);
            }
        }

        public void Test() {

            int[] num = new int[]{2,3,4,2,6,2,5,1};

            int size = 3;

            // Print(MaxInWindows(num, size));
            Print(MaxInWindows2(num, size));
        }
    }
}
