/*
题目名称：
调整数组顺序使奇数位于偶数前面

题目描述：
输入一个整数数组，实现一个函数来调整该数组中数字的顺序，
使得所有的奇数位于数组的前半部分，所有的偶数位于数组的后半部分，
并保证奇数和奇数，偶数和偶数之间的相对位置不变。

代码结构：
class Solution
{
    public int[] reOrderArray(int[] array)
    {
        // write code here
    }
}
*/
using System;
namespace ReOrderArray {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 最直接的思路是再构建一个新的临时数组
        /// 先遍历一遍原数组，把其中的奇数依次添加到新数组中
        /// 再遍历一遍原数组把其中的偶数依次添加到新数组中
        /// 时间复杂度为O(2n)
        /// </summary>

        public int[] ReOrderArray(int[] array)
        {
            int[] temp = new int[array.Length];
            int index = 0;
            for(int i = 0; i < array.Length; i ++){
                if(array[i] % 2 != 0)
                    temp[index ++] = array[i];
            }
            for(int i = 0; i < array.Length; i ++){
                if(array[i] % 2 == 0)
                    temp[index ++] = array[i];
            }
            return temp;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 解法1用到了临时数组，空间复杂度是O(n)，某些情况下可能希望空间复杂度越低越好。
        /// 解法2虽然时间复杂度提高了，但降低了空间复杂度，不再需要额外的空间。
        /// 基本思路是遍历原数组，如果遇到了奇数元素，就将该元素向前移动，该元素前面的偶数元素都依次向后移动。
        /// 可以这样理解，每发现一个奇数时，就将这个奇数移动到了它最终应该在的位置上。
        /// </summary>

        public int[] ReOrderArray2(int[] array)
        {
            for(int i = 0; i < array.Length; i ++){
                if(array[i] % 2 != 0){
                    int j = i, target = array[i];
                    while(j > 0 && array[j - 1] % 2 == 0){
                        array[j] = array[j - 1];
                        j --;
                    }
                    array[j] = target;
                }
            }
            return array;
        }

        public void Print(int[] array){
            foreach(int item in array){
                Console.WriteLine(item);
            }
        }
        
        public void Test() {

            int[] array = new int[]{1, 4, 3, 7, 2, 5, 6};
            array = new int[]{4, 4, 4, 2, 5, 3, 6, 2};
            array = new int[]{-4, 4, -4, 2, -5, 3, 6, 2, -1};

            // Print(ReOrderArray(array));
            Print(ReOrderArray2(array));
        }
    }
}
