/*
题目名称：
字符流中第一个不重复的字符

题目描述：
请实现一个函数用来找出字符流中第一个只出现一次的字符。
例如，当从字符流中只读出前两个字符"go"时，第一个只出现一次的字符是"g"。
当从该字符流中读出前六个字符“google"时，第一个只出现一次的字符是"l"。

输出描述：
如果当前字符流没有存在出现一次的字符，返回#字符。

代码结构：
class Solution
{
    public char FirstAppearingOnce()
    {
        // write code here
    }

    public void Insert(char c)
    {
        // write code here
    }
}
*/
using System;
namespace FirstAppearingOnce {

    class Solution {

        public char FirstAppearingOnce()
        {
            return '#';
        }

        public void Insert(char c)
        {
            // write code here
        }

        public void Test() {

            Insert('.');

            Console.WriteLine(FirstAppearingOnce());
        }
    }
}
