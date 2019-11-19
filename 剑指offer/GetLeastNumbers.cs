/*
题目名称：
最小的K个数

题目描述：
输入n个整数，找出其中最小的K个数。例如输入4,5,1,6,2,7,3,8这8个数字，则最小的4个数字是1,2,3,4,。

代码结构：
class Solution
{
    public List<int> GetLeastNumbers_Solution(int[] input, int k)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace GetLeastNumbers {
    class Solution {

        /*解法1
        基本思路：
        类似于冒泡排序，比较容易理解。每次遍历时找到子数组中的最小值，将最小值移动到子数组的起始位置。
        */
        public void Swap(int[] input, int i, int j){
            int temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
        public List<int> GetLeastNumbers_Solution(int[] input, int k)
        {
            List<int> list = new List<int>();
            if (input == null || k > input.Length){
                return list;
            }
            for(int i = 0; i < k && i < input.Length; i ++){
                int index = i;
                for(int j = i + 1; j < input.Length; j ++){
                    if(input[j] < input[index]){
                        index = j;
                    }
                }
                list.Add(input[index]);
                Swap(input, i, index);
            }
            return list;
        }

        public void Print(List<int> list) {
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void Test() {
            int[] input = new int[]{4,5,1,6,2,7,3,8};
            // input = new int[]{1, 1, 3, 6, 7};
            Print(GetLeastNumbers_Solution(input, 4));
        }
    }
}
