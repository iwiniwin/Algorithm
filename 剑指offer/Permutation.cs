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
        }
    }
}
