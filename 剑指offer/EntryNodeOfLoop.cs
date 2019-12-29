/*
题目名称：
链表中环的入口结点

题目描述：
给一个链表，若其中包含环，请找出该链表的环的入口结点，否则，输出null。

输出描述：
如果当前字符流没有存在出现一次的字符，返回#字符。

代码结构：
class Solution
{
    public ListNode EntryNodeOfLoop(ListNode pHead)
    {
        // write code here
    }
}
*/
using System;
namespace EntryNodeOfLoop {

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode (int x)
        {
            val = x;
        }
    }

    class Solution {

        public ListNode EntryNodeOfLoop(ListNode pHead)
        {
            return null;
        }

        public void Test() {
            
            ListNode pHead = new ListNode(1);
            
            ListNode node = EntryNodeOfLoop(pHead);

            if(node == null){
                Console.WriteLine("null");
            }else{
                Console.WriteLine(node.val);
            }
        }
    }
}
