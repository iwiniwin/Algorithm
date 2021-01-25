/*
算法名称：
KMP模式匹配算法

算法描述：
子串定位运算又称为模式匹配（Pattern Matching）或串匹配（String Matching）。
KMP算法，是不需要对目标串S进行回溯的模式匹配算法。此算法是由D.E.Knuth，J.H.Morris和V.R.Pratt同时发现的，
因此该算法被称为克努斯-莫里斯-普拉特操作，简称为KMP算法。
匹配成功，返回模式串在目标串中的位置；或者目标串中不存在与模式串相等的子串，则匹配失败，返回-1.
*/
using System;
namespace KMP {

    class Solution {

        /// <summary>
        /// 暴力匹配算法 Brute-Force
        /// 基本思路：
        /// 朴素的模式匹配算法，从目标串s的第一个字符开始和模式串p的第一个字符开始比较，
        /// 如果相等，则进一步比较二者的后继字符
        /// 如果不相等，则从目标串s的第二个字符开始再重新与模式串p的第一个字符进行比较
        /// 暴力匹配就在于当发生失配时，目标串直接回溯到开始匹配字符的下一个字符，模式串直接回溯到第一个字符
        /// </summary>
        public int BF(string s, string p){
            int i = 0, j = 0;
            while(i < s.Length && j < p.Length) {
                if(s[i] == p[j]) {
                    i ++;
                    j ++;
                }else{
                    i = i - j + 1;
                    j = 0;
                }
            }
            if(j == p.Length) {
                return i - j;
            }
            return -1;
        }

        /// <summary>
        /// 求解next数组
        /// 基本思路：
        /// next[j] = i就表示对于p[j]前面的子串（不包含p[j]）有长度为i的前缀序列与后缀序列相等
        /// 即 p[0], p[1], p[2] .. p[i - 1] = p[j - i], p[j - i + 1], p[j - i + 2] .. p[j - 1]
        /// next数组求解详细解读 https://www.cnblogs.com/iwiniwin/p/10793659.html
        /// </summary>

        public int[] GetNext(string p){
            int[] next = new int[p.Length];
            int i = -1, j = 0;
            next[j] = i;
            while(j < p.Length - 1){
                if(i == -1 || p[i] == p[j]){
                    i ++;
                    j ++;
                    if(p[i] == p[j])
                        next[j] = next[i];  // 优化，当p[j]失配时，由于p[i] = p[j]，p[i]一定也失配，所以直接回溯到next[i]
                    else
                        next[j] = i;
                }else{
                    i = next[i];
                }
            }
            return next;
        }

        /// <summary>
        /// 基本思路：
        /// 在模式匹配过程中，当匹配失败时，保证对目标串s不进行回溯
        /// 模式串p回溯到哪里通过next数组的值来确定
        /// KMP算法详细解读 https://www.cnblogs.com/iwiniwin/p/10793659.html
        /// </summary>

        public int KMP(string s, string p){
            int i = 0, j = 0;
            int[] next = GetNext(p);
            while(i < s.Length && j < p.Length){
                if(j == -1 || s[i] == p[j]){
                    i ++;
                    j ++;
                }else{
                    j = next[j];  // 根据next数组的指引对p进行回溯
                }
            }
            if(j == p.Length)
                return i - j;
            else
                return -1;
        }

        public void Test() {

            string s = "ababb";
            s = "ababcabcacb";
            // s = "aaaabcde";

            string p = "abb";
            p = "abc";
            p = "abcac";
            // p = "aaaaax";

            // Console.WriteLine(BF(s, p));

            Console.WriteLine(KMP(s, p));
        }
    }
}
