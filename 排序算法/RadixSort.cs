/*
算法名称：
基数排序

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
using System.Collections.Generic;
namespace RadixSort {

    class Solution {

        public void RadixSort(int[] array){

            int bit = GetMaxBit(array);

            // 构建 r = 10 个队列
            Queue<int>[] buffer = new Queue<int>[10];
            for(int i = 0; i < buffer.Length; i ++){
                buffer[i] = new Queue<int>();
            }

            for(int i = 0; i < bit; i ++){
                Distribute(array, buffer, i);
                Collect(array, buffer);
            }
        }

        // 获得待排序列中元素的最大位数
        public int GetMaxBit(int[] array){
            int bit = 0, len = 0;
            for(int i = 0; i < array.Length; i ++){
                len = array[i].ToString().Length;
                if(len > bit) bit = len;
            }
            return bit;
        }

        // 分配
        public void Distribute(int[] array, Queue<int>[] buffer, int bit){
            int value = 0;
            string str = "";
            for(int i = 0; i < array.Length; i ++){
                str = array[i].ToString();
                if(bit < str.Length){
                    value = (int)(str[str.Length - bit - 1] - '0');
                }else{
                    value = 0;
                }
                buffer[value].Enqueue(array[i]);
            }
        }

        // 收集
        public void Collect(int[] array, Queue<int>[] buffer){
            int index = 0;
            for(int i = 0; i < buffer.Length; i ++){
                while(buffer[i].Count > 0){
                    array[index ++] = buffer[i].Dequeue(); 
                }
            }
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
