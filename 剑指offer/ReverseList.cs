/*
题目名称：
反转链表

题目描述：
输入一个链表，反转链表后，输出新链表的表头。

代码结构：
class Solution
{
    public ListNode ReverseList(ListNode pHead)
    {
        // write code here
    }
}
*/
using System;
namespace ReverseList {

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

        public ListNode ReverseList(ListNode pHead)
        {
            return pHead;
        }

        public void Print(ListNode head){
            while(head != null){
                Console.WriteLine(head.val);
                head = head.next;
            }
        }
        
        public void Test() {

            ListNode pHead = new ListNode(1);

            Print(ReverseList(pHead));
        }
    }
}
