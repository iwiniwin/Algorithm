/*
题目名称：
左旋转字符串

题目描述：
汇编语言中有一种移位指令叫做循环左移（ROL），现在有个简单的任务，就是用字符串模拟这个指令的运算结果。
对于一个给定的字符序列S，请你把其循环左移K位后的序列输出。
例如，字符序列S=”abcXYZdef”,要求输出循环左移3位后的结果，即“XYZdefabc”。是不是很简单？OK，搞定它！

代码结构：
class Solution
{
    public string LeftRotateString(string str, int n)
    {
        // write code here
    }
}
*/
using System;
namespace LeftRotateString {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 利用对字符串的长度求余，处理左移位数大于字符串长度的情况
        /// 小于字符串长度的左移，通过分割字符串后调转位置得到
        /// </summary>

        public string LeftRotateString(string str, int n)
        {
            if(str == null || str.Length == 0){
                return str;
            }
            int index = n % str.Length;
            char[] array = str.ToCharArray();
            return new string(array, index, str.Length - index) + new string(array, 0, index);
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 同样利用对字符串的长度求余，处理左移位数大于字符串长度的情况
        /// 对于小于字符串长度的左移，利用 XY的翻转 = YX = （Y的翻转 + X的翻转）的翻转 得到
        /// </summary>

        public void Reverse(char[] array, int i, int j){
            for(int m = i, n = j; m < n; m ++, n --){
                char temp = array[m];
                array[m] = array[n];
                array[n] = temp;
            }
        }

        public string LeftRotateString2(string str, int n)
        {
            if(str == null || str.Length == 0){
                return str;
            }
            int index = n % str.Length;
            char[] array = str.ToCharArray();
            Reverse(array, 0, index - 1);
            Reverse(array, index, array.Length - 1);
            Reverse(array, 0, array.Length - 1);
            return new string(array);
        }

        public void Test() {

            string str = "abcXYZdef";
            // str = null;
            // str = "";

            int n = 3;
            // n = 0;
            // n = 1;
            // n = 9;
            // n = 10;

            Console.WriteLine(LeftRotateString(str, n));
            // Console.WriteLine(LeftRotateString2(str, n));
        }
    }
}
