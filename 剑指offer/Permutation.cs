/*
题目名称：
字符串的排列

题目描述：
输入一个字符串,按字典序打印出该字符串中字符的所有排列。
例如输入字符串abc,则打印出由字符a,b,c所能排列出来的所有字符串abc,acb,bac,bca,cab和cba。

输入描述:
输入一个字符串,长度不超过9(可能有字符重复),字符只包括大小写字母。

代码结构：
class Solution
{
    public List<string> Permutation(string str)
    {
        // write code here
    }
}
*/

using System;
using System.Collections.Generic;
namespace Permutation {
    class Solution {

        /*解法1，递归
        基本思路：
        对于目标字符串，每次首先确定第一个字符。例如对于字符串abc，则第一个字符可以是a或b或c
        然后将除去选取的第一个字符外的剩下字符串进行递归，重复上面的操作，直到剩下的字符串长度为1为止。
        通过HashSet过滤重复的字符串，通过Sort方法进行排序

        对于字符串abc，递归过程如下所示
        选取a为第一个字符（剩下字符串bc）
            选取b为第一个字符（剩下字符串c，长度为1，结束低估，得到字符串abc）
            选取c为第一个字符（剩下字符串b，长度为1，结束低估，得到字符串acb）
        选取b为第一个字符（剩下字符串ac）
            选取a为第一个字符（剩下字符串c，长度为1，结束低估，得到字符串bac）
            选取c为第一个字符（剩下字符串b，长度为1，结束低估，得到字符串bca）
        选取c为第一个字符（剩下字符串ab）
            选取a为第一个字符（剩下字符串c，长度为1，结束低估，得到字符串cab）
            选取b为第一个字符（剩下字符串b，长度为1，结束低估，得到字符串cba）
        */
        public void PermutationImpl(string pre, string str, HashSet<string> set)
        {
            if (str.Length == 1) {
                set.Add(pre + str);
                return;
            }
            for(int i = 0; i < str.Length; i ++) {
                PermutationImpl(pre + str[i], str.Remove(i, 1), set);
            }
        }

        public List<string> Permutation(string str)
        {
            HashSet<string> set = new HashSet<string>();
            PermutationImpl("", str, set);
            List<string> list = new List<string>(set);
            list.Sort();
            return list;
        }

        /*解法2，递归
        基本思路：
        和解法1思路相同。区别在于选取首字符后剩余字符串的表示和重复字符串的过滤

        对剩余字符串的处理，解法1是通过str.Remove(i, 1)返回的新字符串表示剩余字符串
        解法2是通过char数组，swap方法依次将选取的字符和index位置的元素互换，然后index+1及之后的就是剩余字符串

        对重复字符串的处理，解法1是通过HashSet的特性自动过滤重复字符串（即使往HashSet中Add重复字符串也会被自动忽略）
        解法2是通过算法判断是重复字符串则不再Add
        */
        public void Swap(char[] chars, int i, int j){
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }
        public void PermutationImpl2(char[] chars, int index, List<string> list)
        {
            if (index == chars.Length){
                list.Add(new string(chars));
                return;
            }
            HashSet<char> set = new HashSet<char>();
            for(int i = index; i < chars.Length && !set.Contains(chars[i]); i ++){
                set.Add(chars[i]);
                Swap(chars, i, index);
                PermutationImpl2(chars, index + 1, list);
                Swap(chars, index, i);
            }
        }
        public List<string> Permutation2(string str)
        {
            List<string> list = new List<string>();
            if (str != null && str.Length > 0){
                char[] chars = str.ToCharArray();
                PermutationImpl2(chars, 0, list);
                list.Sort();
            }
            return list;
        }

        /*
        abc

        bac
        cba

        bac
        acb

        cba
        acb

        */
        public void Print(List<string> list) {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
/*
a   bac
    b ac ca
    a bc cb
    c ba ab
b   aac
a   abc
    a bc cb
    b ac da 
    c ab ba
c   aba
*/
        public void Test() {
            Print(Permutation("aba"));
            Print(Permutation2(""));
        }
    }
}
