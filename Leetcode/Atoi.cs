/*
题目名称：
字符串转换整数 (atoi)

题目描述：
请你来实现一个 atoi 函数，使其能将字符串转换成整数。
首先，该函数会根据需要丢弃无用的开头空格字符，直到寻找到第一个非空格的字符为止。接下来的转化规则如下：
如果第一个非空字符为正或者负号时，则将该符号与之后面尽可能多的连续数字字符组合起来，形成一个有符号整数。
假如第一个非空字符是数字，则直接将其与之后连续的数字字符组合起来，形成一个整数。
该字符串在有效的整数部分之后也可能会存在多余的字符，那么这些字符可以被忽略，它们对函数不应该造成影响。
注意：假如该字符串中的第一个非空格字符不是一个有效整数字符、字符串为空或字符串仅包含空白字符时，则你的函数不需要进行转换，即无法进行有效转换。
在任何情况下，若函数不能进行有效的转换时，请返回 0 。

提示：
本题中的空白字符只包括空格字符 ' ' 。
假设我们的环境只能存储 32 位大小的有符号整数，那么其数值范围为 [−2^31,  2^31 − 1]。如果数值超过这个范围，请返回  INT_MAX (2^31 − 1) 或 INT_MIN (−2^31) 。

示例1：
输入: "42"
输出: 42

示例2：
输入: "   -42"
输出: -42
解释: 第一个非空白字符为 '-', 它是一个负号。
     我们尽可能将负号与后面所有连续出现的数字组合起来，最后得到 -42 。

示例3：
输入: "4193 with words"
输出: 4193
解释: 转换截止于数字 '3' ，因为它的下一个字符不为数字。

示例4：
输入: "words and 987"
输出: 0
解释: 第一个非空字符是 'w', 但它不是数字或正、负号。
     因此无法执行有效的转换。

示例5：
输入: "-91283472332"
输出: -2147483648
解释: 数字 "-91283472332" 超过 32 位有符号整数范围。 
     因此返回 INT_MIN (−2^31) 。

代码结构：
public class Solution {
    public int MyAtoi(string str) {

    }
}

题目链接：
https://leetcode-cn.com/problems/string-to-integer-atoi/

官方题解：
https://leetcode-cn.com/problems/string-to-integer-atoi/solution/zi-fu-chuan-zhuan-huan-zheng-shu-atoi-by-leetcode-/
*/
using System;
using System.Collections.Generic;
namespace Atoi {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 直观解法,遍历字符串每个字符
        /// 1. 过滤前面的空格字符
        /// 2. 处理可能出现的+，-号
        /// 3. 处理数字部分，注意越界情况的处理，采用逆处理，与(int.MaxValue - d) / 10进行比较
        /// </summary>

        public int MyAtoi(string str) {
            int res = 0, start = -1;
            for(int i = 0; i < str.Length; i ++){
                if(str[i] == ' ')
                    if(start == -1) continue; else break;
                else if(str[i] == '-' || str[i] == '+')
                    if(start == -1) start = i; else break;
                else if(str[i] >= '0' && str[i] <= '9'){
                    if(start == -1) start = i;
                    int d = str[i] - '0';
                    if(res > (int.MaxValue - d) / 10)
                        return str[start] == '-' ? int.MinValue : int.MaxValue;
                    res = res * 10 + d;
                }
                else break;
            }
            if(start != -1) return str[start] == '-' ? -res : res;
            return 0;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 与解法1思路相同，只是代码更加精简
        /// </summary>

        public int MyAtoi2(string str) {
            int res = 0, flag = 1;
            int i = 0, n = str.Length;
            while(i < n && str[i] == ' ') i ++;
            if(i < n && str[i] == '-') flag = -1;
            if(i < n && (str[i] == '-' || str[i] == '+')) i ++;
            while(i < n && str[i] >= '0' && str[i] <= '9'){
                int d = str[i] - '0';
                if(res > (int.MaxValue - d) / 10) return flag == 1 ? int.MaxValue : int.MinValue;
                res = res * 10 + d;
                i ++;
            }
            return flag * res;
        }

        public void Test() {
            string str = "-42";
            // str = "    426s s  ";
            // str = "25526465134156516146165515";
            // str = " -34 ";
            // str = " -91283472332 ";
            // str = " -abddd ";
            // str = "words and 987";
            // str = "";
            // str = " ";
            // str = "   +0 123";
            // str = "2147483647";
            // str = "2147483648";
            // str = "-2147483647";
            // str = "-2147483648";
            // str = "-2147483649";

            Console.WriteLine(MyAtoi(str));
            Console.WriteLine(MyAtoi2(str));
        }
    }
}
