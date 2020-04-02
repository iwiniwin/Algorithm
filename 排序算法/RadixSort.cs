/*
算法名称：
基数排序

时间复杂度：O(d(n + r))

空间复杂度：O(n + r)

最好情况：
O(d(n + r))

最坏情况：
O(d(n + r))

稳定性：稳定

优点：稳定，时间复杂度可以突破基于比较的排序法的下界

缺点：需要额外的辅助空间
*/
using System;
namespace RadixSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 首先设立r个队列，对列编号分别为0～r-1，r为待排序列中元素的基数（例如10进制数，则r=10）
        /// 然后按照下面的规则对元素进行分配收集
        /// 1，先按最低有效位的值，把n个元素分配到上述的r个队列中，然后从小到大将个队列中的元素依次收集起来
        /// 2，再按次低有效位的值把刚收集起来的关键字分配到r个队列中，重复收集工作
        /// 3，重复地进行上述分配和收集，直到最高有效位。
        /// （也就是说，如果位数为d，则需要重复进行d次，d由所有元素中最长的一个元素的位数计量）
        /// </summary>

        public void RadixSort(int[] array){

            int max = GetMaxValue(array);

            int[] buckets = new int[10];
            int[] buffer = new int[array.Length];

            for(int i = 1; max / i > 0; i = i * 10){
                // 统计每个桶中的元素个数
                for(int j = 0; j < array.Length; j ++){
                    buckets[array[j] / i % 10] ++;
                }
                // 使每个桶记录的数表示在buffer数组中的位置
                for(int j = 1; j < buckets.Length; j ++){
                    buckets[j] += buckets[j - 1];
                }
                // 收集，将桶中的数据收集到buffer数组中
                for(int j = array.Length - 1; j >= 0; j --){
                    buffer[-- buckets[array[j] / i % 10]] = array[j];
                }
                for(int j = 0; j < array.Length; j ++){
                    array[j] = buffer[j];
                }
                // 清空桶
                for(int j = 0; j < buckets.Length; j ++){
                    buckets[j] = 0;
                }
            }
        }

        // 获得待排序列中的最大元素
        public int GetMaxValue(int[] array){
            int max = array[0];
            for(int i = 1; i < array.Length; i ++){
                if(array[i] > max){
                    max = array[i];
                }
            }
            return max;
        }

        public void Test() {

            int[] array = new int[]{5, 4, 1, 2, 3};

            // array = new int[]{5, 40, 10, 2, 365, 72, 6459, 781, 66666, 999, 92, 95, 85, 0, 1};

            array = new int[]{5, 400, 400, 400, 365, 781, 66666, 0, 0, 0, 85, 11, 11};

            RadixSort(array);

            Print(array);
        }

        public void Print(int[] array){
            foreach (int item in array)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }
    }
}
