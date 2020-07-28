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

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 利用Split函数将字符串根据" "拆分成多个子字符串
        /// 依次翻转子字符串的顺序，然后再用Join函数通过" "连接起来
        /// </summary>

        public string Reverse(string str){
            char[] s = str.ToCharArray();
            int left = 0, right = s.Length - 1;
            while(left < right){
                char temp = s[left];
                s[left ++] = s[right];
                s[right --] = temp;
            }
            return new string(s);
        }

        public string ReverseWords(string s) {
            string[] strs = s.Split(" ");
            for(int i = 0; i < strs.Length; i ++){
                strs[i] = Reverse(strs[i]);
            }
            return string.Join(" ", strs);
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 循环遍历，通过' '找到每一个单词，然后反转该单词
        /// </summary>
        
        public void Reverse(char[] cs, int i, int j){
            while(i < j){
                char temp = cs[i];
                cs[i ++] = cs[j];
                cs[j --] = temp;
            }
        }

        public string ReverseWords2(string s) {
            char[] cs = s.ToCharArray();
            int i = 0, j = 0;
            while(i < cs.Length){
                while(j < cs.Length && cs[j] != ' ')
                    j ++;
                Reverse(cs, i, j - 1);
                i = ++j;
            }
            return new string(cs);
        }

        public void Test() {
            string s = "Let's take LeetCode contest";
            // s = "";
            // s = " a ";
            
            // Console.WriteLine(ReverseWords(s));
            Console.WriteLine(ReverseWords2(s));
        }
    }
}
