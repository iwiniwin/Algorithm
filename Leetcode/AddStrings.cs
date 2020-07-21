/*
题目名称：
字符串相加

题目描述：
给定两个字符串形式的非负整数 num1 和num2 ，计算它们的和。

注意：
1. num1 和 num2 的长度都小于 5100.
2. num1 和 num2 都只包含数字 0-9.
3. num1 和 num2 都不包含任何前导零。
4. 你不能使用任何內建 BigInteger 库， 也不能直接将输入的字符串转换为整数形式。

代码结构：
public class Solution {
    public string AddStrings(string num1, string num2) {

    }
}

题目链接：
https://leetcode-cn.com/problems/add-strings/
*/
using System;
using System.Collections.Generic;
namespace AddStrings {

    class Solution {

        /// <summary>
        /// 解法，模拟竖式加法
        /// 基本思路：
        /// 使用i, j两个指针指向两个字符串的末尾
        /// 从字符串末尾开始向前依次相加i，j所指向的元素
        /// 将两数之和对10求余，获取该位上的数值
        /// 将两数之和除以10，获取是否有进位
        /// 当较短的字符串先走完时，均以0代替
        /// </summary>

        public string AddStrings(string num1, string num2) {
            string res = "";
            int i = num1.Length - 1, j = num2.Length - 1;
            int carry = 0;
            while(i >= 0 || j >= 0){
                int n1 = i >= 0 ? num1[i] - '0' : 0;
                int n2 = j >= 0 ? num2[j] - '0' : 0;
                int sum = n1 + n2 + carry;
                res = (sum % 10) + res;
                carry = sum / 10;
                i --;
                j --;
            }
            if(carry == 1) res = 1 + res;
            return res;
        }

        public void Test() {
            string num1 = "129";
            // num1 = "0";
            // num1 = "1";

            string num2 = "459";
            // num2 = "9";
            
            Console.WriteLine(AddStrings(num1, num2));
        }
    }
}
