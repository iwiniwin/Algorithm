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

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 利用left指针指向确定不重复的元素
        /// 利用right指针查找重复的元素
        /// 如果right指针没有找到重复的元素，则两个指针同时右移一位，查找剩余的元素
        /// 如果有找到重复的元素，则将left的next直接指向right.next，以移除重复的元素
        /// 构造了一个head节点，为了方便处理头元素可能是重复元素需要移除的情况
        /// </summary>

        public ListNode DeleteDuplication(ListNode pHead)
        {
            ListNode head = new ListNode(0);
            head.next = pHead;
            ListNode left = head, right = head.next;
            while(right != null){
                while(right.next != null && right.next.val == right.val){
                    right = right.next;
                }
                if(left.next == right){
                    left = left.next;
                    right = right.next;
                }else{
                    left.next = right.next;
                    right = left == null ? null : left.next;
                }
            }
            return head.next; 
        }

        public void Print(ListNode node) {
            if (node == null){
                Console.WriteLine("null");
                return;
            }
            while(node != null) {
                Console.WriteLine(node.val);
                node = node.next;
            }
        }

        public void Test() {
            ListNode pHead = null;
            pHead = new ListNode(1);
            // pHead.next = new ListNode(1);
            pHead.next = new ListNode(3);
            pHead.next.next = new ListNode(3);
            pHead.next.next.next = new ListNode(3);
            pHead.next.next.next.next = new ListNode(4);
            pHead.next.next.next.next.next = new ListNode(4);
            pHead.next.next.next.next.next.next = new ListNode(5);

            Print(DeleteDuplication(pHead));
        }
    }
}
