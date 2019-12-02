/*
题目名称：
第一个只出现一次的字符

题目描述：
在一个字符串(0<=字符串长度<=10000，全部由字母组成)中找到第一个只出现一次的字符,并返回它的位置,
如果没有则返回 -1（需要区分大小写）.

代码结构：
class Solution
{
    public int FirstNotRepeatingChar(string str)
    {
        // write code here
    }
}
*/
using System;
namespace FirstNotRepeatingChar {
    class Solution {

        /// <summary>
        /// 解法
        /// 解题思路：
        /// 先遍历一遍字符串统计每个字符的出现次数，然后再遍历一遍字符串，找出第一个出现次数为1的字符的索引
        /// 利用0 - 57的数组下标，来对应A(65) - Z(90) - a(97) - z(122)的ASCII值
        /// 例如65对应的是下标0, 122对应的是下标57
        /// </summary>

        public int FirstNotRepeatingChar(string str)
        {
            if(str == null){
                return - 1;
            }
            int[] arr = new int[58];
            for(int i = 0; i < str.Length; i ++){
                arr[(int)str[i] - 65] ++;
            }
            for(int i = 0; i < str.Length; i ++){
                if(arr[(int)str[i] - 65] == 1){
                    return i;
                }
            }
            return -1;
        }

        public void Test() {
            string str = "abcdAddcfa";
            // str = null;

            Console.WriteLine(FirstNotRepeatingChar(str));
        }
    }
}
