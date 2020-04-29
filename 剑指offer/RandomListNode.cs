/*
题目名称：
复杂链表的复制

题目描述：
输入一个复杂链表（每个节点中有节点值，以及两个指针，一个指向下一个节点，另一个特殊指针random指向一个随机节点）
请对此链表进行深拷贝，并返回拷贝后的头结点。
（注意，输出结果中请不要返回参数中的节点引用，否则判题程序会直接返回空）

代码结构：
class Solution
{
    public RandomListNode Clone(RandomListNode pHead)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace RandomListNode {

    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode (int x)
        {
            this.label = x;
        }
    }

    class Solution {

        /// <summary>
        /// 解法1，递归
        /// 基本思路：
        /// 通过递归拷贝每一个节点
        /// 利用Dictionary处理循环链表的问题，避免死循环
        /// </summary>

        Dictionary<RandomListNode, RandomListNode> dic = new Dictionary<RandomListNode, RandomListNode>();
        
        public RandomListNode Clone(RandomListNode pHead)
        {
            if(pHead == null) return null;
            if(dic.ContainsKey(pHead)) return dic[pHead];
            RandomListNode head = new RandomListNode(pHead.label);
            dic[pHead] = head;
            head.next = Clone(pHead.next);
            head.random = Clone(pHead.random);
            return head;
        }

        public void Print(RandomListNode pHead){
            if(pHead == null){
                Console.WriteLine("null");
                return;
            }
            while(pHead != null){
                Console.WriteLine(pHead.label);
                if(pHead.random != null){
                    Print(pHead.random);
                }
                pHead = pHead.next;
            }
        }

        public void Test() {
            
            RandomListNode pHead = new RandomListNode(1);
            pHead.random = new RandomListNode(4);
            pHead.next = new RandomListNode(5);
            pHead.next.random = new RandomListNode(6);
            pHead.next.random.next = new RandomListNode(7);
            pHead.next.next = new RandomListNode(5);
            // pHead.next.next.next = pHead;  // 小心，会导致print死循环

            Print(Clone(pHead));
        }
    }
}
