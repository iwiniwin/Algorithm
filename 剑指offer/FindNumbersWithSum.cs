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

        public List<int> FindNumbersWithSum(int[] array, int sum)
        {
            List<int> list = new List<int>();
            list.Add(5);
            return list;
        }

        public void Print(List<int> list) {
            foreach(int i in list){
                Console.WriteLine(i);
            }
        }

        public void Test() {

            int[] array = new int[]{1, 2, 3};
            int sum = 100;
            // sum = 102;
            // sum = 1;

            List<int> list = FindNumbersWithSum(array, sum);
            Print(list);
        }
    }
}
