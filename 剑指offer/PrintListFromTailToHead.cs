/*
题目名称：
从尾到头打印链表

题目描述：
输入一个链表，按链表从尾到头的顺序返回一个ArrayList。

代码结构：
class Solution
{
    // 返回从尾到头的列表值序列
    public List<int> PrintListFromTailToHead(ListNode listNode)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace PrintListFromTailToHead {

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
        /// while循环从头遍历整个链表，将每个元素插入到List中
        /// 因为要求是从尾到头，所以每次插入时利用Insert函数不断将元素插入到第一的位置
        /// </summary>
        public List<int> PrintListFromTailToHead(ListNode listNode)
        {
            List<int> list = new List<int>();
            while(listNode != null){
                list.Insert(0, listNode.val);
                listNode = listNode.next;
            }
            return list;
        }

        /// <summary>
        /// 解法2
        /// 基本思路：
        /// 和解法1类似，遍历每个元素后通过Add函数添加到List中，最后统一调用一次Reverse方法进行翻转
        /// </summary>
        public List<int> PrintListFromTailToHead2(ListNode listNode)
        {
            List<int> list = new List<int>();
            while(listNode != null){
                list.Add(listNode.val);
                listNode = listNode.next;
            }
            list.Reverse();
            return list;
        }

        public void Print(List<int> list){
            if(list == null){
                Console.WriteLine("null");
            }else{
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void Test() {

            ListNode node = new ListNode(0);
            // node = null;
            node.next = new ListNode(3);
            node.next.next = new ListNode(1);

            // Print(PrintListFromTailToHead(node));
            Print(PrintListFromTailToHead2(node));
        }
    }
}
