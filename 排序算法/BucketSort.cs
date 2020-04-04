/*
算法名称：
桶排序

时间复杂度：O(n)

空间复杂度：O(m + n)，m表示桶的个数

最好情况：
O(n)，当待排序列的元素是被均匀分配到桶中时，是线性时间O(n)

最坏情况：
所有元素都被分配到同一个桶中，退化为普通排序。各个桶内的数据越少，排序所用的时间也越少，但相应的空间消耗就会增大

稳定性：稳定

优点：稳定，突破了基于比较排序的下限

缺点：需要额外的辅助空间，需要好的映射函数
*/
using System;
using System.Collections.Generic;
namespace BucketSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 将待排序列通过事先设定好的映射函数分到有限数量的桶里。每个桶再进行排序（可以使用别的排序算法，比如快速排序）。
        /// 1. 准备有限数量的空桶
        /// 2. 遍历待排序列，将每个元素通过映射函数分配到对应的桶中
        /// 3. 对每个不是空的桶进行排序
        /// 4. 从每个不是空的桶中再依次把元素放回到原来的序列中
        /// </summary>

        public void BucketSort(int[] array){
            int max = array[0], min = array[0];
            for(int i = 1; i < array.Length; i ++){
                if(array[i] > max) max = array[i];
                if(array[i] < min) min = array[i];
            }
            List<int>[] buckets = new List<int>[Fun(max, min, array.Length) + 1];
            for(int i = 0; i < buckets.Length; i ++){
                buckets[i] = new List<int>();
            }
            for(int i = 0; i < array.Length; i ++){
                buckets[Fun(array[i], min, array.Length)].Add(array[i]);
            }
            int index = 0;
            for(int i = 0; i < buckets.Length; i ++){
                // 桶内的排序借助了Sort方法，也可以使用其他排序方法
                buckets[i].Sort();
                foreach(int item in buckets[i]){
                    array[index ++] = item;
                }
            }
        }

        public int Fun(int value, int minValue, int length){
            return (value - minValue) / length;
        }

        public void Test() {

            int[] array = new int[]{4, 1, 0, 2, 3};

            // array = new int[]{10, 25, 0, 0, 0, 58, 90, 1, 1, 0, 1, 952, 7896, 3, 44};
            // array = new int[]{7896, 0};

            BucketSort(array);

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
