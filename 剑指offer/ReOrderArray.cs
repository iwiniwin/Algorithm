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

        public int[] ReOrderArray(int[] array)
        {
            return array;
        }

        public void Print(int[] array){
            foreach(int item in array){
                Console.WriteLine(item);
            }
        }
        
        public void Test() {

            int[] array = new int[]{1, 5, 3, 7, 2, 4};

            Print(ReOrderArray(array));
        }
    }
}
