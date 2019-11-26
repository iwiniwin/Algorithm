/*
题目名称：
拼接所有的字符串产生字典序最小的字符串

题目描述：
给定一个字符串的数组strs，请找到一种拼接顺序，
使得所有的字符串拼接起来组成的字符串是所有可能性中字典序最小的，并返回这个字符串。

输入描述：
输入包含多行，第一行包含一个整数n（ 1 <= n <= pow(10, 5) ）代表字符串数组strs的长度
后面n行，每行一个字符串，代表strs[i]（保证所有字符串长度都小于10）。

输出描述:
输出一行，包含一个字符串，代表返回的字典序最小的字符串。

备注:
时间复杂度O（nlog_2_n），额外空间复杂度O（1）。
*/

/// <summary>
/// 解题算法分析请参考 剑指offer/PrintMinNumber.cs
/// </summary>
using System;
namespace PrintMinString {
    
    class Solution {

        public int Compare(string a, string b){
            return (a + b).CompareTo((b + a));
        }
        public string PrintMinString(string[] strs){
            Array.Sort(strs, Compare);
            return string.Join("", strs);
        }

        public static void Test() {
            string input = Console.ReadLine();
            int n = int.Parse(input);
            string[] strs = new string[n];
            for(int i = 0; i < n; i ++){
                strs[i] = Console.ReadLine();
            }
            Solution s = new Solution();
            Console.WriteLine(s.PrintMinString(strs));
        }

    }
}