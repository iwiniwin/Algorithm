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

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 使用两个指针p1, p2，分别遍历两个链表一遍
        /// 如果两个链表长度相同：
        ///     如果有公共节点，则第一遍就可以找到公共节点
        ///     如果没有公共节点，则两个指针同时指向null，结束循环
        /// 如果两个链表长度不相同：
        ///     如果有公共节点，则两个链表构成Y型结构，即a+n和b+n(n表示公共部分)，则遍历到a+n+b和b+n+a的位置，一定是公共节点
        ///     如果没有公共节点，则两个指针分别走到a+b和b+a，同时指向null，结束循环
        /// </summary>

        public ListNode FindFirstCommonNode2(ListNode pHead1, ListNode pHead2)
        {
            ListNode p1 = pHead1, p2 = pHead2; 
            while(p1 != p2){
                p1 = (p1 == null) ? pHead2 : p1.next;
                p2 = (p2 == null) ? pHead1 : p2.next;
            }
            return p1;
        }

        /// <summary>
        /// 解法3
        /// 基本思路：
        /// 如果两个链表有公共节点，则有相同的尾部，即构成Y型结构
        /// 先计算出两个链表的长度差，然后让较长的链表先走长度差个元素，然后两个链表再一起走，寻找公共节点
        /// </summary>

        public int GetListLength(ListNode head){
            int count = 0;
            while(head != null){
                count ++;
                head = head.next;
            }
            return count;
        }

        public ListNode FindFirstCommonNode3(ListNode pHead1, ListNode pHead2)
        {
            int len1 = GetListLength(pHead1);
            int len2 = GetListLength(pHead2);
            while(len1 > len2){
                pHead1 = pHead1.next;
                len1 --;
            }
            while(len2 > len1){
                pHead2 = pHead2.next;
                len2 --;
            }
            while(len1 > 0){
                if(pHead1 == pHead2){
                    return pHead1;
                }
                pHead1 = pHead1.next;
                pHead2 = pHead2.next;
                len1 --;
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

            // ListNode ret = FindFirstCommonNode(p1, p2);
            ListNode ret = FindFirstCommonNode2(p1, p2);
            // ListNode ret = FindFirstCommonNode3(p1, p2);
            if(ret != null){
                Console.WriteLine(ret.val);
            }else{
                Console.WriteLine("null");
            }
        }
    }
}
