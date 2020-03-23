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

        // 返回从尾到头的列表值序列
        public List<int> PrintListFromTailToHead(ListNode listNode)
        {
            return null;
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

            Print(PrintListFromTailToHead(node));
        }
    }
}
