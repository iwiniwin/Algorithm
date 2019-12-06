/*
题目名称：
两个链表的第一个公共结点

题目描述：
输入两个链表，找出它们的第一个公共结点。

代码结构：
class Solution
{
    public ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2)
    {
        // write code here
    }
}
*/
using System;
namespace FindFirstCommonNode {

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

        public ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2)
        {
            return new ListNode(0);
        }

        public void Test() {
            ListNode p1 = new ListNode(1);
            p1.next = new ListNode(2);
            p1.next.next = new ListNode(3);

            ListNode p2 = new ListNode(4);
            p2.next = new ListNode(2);
            p2.next.next = new ListNode(5);

            ListNode ret = FindFirstCommonNode(p1, p2);
            Console.WriteLine(ret.val);
        }
    }
}
