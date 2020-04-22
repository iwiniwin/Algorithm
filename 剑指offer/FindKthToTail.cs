/*
题目名称：
链表中倒数第k个结点

题目描述：
输入一个链表，输出该链表中倒数第k个结点。

代码结构：
class Solution
{
    public ListNode FindKthToTail(ListNode head, int k)
    {
        // write code here
    }
}
*/
using System;
namespace FindKthToTail {

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

        public ListNode FindKthToTail(ListNode head, int k)
        {
            return null;
        }

        public void Test() {

            ListNode head = new ListNode(1);
            int k = 3;

            ListNode node = FindKthToTail(head, k);
            if(node == null)
                Console.WriteLine("null");
            else
                Console.WriteLine(node.val);
        }
    }
}
