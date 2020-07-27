/*
题目名称：
反转字符串中的单词 III

题目描述：
给定一个字符串，你需要反转字符串中每个单词的字符顺序，同时仍保留空格和单词的初始顺序。

示例 1：
输入: "Let's take LeetCode contest"
输出: "s'teL ekat edoCteeL tsetnoc" 

注意：
在字符串中，每个单词由单个空格分隔，并且字符串中不会有任何额外的空格。

代码结构：
public class Solution {
    public string ReverseWords(string s) {

    }
}

题目链接：
https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/
*/
using System;
using System.Collections.Generic;
namespace ReverseWords {

    class Solution {

        public string ReverseWords(string s) {
            return s;
        }

        public void Test() {
            string s = "Let's take LeetCode contest";
            
            Console.WriteLine(ReverseWords(s));
        }
    }
}
