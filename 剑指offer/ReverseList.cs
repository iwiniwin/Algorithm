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

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 使用三个指针pHead， last, next
        /// pHead记录当前节点，last记录上一个节点，next记录下一个节点
        /// 首先使用next保存当前节点的下一个节点，然后将当前节点的下一个节点指向last，实现反转
        /// </summary>

        public ListNode ReverseList(ListNode pHead)
        {
            ListNode last = null, next = null;
            while(pHead != null){

                next = pHead.next;

                pHead.next = last;

                last = pHead;

                pHead = next;
            }
            return last;
        }

        /// <summary>
        /// 解法2，递归
        /// 基本思路：
        /// 通过不断递归，先从链表的尾节点开始反转
        /// 然后利用递归的回溯实现按照从尾到头的顺序反转每个节点
        /// </summary>

        public ListNode ReverseList2(ListNode pHead)
        {
            if(pHead == null || pHead.next == null) return pHead;
            ListNode node = ReverseList2(pHead.next);
            pHead.next.next = pHead;
            pHead.next = null;
            return node;
        }

        public void Print(ListNode head){
            while(head != null){
                Console.WriteLine(head.val);
                head = head.next;
            }
        }
        
        public void Test() {

            ListNode pHead = new ListNode(1);
            pHead.next = new ListNode(2);
            pHead.next.next = new ListNode(3);
            pHead.next.next.next = new ListNode(4);
            // pHead = null;

            // Print(ReverseList(pHead));
            Print(ReverseList2(pHead));
        }
    }
}
