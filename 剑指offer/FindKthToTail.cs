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

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 使用两个指针p, q，通过p = p.next不断遍历链表，当p先走了k步后，q指针再通过q = q.next往下走
        /// 这样相当于p指针一直提前q指针k个节点
        /// 当p指针指向链表末尾时，q指针指向的就是倒数第k个结点
        /// </summary>

        public ListNode FindKthToTail(ListNode head, int k)
        {
            ListNode p = head, q = null;
            while(p != null){
                if(q != null)
                    q = q.next;
                else if(--k == 0)
                    q = head;
                p = p.next;
            }
            return q;
        }

        public void Test() {

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            int k = 3;
            // k = 1;
            // k = 0;
            // k = -3;

            ListNode node = FindKthToTail(head, k);
            if(node == null)
                Console.WriteLine("null");
            else
                Console.WriteLine(node.val);
        }
    }
}
