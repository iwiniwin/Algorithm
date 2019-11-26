/*
题目名称：
把数组排成最小的数

题目描述：
输入一个正整数数组，把数组里所有数字拼接起来排成一个数，打印能拼接出的所有数字中最小的一个。
例如输入数组{3，32，321}，则打印出这三个数字能排成的最小数字为321323。

代码结构：
class Solution
{
    public string PrintMinNumber(int[] numbers)
    {
        // write code here
    }
}
*/
using System;
namespace PrintMinNumber {
    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 将数组中的元素按从小到大的顺序排序，得到的就是最小数字。
        /// 使用任何的排序算法都可以，这里使用的是冒泡排序
        /// 重点是如何判断两个元素（不同元素的长度可能不同）的大小。
        /// 这里通过(a + b)和(b + a)判断，如果前者小于后者，则说明a < b，反之亦然。 
        /// </summary>
        public bool Less(string a, string b){
            return (a + b).CompareTo(b + a) < 0;
        }
        public void Swap(int[] numbers, int i, int j){
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
        public string PrintMinNumber(int[] numbers)
        {
            if (numbers == null){
                return "";
            }
            for(int i = 0; i < numbers.Length; i ++){
                for(int j = numbers.Length - 1; j > i; j --){
                    if(Less(numbers[j].ToString(), numbers[j - 1].ToString())){
                        Swap(numbers, j, j - 1);
                    }
                }
            }
            return string.Join("", numbers);
        }

        public void Test() {
            int[] numbers = new int[]{3, 32, 321};
            // numbers = new int[]{};
            // numbers = null;

            Console.WriteLine(PrintMinNumber(numbers));
        }
    }
}
