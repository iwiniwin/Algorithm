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

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 同时遍历两个链表，比较两个链表的首结点，优先合并其中较小的节点
        /// 当两个链表长度不同时，最后再合并两个链表中较长链表的剩余节点
        /// </summary>

        public ListNode Merge(ListNode pHead1, ListNode pHead2)
        {
            ListNode pHead = new ListNode(0);
            ListNode head = pHead;
            while(pHead1 != null && pHead2 != null){
                if(pHead2.val < pHead1.val){
                    head.next = pHead2;
                    pHead2 = pHead2.next;
                }else{
                    head.next = pHead1;
                    pHead1 = pHead1.next;
                }
                head = head.next;
            }
            if(pHead1 != null){
                head.next = pHead1;
            }
            if(pHead2 != null){
                head.next = pHead2;
            }
            return pHead.next;
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
            // pHead1 = null;

            ListNode pHead2 = new ListNode(0);
            pHead2.next = new ListNode(3);
            pHead2.next.next = new ListNode(4);
            pHead2.next.next.next = new ListNode(5);
            // pHead2 = null;

            Print(Merge(pHead1, pHead2));
        }
    }
}
