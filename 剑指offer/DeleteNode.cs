/*
题目名称：
删除链表的节点

题目描述：
给定单向链表的头指针和一个要删除的节点的值，定义一个函数删除该节点。返回删除后的链表的头节点。

1.此题对比原题有改动
2.题目保证链表中节点的值互不相同
3.该题只会输出返回的链表和结果做对比，所以若使用 C 或 C++ 语言，你不需要 free 或 delete 被删除的节点

代码结构：
class Solution {
    public ListNode deleteNode (ListNode head, int val) {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace DeleteNode {
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
        public ListNode DeleteNode (ListNode head, int val) {
            if(head == null) return null;
            if(head.val == val) return head.next;
            ListNode node = head;
            while(node.next != null) {
                if(node.next.val == val) {
                    node.next = node.next.next;
                    break;
                }
                node = node.next;
            }
            return head;
        }

        public void Test()
        {
            ListNode head = new ListNode(2);
            head.next = new ListNode(5);
            head.next.next = new ListNode(1);
            head.next.next.next = new ListNode(9);
            int val = 5;

            ListNode result = DeleteNode(head, val);
            while (head != null) {
                Console.Write(head.val + " ");
                head = head.next;
            }
            Console.WriteLine();
        }
    }
}
