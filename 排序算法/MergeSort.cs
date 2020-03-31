/*
算法名称：
归并排序

时间复杂度：todo

空间复杂度：todo

最好情况：
todo

最坏情况：
todo

稳定性：todo

优点：todo

缺点：todo
*/
using System;
namespace MergeSort {

    class Solution {

        public void MergeSort(int[] array){
           
        }

        public void Test() {

            int[] array = new int[]{1, 4, 2, 3, 5};

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
