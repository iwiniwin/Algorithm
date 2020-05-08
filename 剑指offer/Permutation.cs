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
            选取b为第一个字符（剩下字符串c，长度为1，结束递归，得到字符串abc）
            选取c为第一个字符（剩下字符串b，长度为1，结束递归，得到字符串acb）
        选取b为第一个字符（剩下字符串ac）
            选取a为第一个字符（剩下字符串c，长度为1，结束递归，得到字符串bac）
            选取c为第一个字符（剩下字符串b，长度为1，结束递归，得到字符串bca）
        选取c为第一个字符（剩下字符串ab）
            选取a为第一个字符（剩下字符串c，长度为1，结束递归，得到字符串cab）
            选取b为第一个字符（剩下字符串b，长度为1，结束递归，得到字符串cba）
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
        解法2是通过算法判断是重复字符串则不再Add，如果选取的首字符相同，则剩下的元素的全排列结果必然是重复的，可以过滤
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
            for(int i = index; i < chars.Length; i ++){
                if (!set.Contains(chars[i])){
                    set.Add(chars[i]);
                    Swap(chars, i, index);
                    PermutationImpl2(chars, index + 1, list);
                    Swap(chars, index, i);
                }
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

        /*解法3，字典序全排列算法
        基本思路：
        顾名思义就是按照字典的顺序（a-z, 1-9）列出所有的排列。
        对于数字串1234
        我们可以知道其最小排列为1234（从左到右依次递增）
        其最大排列为4321（从右到左依次递增）
        对于给定字符串1342，下一个恰好比它大的是1423 字典序算法的重点就是如何求得这个下一个刚刚比它大的排列
        我们已经知道从右到左依次递增的排列是最大的，那么越满足这个条件的排列就是越大的
        从右到左，我们找到第一个不满足这个条件的数（即左边的数比右边的数小），记下它的位置，将这个不符合条件
        的数和右边比它大的数中的最小数进行交换，然后将这个位置右边的数进行翻转即可（因为这个位置的数值已经比
        原字符串大了，所以这个位置右边的数应该是最小的）
        
        字符串1342的求解下一个恰好比它大的字符串的过程如下
        1. 从右到左找到第一个不满足递增规律的数，即3
        2. 将3和它右边比它大的数中的最小数即4进行交换，得到1432
        3. 然后将4之后的字符串翻转，得到1423
        */
        public void Reverse(char[] chars, int index){
            for(int i = index; i <= (index + (chars.Length- 1 - index)/2); i ++){
                Swap(chars, i, chars.Length - 1 - i + index);
            }
        }
        public List<string> Permutation3(string str)
        {
            List<string> list = new List<string>();
            if (str != null && str.Length > 0){
                char[] chars = str.ToCharArray();
                Array.Sort(chars);
                list.Add(new string(chars));
                while(true)
                {
                    int i = chars.Length - 1;
                    while(i > 0 && chars[i - 1] >= chars[i]){
                        i --;
                    }
                    if(i == 0) break;
                    int j = i;
                    while(j < chars.Length && chars[j] > chars[i - 1]){
                        j ++ ;
                    }
                    Swap(chars, i - 1, j - 1);
                    Reverse(chars, i);
                    list.Add(new string(chars));
                }
            }
            return list;
        }


        public void Print(List<string> list) {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void Test() {
            // Print(Permutation("abc"));
            Print(Permutation2("aba"));
            // Print(Permutation3("abac"));
        }
    }
}
