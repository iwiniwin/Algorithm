/*
题目名称：
反转字符串

题目描述：
编写一个函数，其作用是将输入的字符串反转过来。输入字符串以字符数组 char[] 的形式给出。
不要给另外的数组分配额外的空间，你必须原地修改输入数组、使用 O(1) 的额外空间解决这一问题。
你可以假设数组中的所有字符都是 ASCII 码表中的可打印字符。

示例 1：
输入：["h","e","l","l","o"]
输出：["o","l","l","e","h"]

示例 2：
输入：["H","a","n","n","a","h"]
输出：["h","a","n","n","a","H"]

代码结构：
public class Solution {
    public void ReverseString(char[] s) {

    }
}

题目链接：
https://leetcode-cn.com/problems/reverse-string/
*/
using System;
using System.Collections.Generic;
namespace ReverseString {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 第一个字符与倒数第一个字符交换，第二个与倒数第二个交换，第三个与倒数第三个。。。
        /// 对于反转字符数组的所有字符，实际上只需要交换 数组长度的一半 次即可
        /// </summary>
        
        public void ReverseString(char[] s) {
            int len = s.Length;
            for(int i = 0; i < len / 2; i ++){
                char temp = s[i];
                s[i] = s[len - 1 - i];
                s[len - 1 - i] = temp;
            }
        }

        /// <summary>
        /// 解法2，双指针
        /// 基本思路：
        /// 使用left指针指向数组头部，right指针指向数组尾部
        /// 交换left与right位置的元素同时，left向右移动，right向左移动
        /// 直到两个指针相遇则所有元素替换完毕
        /// </summary>
        
        public void ReverseString2(char[] s) {
            int left = 0, right = s.Length - 1;
            while(left < right){
                char temp = s[left];
                s[left++] = s[right];
                s[right--] = temp;
            }
        }

        public void Print(char[] s){
            foreach (var c in s)
            {
                Console.Write(c + " ");
            }
        }

        public void Test() {
            char[] s = new char[]{'h','e','l','l','o'};
            // s = new char[]{'H', 'a', 'n', 'n', 'a', 'h'};
            // s = new char[]{};
            // s = new char[]{'a'};
            
            // ReverseString(s);
            ReverseString2(s);

            Print(s);
        }
    }
}
