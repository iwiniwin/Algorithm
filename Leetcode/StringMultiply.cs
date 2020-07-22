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
using System.Text;
using System.Collections.Generic;
namespace StringMultiply {

    class Solution {

        /// <summary>
        /// 解法1，模拟竖式乘法
        /// 基本思路：
        /// 将第一个字符串分别与第二个字符串的每个字符相乘
        /// 将相乘的结果（除了第一位之外需要补0）再相加即得到结果
        /// 字符串与字符相乘算法Multiply(string num, char c) 类似于 字符串与字符串相加算法 Add(string num1, string num2)
        /// 字符串相加算法解释可以参考 AddStrings.cs
        /// </summary>

        public string Multiply(string num1, string num2) {
            string res = "";
            string product = "";
            for(int i = num2.Length - 1; i >= 0; i --){
                product = Multiply(num1, num2[i]);
                if(product != "0") product += new string('0', num2.Length - 1 - i);
                res = Add(res, product);
            }
            return res;
        }

        public string Add(string num1, string num2){
            int i = num1.Length - 1, j = num2.Length - 1;
            int carry = 0, sum = 0;
            string res = "";
            while(i >= 0 || j >= 0){
                int n1 = i >= 0 ? num1[i] - '0' : 0;
                int n2 = j >= 0 ? num2[j] - '0' : 0;
                sum = n1 + n2 + carry;
                res = (sum % 10) + res;
                carry = sum / 10;
                i --; j --;
            }
            if(carry == 1) res = 1 + res;
            return res;
        }

        public string Multiply(string num, char c){
            string res = "";
            int carry = 0, product = 0;
            int n = c - '0';
            if(n == 0) return "0";
            if(n == 1) return num;
            for(int i = num.Length - 1; i >= 0; i --){
                product = (num[i] - '0') * n + carry;
                res = (product % 10) + res;
                carry = product / 10;
            }
            if(carry > 0) res = carry + res;
            return res;
        }

        /// <summary>
        /// 解法2，竖式乘法优化
        /// 基本思路：
        /// 优化的依据如下：
        /// 对于字符串num1，长度为M，字符串num2，长度为N
        /// num1与num2乘积的结果字符串res，最长是 M + N 位
        /// 比如 "99" * "99" ，结果是 "9801"，长度最长是4位
        /// 对于num1的第i位与num2的第j位 （位数即下标，从0开始，从左到右依次递增）
        /// num1[i]与num2[j]相乘结果的个位一定位于res[i + j + 1]，十位一定位于res[i + j]  （两个个位数相乘最多是两位数）
        /// 比如 "98" * "76" 中的 第0位 '9' 与 第1位 '6' 相乘，是 "54"
        /// 个位 '4' 一定是位于最终结果的第 0 + 1 + 1 = 2 位，十位 '5' 一定是位于最终结果的第 0 + 1 = 1位
        /// </summary>

        public string Multiply2(string num1, string num2){
            StringBuilder sum = new StringBuilder(new String('0', num1.Length + num2.Length));
            for(int i = num1.Length - 1; i >= 0; i --){
                for(int j = num2.Length - 1; j >= 0; j --){
                    int product = (sum[i + j + 1] - '0') + (num1[i] - '0') * (num2[j] - '0');
                    sum[i + j + 1] = (char)(product % 10 + '0');
                    sum[i + j] += (char)(product / 10);
                }
            }
            string res = sum.ToString().TrimStart('0');
            return res.Length == 0 ? "0" : res;
        }

        public void Test() {
            string num1 = "123";
            num1 = "0";
            // num1 = "1";
            // num1 = "956";
            // num1 = "956100";

            string num2 = "956";
            num2 = "0";
            
            // Console.WriteLine(Multiply(num1, num2));
            Console.WriteLine(Multiply2(num1, num2));
        }
    }
}
