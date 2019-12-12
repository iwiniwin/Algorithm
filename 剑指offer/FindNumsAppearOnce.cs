/*
题目名称：
数组中只出现一次的数字

题目描述：
一个整型数组里除了两个数字之外，其他的数字都出现了两次。请写程序找出这两个只出现一次的数字。

代码结构：
//num1,num2分别为长度为1的数组。传出参数
//将num1[0],num2[0]设置为返回结果
class Solution
{
    public void FindNumsAppearOnce(int[] array, int[] num1, int[] num2)
    {
        // write code here
    }
}
*/
using System;
namespace FindNumsAppearOnce {

    class Solution {

        public void FindNumsAppearOnce(int[] array, int[] num1, int[] num2)
        {
            // write code here
        }

        public void Test() {

            int[] array = new int[]{};

            int[] num1 = new int[1];
            int[] num2 = new int[1];
            FindNumsAppearOnce(array, num1, num2);

            Console.WriteLine(num1[0]);
            Console.WriteLine(num2[0]);
        }
    }
}
