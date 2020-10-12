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
        /// 解法1
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

        /// <summary>
        /// 解法2，动态规划
        /// 基本思路：
        /// 构建动态规划转移方程f[i,j]，表示字符串的前i个字符与模式串的前j个字符是否匹配
        /// 对于不包含"*"的情况
        ///     f[i, j] = f[i - 1, j - 1] && (str[i - 1] == pattern[j - 1] || pattern[j - 1] == '.');
        ///     表示前i个字符与模式串的前j个字符匹配的前提是，前i - 1个字符与前j - 1个字符匹配且第i个字符与第j个字符相等或第j个字符是"."
        /// 对于包含"*"的情况
        ///     "*"表示出现0次时
        ///         f[i, j] |= f[i, j - 2];
        ///         表示前i个字符与模式串的前j个字符匹配的前提是，前i个字符与前j - 2个字符匹配即可（相当于把x*忽略掉）
        ///     "*"表示出现1次或多次时
        ///         f[i, j] |= f[i - 1, j] && (str[i - 1] == pattern[j - 2] || pattern[j - 2] == '.');
        ///         表示前i个字符与模式串的前j个字符匹配的前提是，前i - 1个字符与前j个字符匹配且第i个字符与"*"前的字符相等或"*"前的字符是"."
        /// 补充说明
        /// f[0, 0]就表示空字符串与空模式串是否匹配
        /// f[1, 1]就表示字符串第一个字符与模式串第一个字符是否匹配
        /// f[str.Length, pattern.Length]就表示字符串str与模式串pattern是否匹配
        /// </summary>

        public bool Match2(char[] str, char[] pattern)
        {
            bool[,] f = new bool[str.Length + 1, pattern.Length + 1];
            for(int i = 0; i <= str.Length; i ++){
                for(int j = 0; j <= pattern.Length; j ++){
                    if(j == 0)
                        f[i, j] = i == 0;
                    else{
                        if(pattern[j - 1] == '*'){
                            if(j >= 2)
                                f[i, j] |= f[i, j - 2];
                                if(i > 0)
                                    f[i, j] |= f[i - 1, j] && (str[i - 1] == pattern[j - 2] || pattern[j - 2] == '.');
                        }else if(i > 0){
                            f[i, j] = f[i - 1, j - 1] && (str[i - 1] == pattern[j - 1] || pattern[j - 1] == '.');
                        }
                    }
                }
            }
            return f[str.Length, pattern.Length];
        }

        public void Test() {

            char[] str = new char[]{'a', 'a', 'a'};
            // str = new char[]{};
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
            // pattern = new char[]{'*', '*'};
            // pattern = new char[]{};
            // pattern = new char[]{'.'};

            // Console.WriteLine(Match(str, pattern));
            Console.WriteLine(Match2(str, pattern));
        }
    }
}
