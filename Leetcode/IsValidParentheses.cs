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

官方题解：
https://leetcode-cn.com/problems/valid-parentheses/solution/you-xiao-de-gua-hao-by-leetcode/
*/
using System;
using System.Collections.Generic;
namespace IsValidParentheses {

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 枚举字符串每个字符，利用栈
        /// 如果是闭括号，则判断是否是栈顶元素对应的闭括号，如果是则弹出栈顶元素（找到了一对子有效括号）。
        /// 如果是其它括号，就入栈
        /// 最后如果栈中元素为0，则表示是有效括号，因为它的子串都是子有效括号，都被弹出了
        /// </summary>

        public bool IsValid(string s) {
            Stack<char> stack = new Stack<char>();
            for(int i = 0; i < s.Length; i ++){
                if(stack.Count == 0){
                    stack.Push(s[i]);
                    continue;
                }
                char top = stack.Peek();
                if((top == '(' && s[i] == ')') || (top == '[' && s[i] == ']') || (top == '{' && s[i] == '}'))
                    stack.Pop();
                else
                    stack.Push(s[i]);
            }
            return stack.Count == 0;
        }

        public void Test() {
            string s = "";
            s = "()";
            s = "()[]{}";
            s = "(]";
            s = "([)]";
            s = "{[]}";
            
            Console.WriteLine(IsValid(s));
        }
    }
}
