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
using System.Collections.Generic;
namespace FirstAppearingOnce {

    class Solution {

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 根据ASCII码一共定义了128个字符，因此使用长度为128的数组记录每个字符的出现字数
        /// 当每个字符出现1次时，入队列。查找第一个不重复字符时，将出现次数不为1的字符，出队。
        /// 这样队首的元素就是第一个不重复的字符
        /// </summary>

        int[] array = new int[128];
        Queue<char> queue = new Queue<char>();

        public char FirstAppearingOnce()
        {
            while(queue.Count > 0 && array[queue.Peek()] != 1){
                queue.Dequeue();
            }
            return queue.Count == 0 ? '#' : queue.Peek();
        }

        public void Insert(char c)
        {
            array[c] ++;
            if(array[c] == 1){
                queue.Enqueue(c);
            }
        }

        public void Test() {
            // Insert('.');
            Insert('g');
            Insert('o');
            Insert('o');
            Insert('g');
            Insert('l');
            Insert('e');
            
            Console.WriteLine(FirstAppearingOnce());
        }
    }
}
