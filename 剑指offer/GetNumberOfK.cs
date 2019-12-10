/*
题目名称：
数字在排序数组中出现的次数

题目描述：
统计一个数字在排序数组中出现的次数。

代码结构：
class Solution
{
    public int GetNumberOfK(int[] data, int k)
    {
        // write code here
    }
}
*/
using System;
namespace GetNumberOfK {

    class Solution {

        /// <summary>
        /// 解法，二分查找
        /// 在排序数组中查找，首先想到的是二分查找
        /// 由于数组中的数字都是整数，所以可以通过分别查找k+0.5和k-0.5这两个数字应该插入的位置
        /// 两个位置的差值就是数字k的个数
        /// 由于题目未说明排序数组是递增还是递减，所以通过increase标志判断
        /// </summary>

        public int Find(int[] data, double k){
            int left = 0, right = data.Length - 1;
            int mid = 0;
            bool increase = true;
            if(data[left] > data[right]){
                increase = false;
            }
            while(left <= right){
                mid = (left + right) / 2;
                if(data[mid] < k){
                    if(increase){
                        left = mid + 1;
                    }else{
                        right = mid - 1;
                    }
                    
                }else if(data[mid] > k){
                    if(increase){
                        right = mid - 1;
                    }else{
                        left = mid + 1;
                    }
                }
            }
            return increase ? left : -left;
        }

        public int GetNumberOfK(int[] data, int k)
        {
            if(data == null || data.Length == 0){
                return 0;
            }
            return Find(data, k + 0.5) - Find(data, k - 0.5);
        }

        public void Test() {
            int[] data = new int[]{1, 2, 3, 3, 4};
            // data = new int[]{3, 3, 3, 3, 3};
            // data = null;
            // data = new int[]{};
            // data = new int[]{4, 3, 3, 2, 1};
            int k = 3;

            Console.WriteLine(GetNumberOfK(data, k));
        }
    }
}
