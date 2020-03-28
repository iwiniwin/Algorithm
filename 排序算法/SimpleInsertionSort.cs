/*
算法名称：
简单插入排序

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
namespace SimpleInsertionSort {

    class Solution {

        public void SimpleInsertionSort(int[] array){

        }

        public void Test() {

            int[] array = new int[]{4, 1, 2, 3};

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
