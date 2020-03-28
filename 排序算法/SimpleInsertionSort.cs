/*
算法名称：
简单插入排序

时间复杂度：O(n^2)

空间复杂度：O(1)

最好情况：
O(n) 正序有序，要插入的元素总是插入在末尾

最坏情况：
O(n^2) 逆序有序

稳定性：稳定

优点：稳定，快，如果序列是基本有序的，使用直接插入排序效率就非常高

缺点：比较次数不一定，比较次数越多，插入点后移的数据越多，特别是数据量庞大的时候。不过使用链表可以解决这个问题
*/
using System;
namespace SimpleInsertionSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 每次将一个待排序列的元素，按其大小插入到前面已经排好序序列中的合适位置，直到全部元素插完为止
        /// 自然地，插入的时候，后面的元素要依次往后移
        /// 这里默认待排序列的第一个元素是排好序的
        /// </summary>

        public void SimpleInsertionSort(int[] array){
            for(int i = 1; i < array.Length; i ++){
                int j = i;
                int target = array[j];
                while(j > 0 && target < array[j - 1]){
                    array[j] = array[j - 1];
                    j --;
                }
                array[j] = target;
            }
        }

        public void Test() {

            int[] array = new int[]{4, 1, 2, 3};
            // array = new int[]{1, 1, 1, 1, 0, 0};
            // array = new int[]{1};

            SimpleInsertionSort(array);

            Print(array);
        }

        public void Print(int[] array){
            foreach (int item in array)
            {
                Console.Write(item + "  ");
            }
        }
    }
}
