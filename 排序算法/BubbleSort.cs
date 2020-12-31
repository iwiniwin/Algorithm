/*
算法名称：
冒泡排序

时间复杂度：O(n^2)

空间复杂度：O(1)

最好情况：
正序有序时，普通冒泡排序仍是O(n^2)，优化后的冒泡排序是O(n)

最坏情况：
逆序有序时，O(n^2)

稳定性：稳定

优点：简单，稳定，空间复杂度低

缺点：时间复杂度高，效率不好
*/
using System;
namespace BubbleSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 从序列的末尾开始，针对每一个元素，与其相邻的元素进行比较，若不满足条件，则进行交换
        /// 这样每一次都会有一个相对最小的元素如气泡一般逐渐往上漂浮至水面
        /// </summary>

        public void BubbleSort(int[] array){
            for(int i = 0; i < array.Length - 1; i ++){
                for(int j = array.Length - 1; j > i ; j --){
                    if(array[j] < array[j - 1]){
                        Swap(array, j, j - 1);
                    }
                }
            }
        }

        /// <summary>
        /// 基本思想：
        /// 优化正序有序时的复杂度，当第一次冒泡排序后没有发生位置交换
        /// 则说明所有元素都已经正确的在其位置上，结束算法即可
        /// </summary>

        public void BubbleSortOptimize(int[] array){
            for(int i = 0; i < array.Length - 1; i ++){
                bool swapTag = false;  // 标志位，判断每完成一趟冒牌排序是否发生交换
                for(int j = array.Length - 1; j > i; j --){
                    if(array[j] < array[j - 1]){
                        Swap(array, j, j -1);
                        swapTag = true;
                    }
                }
                if(!swapTag){
                    break;
                }
            }
        }

        public void Swap(int[] array, int i, int j){
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public void Test() {

            int[] array = new int[]{1, 3, 2, 4};
            array = new int[]{1, 1, 3, 3, 4, 2, 2, 6, 1, 9};

            // BubbleSort(array);
            BubbleSortOptimize(array);

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
