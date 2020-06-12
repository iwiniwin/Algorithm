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

官方题解：
https://leetcode-cn.com/problems/longest-common-prefix/solution/zui-chang-gong-gong-qian-zhui-by-leetcode/
*/
using System;
using System.Collections.Generic;
namespace LongestCommonPrefix {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 从前往后枚举字符串的每一列
        /// 比较字符串数组中每个字符串对应列是否相等
        /// </summary>

        public string LongestCommonPrefix(string[] strs) {
            if(strs == null || strs.Length == 0) return "";
            for(int i = 0; i < strs[0].Length; i ++){
                for(int j = 1; j < strs.Length; j ++){
                    if(i >= strs[j].Length || strs[j][i] != strs[0][i])
                        return strs[0].Substring(0, i);
                }
            }
            return strs[0];
        }

        public void Test() {
            string[] strs = new string[]{"flower", "flow", "flight"};
            // strs = new string[]{"dog", "racecar", "car"};
            // strs = null;
            // strs = new string[]{};
            // strs = new string[]{""};
            // strs = new string[]{"flower", "flower", "flower"};
            
            Console.WriteLine(LongestCommonPrefix(strs));
        }
    }
}
