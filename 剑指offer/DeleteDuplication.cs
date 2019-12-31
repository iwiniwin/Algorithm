/*
题目名称：
删除链表中重复的结点

题目描述：
在一个排序的链表中，存在重复的结点，请删除该链表中重复的结点，重复的结点不保留，返回链表头指针。 
例如，链表1->2->3->3->4->4->5 处理后为 1->2->5

代码结构：
class Solution
{
    public ListNode deleteDuplication(ListNode pHead)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace DeleteDuplication {

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

        public ListNode DeleteDuplication(ListNode pHead)
        {
            return pHead;
        }

        public void Print(ListNode node) {
            while(node != null) {
                Console.WriteLine(node.val);
                node = node.next;
            }
        }

        public void Test() {
            
            ListNode pHead = new ListNode(1);
            pHead.next = new ListNode(2);
            
            Print(DeleteDuplication(pHead));
        }
    }
}
