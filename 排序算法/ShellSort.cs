/*
算法名称：
希尔排序

时间复杂度：O(n*log(2, n))

空间复杂度：O(1)

最好情况：
O(n*log(2, n)) 因为希尔排序的执行时间依赖于增量d，如何选择增量使得希尔排序的元素比较次数和移动次数较少
这个问题目前还未能解决

最坏情况：
O(n*log(2, n))

稳定性：不稳定 相同元素可能分在不同的组内，导致顺序可能发生改变

优点：快，数据移动少

缺点：不稳定，d的取值是多少，应该取多少个不同的值，都无法确切知道，只能凭经验来取
*/
using System;
namespace ShellSort {

    class Solution {

        /// <summary>
        /// 基本思想：
        /// 希尔排序是直接插入排序算法的优化，又称为缩小增量式插入排序
        /// 对于待排数组，取一个增量d，根据增量d作为下标间隔，将待排数组分割成若干个组
        /// 各组内部做直接插入排序，然后不断减小增量d，重复上述过程
        /// 直到增量d为1时，即所有元素在同一组内进行直接插入排序，完成最终的排序
        /// </summary>

        public void ShellSort(int[] array){
            int d = array.Length / 2;
            while(d >= 1){
                for(int i = d; i < array.Length; i ++){
                    int j = i;
                    int target = array[j];
                    while(j >= d && target < array[j -d]){
                        array[j] = array[j - d];
                        j -= d;
                    }
                    array[j] = target;
                }
                d /= 2;
            }
        }

        public void Test() {

            int[] array = new int[]{1, 3, 2, 4};
            // array = new int[]{0, 1, 0, 0, 0, -1, 1};
            array = new int[]{4, 4, 5, 1, 1, 1, -2, -2, -2, 3, 3, 3};

            ShellSort(array);

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
