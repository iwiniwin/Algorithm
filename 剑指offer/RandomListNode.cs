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

        /// <summary>
        /// 解法2，三步法
        /// 基本思路：
        /// 1. 复制链表每个节点，如：复制节点A得到A1，并将A1插入节点A后面
        /// 2. 重新遍历链表，为每个复制的节点设置random，如A1.random = A.random.next;
        /// 3、将链表拆分成原链表和复制后的链表
        /// 第2步是第1步将复制节点插入到原节点后面的原因，这样复制节点的random就是原节点random的下一个节点
        /// 可以查看docs/RandomListNode_solution2.png三步法的图示
        /// </summary>

        public RandomListNode Clone2(RandomListNode pHead){
            if(pHead == null) return null;
            RandomListNode cur = pHead;
            while(cur != null){
                RandomListNode next = new RandomListNode(cur.label);
                next.next = cur.next;
                cur.next = next;
                cur = next.next;
            }
            cur = pHead;
            while(cur != null){
                if(cur.random != null)
                    cur.next.random = cur.random.next;
                cur = cur.next.next;
            }
            cur = pHead;
            RandomListNode head = pHead.next, temp;
            while(cur != null && cur.next != null){
                temp = cur.next;
                cur.next = temp.next;
                cur = temp;
            }
            return head;
        }

        public void Print(RandomListNode pHead){
            if(pHead == null){
                Console.WriteLine("null");
                return;
            }
            while(pHead != null){
                Console.WriteLine(pHead.label + " " + pHead.random?.label);
                pHead = pHead.next;
            }
        }

        public void Test() {
            
            RandomListNode pHead = new RandomListNode(1);
            pHead.next = new RandomListNode(2);
            pHead.next.next = new RandomListNode(3);
            pHead.next.next.next = new RandomListNode(4);
            pHead.random = pHead.next.next;
            pHead.next.random =  pHead.next.next.next;

            // Print(Clone(pHead));
            Print(Clone2(pHead));
        }
    }
}
