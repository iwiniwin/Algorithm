/*
题目名称：
字符串相乘

题目描述：
给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。

示例 1:
输入: num1 = "2", num2 = "3"
输出: "6"

示例 2:
输入: num1 = "123", num2 = "456"
输出: "56088"

说明：
1. num1 和 num2 的长度小于110。
2. num1 和 num2 只包含数字 0-9。
3. num1 和 num2 均不以零开头，除非是数字 0 本身。
4. 不能使用任何标准库的大数类型（比如 BigInteger）或直接将输入转换为整数来处理。

代码结构：
public class Solution {
    public string Multiply(string num1, string num2) {

    }
}

题目链接：
https://leetcode-cn.com/problems/multiply-strings/
*/
using System;
using System.Collections.Generic;
namespace StringMultiply {

    class Solution {

        public string Multiply(string num1, string num2) {
            return "";
        }

        public void Test() {
            string num1 = "123";

            string num2 = "456";
            
            Console.WriteLine(Multiply(num1, num2));
        }
    }
}
