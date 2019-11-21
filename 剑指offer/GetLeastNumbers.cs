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

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 类似于直接选择排序，比较容易理解。每次遍历时找到子数组中的最小值，将最小值移动到子数组的起始位置。
        /// </summary>
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

        /// <summary>
        /// 解法2
        /// 利用堆排序（小顶堆），首先构建堆，然后每次依次取堆顶的元素（最小值），并将其交换到尾部
        /// 然后重新构建堆，重复上述过程。取出k个数即可。
        /// 堆排序介绍 https://blog.csdn.net/FightLei/article/details/52586776
        /// </summary>
        
        public void HeapAdjust(int[] input, int start, int end){
            int target = input[start];
            for(int i = 2 * start + 1; i < end; i = 2 * i + 1){
                if ((i + 1) < end && input[i + 1] < input[i]){
                    i ++;
                }
                if (input[i] < target){
                    input[start] = input[i];
                    start = i;
                }else{
                    break;
                }
            }
            input[start] = target;
        }
        public List<int> GetLeastNumbers_Solution2(int[] input, int k)
        {
            List<int> list = new List<int>();
            if (input == null || input.Length < k){
                return list;
            }
            for(int i = input.Length / 2 - 1; i >= 0; i --){
                HeapAdjust(input, i, input.Length);
            }
            for(int i = 1; i <= k; i ++){
                list.Add(input[0]);
                Swap(input, 0, input.Length - i);
                HeapAdjust(input, 0, input.Length - i);
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
            // input = new int[]{};
            // input = null;

            // Print(GetLeastNumbers_Solution(input, 4));
            Print(GetLeastNumbers_Solution2(input, 4));
        }
    }
}
