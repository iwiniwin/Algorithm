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
using System.Collections.Generic;
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

        /// <summary>
        /// 解法1
        /// 基本思路：
        /// 利用Dictionary的特性保存链表1的所有节点
        /// 遍历链表2，第一个在Dictionary中的节点就是第一个公共节点
        /// </summary>

        public ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2)
        {
            Dictionary<ListNode, bool> dic = new Dictionary<ListNode, bool>();
            while(pHead1 != null){
                dic[pHead1] = true;
                pHead1 = pHead1.next;
            }
            while(pHead2 != null){
                if(dic.ContainsKey(pHead2)){
                    return pHead2;
                }
                pHead2 = pHead2.next;
            }
            return null;
        }

        public void Test() {
            ListNode p1 = new ListNode(1);
            p1.next = new ListNode(2);
            p1.next.next = new ListNode(3);

            ListNode p2 = new ListNode(4);
            p2.next = new ListNode(2);
            p2.next.next = new ListNode(5);

            p1.next.next = p2.next;

            ListNode ret = FindFirstCommonNode(p1, p2);
            if(ret != null){
                Console.WriteLine(ret.val);
            }else{
                Console.WriteLine("null");
            }
        }
    }
}
