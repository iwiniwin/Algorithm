/*
题目名称：
最长公共前缀

题目描述：
编写一个函数来查找字符串数组中的最长公共前缀。
如果不存在公共前缀，返回空字符串 ""。

示例1：
输入: ["flower","flow","flight"]
输出: "fl"

示例2：
输入: ["dog","racecar","car"]
输出: ""
解释: 输入不存在公共前缀。

说明：
所有输入只包含小写字母 a-z 。

代码结构：
public class Solution {
    public string LongestCommonPrefix(string[] strs) {

    }
}

题目链接：
https://leetcode-cn.com/problems/longest-common-prefix/
*/
using System;
using System.Collections.Generic;
namespace LongestCommonPrefix {

    class Solution {

        public string LongestCommonPrefix(string[] strs) {
            return "test";
        }

        public void Test() {
            string[] strs = new string[]{"flower", "flow", "flight"};
            
            Console.WriteLine(LongestCommonPrefix(strs));
        }
    }
}
