/*
算法名称：
计数排序

时间复杂度：O(n + k)，k常数，即待排序的最大值

空间复杂度：O(n + k)

最好情况：
O(n + k)

最坏情况：
O(n + k)

稳定性：稳定

优点：稳定，适用于最大值不是很大的整数序列，在k值较小时突破了基于比较的排序的算法下限

缺点：存在前提条件，k值较大时，需要大量额外空间
*/
using System;
namespace CountSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 采用空间换时间的方法。
        /// 得到待排序列中的最大值，构建 最大值 + 1 的计数数组
        /// 遍历待排序列，在计数数组中统计每个元素出现的次数。出现一个元素，则以该元素值为索引的位置上计数加1
        /// 然后遍历计数数组，若对应索引上的值大于0，则表示存在有值为对应索引的元素，依次将存在的元素赋值到原始序列中
        /// </summary>

        public void CountSort(int[] array){
            int max = array[0];
            for(int i = 0; i < array.Length; i ++){
                if(array[i] > max) max = array[i];
            }
            int[] count = new int[max + 1];
            for(int i = 0; i < array.Length; i ++){
                count[array[i]] ++;
            }
            int index = 0;
            for(int i = 0; i < count.Length; i ++){
                while(count[i] -- > 0){
                    array[index ++] = i;
                }
            }
        }

        public void Test() {

            int[] array = new int[]{1, 4, 2, 3, 0};

            array = new int[]{1, 0, 1, 2, 0};

            array = new int[]{100, 3, 0, 1, 1, 4, 99, 30, 100};

            CountSort(array);

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
