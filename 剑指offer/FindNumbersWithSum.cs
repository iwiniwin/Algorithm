/*
题目名称：
和为S的两个数字

题目描述：
输入一个递增排序的数组和一个数字S，在数组中查找两个数，使得他们的和正好是S。
如果有多对数字的和等于S，输出两个数的乘积最小的。

输出描述:
对应每个测试案例，输出两个数，小的先输出。

代码结构：
class Solution
{
    public List<int> FindNumbersWithSum(int[] array, int sum)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace FindNumbersWithSum {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 使用双指针left, right，左右逼近。题目要求乘积最小的先输出，实际上两个数离得越远，乘积越小
        /// 如果array[left] + array[right] == sum，得到答案
        /// 如果array[left] + array[right] < sum，left++，left指针右移
        /// 如果array[left] + array[right] > sum，right--，right指针左移
        /// </summary>

        public List<int> FindNumbersWithSum(int[] array, int sum)
        {
            List<int> list = new List<int>();
            if(array == null){
                return list;
            }
            int left = 0, right = array.Length - 1;
            while(left < right){
                int cur = array[left] + array[right];
                if(cur == sum){
                    list.Add(array[left]);
                    list.Add(array[right]);
                    break;
                }else if(cur < sum){
                    left ++;
                }else{
                    right --;
                }
            }
            return list;
        }

        /// <summary>
        /// 解法1结合二分查找
        /// 基本思路：
        /// 本来直接使用解法1就可以AC了，不过我第一次提交的时候可能牛客出了什么问题，提示超时，所以有了这个结合二分查找的思路
        /// 利用三个指针start(指向左边的值)，left, right。其中left和right通过二分查找，寻找右边的值
        /// 当右边的值未找到时，start++，start指针右移，start右边的数组继续进行二分查找
        /// 通过保证start指向的值是左边值中最小的来确定得到的两个数乘积最小
        /// </summary>

        public List<int> FindNumbersWithSum2(int[] array, int sum)
        {
            List<int> list = new List<int>();
            if(array == null){
                return list;
            }
            int start = 0;
            int left = 1, right = array.Length - 1;
            while(start < right){
                int mid = (left + right) / 2;
                int cur = array[start] + array[mid];
                if(cur == sum){
                    list.Add(array[start]);
                    list.Add(array[mid]);
                    break;
                }else if(cur < sum){
                    left = mid + 1;
                }else{
                    right = mid - 1;
                }
                if(left > right){
                    start ++;
                    left = start + 1;
                }
            }
            return list;
        }

        public void Print(List<int> list) {
            foreach(int i in list){
                Console.WriteLine(i);
            }
        }

        public void Test() {

            int[] array = new int[]{1, 2, 3, 3, 4, 4, 5, 6};
            // array = null;

            int sum = 8;
            // sum = 7;
            // sum = 100;
            // sum = 1;

            List<int> list = FindNumbersWithSum(array, sum);
            // List<int> list = FindNumbersWithSum2(array, sum);
            Print(list);
        }
    }
}
