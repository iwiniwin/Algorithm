/*
题目名称：
数组中的逆序对

题目描述：
在数组中的两个数字，如果前面一个数字大于后面的数字，则这两个数字组成一个逆序对。
输入一个数组,求出这个数组中的逆序对的总数P。
并将P对1000000007取模的结果输出。 即输出P%1000000007

输入描述：
题目保证输入的数组中没有的相同的数字
数据范围：
	对于%50的数据,size<=10^4
	对于%75的数据,size<=10^5
	对于%100的数据,size<=2*10^5

代码结构：
class Solution
{
    public int InversePairs(int[] data)
    {
        // write code here
    }
}
*/
using System;
namespace InversePairs {
    class Solution {

        /// <summary>
        /// 解法，归并排序思想
        /// 基本思路：
        /// 将含有n个元素的数组，不断的进行二分为两个子数组。直到每个子数组都只含有一个元素。
        /// 再进行合并两个子数组，利用一个临时数组，不断从两个子数组中选出最大值放到临时数组中。
        /// 在比较时，由于每个子数组都是有序递减的，所以只需要比较子数组的首元素即可（此时进行逆序对的数量统计，如果
        /// 该元素已经大于右边子数组的首元素，则右边子数组的所有元素都小于该元素，即都可以和该元素构成逆序对）。
        /// 归并排序介绍 https://www.cnblogs.com/iwiniwin/p/12609549.html
        /// </summary>

        public int Merge(int[] data, int start, int mid, int end){
            int count = 0;
            int i = start;
            int j = mid + 1;
            int k = 0;
            int[] temp = new int[end - start + 1];
            while(i <= mid && j <= end){
                if(data[i] > data[j]){
                    count += (end - j + 1);
                    if(count > 1000000007){
                        count %= 1000000007;
                    }
                    temp[k ++] = data[i ++];
                }else{
                    temp[k ++] = data[j ++];
                }
            }
            while(i <= mid){
                temp[k ++] = data[i ++];
            }
            while(j <= end){
                temp[k ++] = data[j ++];
            }
            for(i = 0; i < k; i ++){
                data[start + i] = temp[i];
            }
            return count;
        }

        public int MergeSort(int[] data, int start, int end){
            if(start >= end){
                return 0;
            }
            int mid = (start + end) / 2;
            return (MergeSort(data, start, mid) + MergeSort(data, mid + 1, end) + Merge(data, start, mid, end)) % 1000000007;
        }

        public int InversePairs(int[] data)
        {
            if(data == null){
                return 0;
            }
            return MergeSort(data, 0, data.Length - 1);
        }

        public void Test() {
            int[] data = new int[]{1, 6, 2, 8, 4, 1, 0, 7};
            // data = new int[]{1, 2, 3, 4, 5, 6, 7, 0};
            // data = null;
            // data = new int[]{};
            // data = new int[]{1, 1, 0};

            Console.WriteLine(InversePairs(data));
        }
    }
}
