/*
算法名称：
归并排序

时间复杂度：O(n*log(2, n))

空间复杂度：O(n)，因为在实现过程中用到了一个临时序列来暂存归并过程中的中间结果

最好情况：
O(n*log(2, n))

最坏情况：
O(n*log(2, n))

稳定性：稳定

优点：稳定，若采用单链表作为存储结构，可实现就地排序，不需要额外空间

缺点：需要O(n)的额外空间
*/
using System;
namespace MergeSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 所谓归并是指，把两个或两个以上的待排序列合并起来，形成一个新的有序序列。
        /// 2-路归并是指，将两个有序序列合并成为一个有序序列。
        /// 2-路归并排序的基本思想是，对于长度为n的无序序列来说，
        /// 归并排序把它看成是由n个只包括一个元素的有序序列组成，然后进行两两归并，最后形成包含n个元素的有序序列
        /// 即先将待排序列通过递归拆解成子序列，然后再对已经排好序的子序列进行合并
        /// </summary>

        public void MergeSort(int[] array){
            MergeSortImpl(array, 0, array.Length - 1);
        }

        public void MergeSortImpl(int[] array, int left, int right){
            if(left >= right) return;
            int middle = (left + right) / 2;
            MergeSortImpl(array, left, middle);
            MergeSortImpl(array, middle + 1, right);
            Merge(array, left, middle, right);
        }

        public void Merge(int[] array, int left, int middle, int right){
            int[] temp = new int[right - left + 1];
            int index = 0, lindex = left, rindex = middle + 1;
            while(lindex <= middle && rindex <= right){
                if(array[rindex] < array[lindex]){
                    temp[index ++] = array[rindex ++];
                }else{
                    temp[index ++] = array[lindex ++];
                }
            }
            while(lindex <= middle){
                temp[index ++] = array[lindex ++];
            }
            while(rindex <= right){
                temp[index ++] = array[rindex ++];
            }

            while(--index >= 0){
                array[left + index] = temp[index];
            }
            
        }

        public void Test() {

            int[] array = new int[]{1, 4, 2, 3, 5};
            // array = new int[]{0, 0, 0, 1, 1, 1, -1, -1, 0, -1};
            // array = new int[]{4, 3, 3, 2, 1, 2, 3, 4, 3, 2, -1};

            MergeSort(array);

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
