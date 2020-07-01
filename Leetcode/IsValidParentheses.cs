/*
题目名称：
有效的括号

题目描述：
给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
有效字符串需满足：
左括号必须用相同类型的右括号闭合。
左括号必须以正确的顺序闭合。
注意空字符串可被认为是有效字符串。

示例：
输入: "()"
输出: true

示例：
输入: "()[]{}"
输出: true

示例：
输入: "(]"
输出: false

示例：
输入: "([)]"
输出: false

示例：
输入: "{[]}"
输出: true

代码结构：
public class Solution {
    public bool IsValid(string s) {

    }
}

题目链接：
https://leetcode-cn.com/problems/valid-parentheses/
*/
using System;
using System.Collections.Generic;
namespace IsValidParentheses {

    class Solution {

        public bool IsValid(string s) {
            return true;
        }

        public void Test() {
            string s = "";
            
            Console.WriteLine(IsValid(s));
        }
    }
}
