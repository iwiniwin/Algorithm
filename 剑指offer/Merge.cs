/*
题目名称：
合并两个排序的链表

题目描述：
输入两个单调递增的链表，输出两个链表合成后的链表，当然我们需要合成后的链表满足单调不减规则。

代码结构：
class Solution
{
    public ListNode Merge(ListNode pHead1, ListNode pHead2)
    {
        // write code here
    }
}
*/
using System;
namespace Merge {

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
        
        public ListNode Merge(ListNode pHead1, ListNode pHead2)
        {
            return pHead2;
        }

        public void Print(ListNode head){
            while(head != null){
                Console.WriteLine(head.val);
                head = head.next;
            }
        }
        
        public void Test() {

            ListNode pHead1 = new ListNode(1);
            pHead1.next = new ListNode(2);
            pHead1.next.next = new ListNode(3);
            pHead1.next.next.next = new ListNode(4);

            ListNode pHead2 = new ListNode(0);
            pHead2.next = new ListNode(3);
            pHead2.next.next = new ListNode(4);
            pHead2.next.next.next = new ListNode(5);

            Print(Merge(pHead1, pHead2));
        }
    }
}
