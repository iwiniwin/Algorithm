/*
算法名称：
简单选择排序

时间复杂度：O(n^2)

空间复杂度：O(1)

最好情况：
O(n^2)，此时不发生交换，但仍需进行比较

最坏情况：
O(n^2)

稳定性：不稳定，因为在将最小或最大元素替换到前面时，可能将排在前面的相等元素交换到后面去

优点：交换数据的次数已知(n - 1)次

缺点：不稳定，比较的次数多
*/
using System;
namespace SimpleSelectionSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 每一趟在待排序列中选出最小（或最大）的元素，依次放在已排好序的元素序列后面（或前面），直至全部的元素排完为止。
        /// 首先在待排序列中选出最小的元素，将它与第一个位置上的元素交换。
        /// 然后选出次小的元素，将它与第二个位置上的元素交换。以此类推，直至所有元素排成有序序列为止。
        /// 选择排序是对整体的选择。只有在确定了最小数（或最大数）的前提下才进行交换， 大大减少了交换的次数。
        /// </summary>

        public void SimpleSelectionSort(int[] array){
            for(int i = 0; i < array.Length - 1; i ++){
                int index = i;
                for(int j = index + 1; j < array.Length; j ++){
                    if(array[j] < array[index]){
                        index = j;
                    }
                }
                if(index != i)
                    Swap(array, i, index);
            }
        }

        public void Swap(int[] array, int i, int j){
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public void Test() {

            int[] array = new int[]{1, 4, 2, 3};
            // array = new int[]{1, 1, 1, 1, 0, 0, -1, -1};
            // array = new int[]{4, 4, 5, 1, 1, 1, -2, -2, -2, 3, 3, 3};

            SimpleSelectionSort(array);

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
