/*
题目名称：
正则表达式匹配

题目描述：
请实现一个函数用来匹配包括'.'和'*'的正则表达式。
模式中的字符'.'表示任意一个字符，而'*'表示它前面的字符可以出现任意次（包含0次）。 
在本题中，匹配是指字符串的所有字符匹配整个模式。
例如，字符串"aaa"与模式"a.a"和"ab*ac*a"匹配，但是与"aa.a"和"ab*a"均不匹配

代码结构：
class Solution
{
    public bool match(char[] str, char[] pattern)
    {
        // write code here
    }
}
*/
using System;
namespace Match {

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 当出现x*时，即任意一个字符加上'*'
        /// 1. x*消耗0个字符，模式串后移两位，字符串不动
        /// 2. x*消耗1个字符，模式串后移两位，字符串后移一位
        /// 3. x*消耗多个字符，即匹配下一个字符，模式串不动，字符串后移一位
        /// （注意，当这个'x'和字符串对应位的字符不相等时，x*只能等于消耗0个字符）
        /// 未出现时
        /// 1. 若模式串与字符串对应位字符相等，则都后移一位，匹配剩余的
        /// 2. 若不相等，直接返回匹配失败
        /// </summary>

        public bool MatchImpl(char[] str, int sIndex, char[] pattern, int pIndex) {
            if(sIndex == str.Length && pIndex == pattern.Length) return true;
            if(pIndex < pattern.Length - 1 && pattern[pIndex + 1] == '*'){
                if (sIndex < str.Length && (str[sIndex] == pattern[pIndex]
                    || pattern[pIndex] == '.')) {
                    return MatchImpl(str, sIndex, pattern, pIndex + 2) 
                        || MatchImpl(str, sIndex + 1, pattern, pIndex) 
                        || MatchImpl(str, sIndex + 1, pattern, pIndex + 2);
                }else{
                    return MatchImpl(str, sIndex, pattern, pIndex + 2);
                }
            }
            if(sIndex >= str.Length || pIndex >= pattern.Length) return false;
            if(str[sIndex] == pattern[pIndex] || pattern[pIndex] == '.') {
                return MatchImpl(str, sIndex + 1, pattern, pIndex + 1);
            }else {
                return false;
            }
        }

        public bool Match(char[] str, char[] pattern)
        {
            return MatchImpl(str, 0, pattern, 0);
        }

        public void Test() {

            char[] str = new char[]{'a', 'a', 'a'};
            str = new char[]{};
            // str = new char[]{'a', 'b', 'b', 'b', '*'};
            // str = new char[]{'a', 'b', 'b', 'b'};
            // str = new char[]{'a', 'b', 'c', '.', '*', 'f', '*', 's'};
            // str = new char[]{'a'};
            // str = new char[]{'a', 'a'};

            char[] pattern = new char[]{'a', '.', 'a'};
            // pattern = new char[]{'a', '*', 'a', 'a'};
            // pattern = new char[]{'b', '*', 'a', 'a', 'a'};
            // pattern = new char[]{'b', '*'};
            // pattern = new char[]{'a', 'b', '*'};
            // pattern = new char[]{'a', 'b', '*', '*'};
            // pattern = new char[]{'.', '*'};
            pattern = new char[]{'*', '*'};
            // pattern = new char[]{};
            // pattern = new char[]{'.'};

            Console.WriteLine(Match(str, pattern));
        }
    }
}
