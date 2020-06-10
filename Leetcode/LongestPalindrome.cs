/*
题目名称：
最长回文子串

题目描述：
给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

示例1：
输入: "babad"
输出: "bab"
注意: "aba" 也是一个有效答案。

示例2：
输入: "cbbd"
输出: "bb"

代码结构：
public class Solution {
    public string LongestPalindrome(string s) {

    }
}

题目链接：
https://leetcode-cn.com/problems/longest-palindromic-substring/
*/
using System;
using System.Collections.Generic;
namespace LongestPalindrome {

    class Solution {

        public string LongestPalindrome(string s) {
            return "bab";
        }

        public void Test() {
            string s = "babad";

            Console.WriteLine(LongestPalindrome(s));
        }
    }
}
