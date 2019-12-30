/*
题目名称：
链表中环的入口结点

题目描述：
给一个链表，若其中包含环，请找出该链表的环的入口结点，否则，输出null。

代码结构：
class Solution
{
    public ListNode EntryNodeOfLoop(ListNode pHead)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace EntryNodeOfLoop {

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
        /// 使用Dictionary记录每个节点是否出现过，如果某个节点重复出现则该节点是环的入口节点
        /// </summary>

        public ListNode EntryNodeOfLoop(ListNode pHead)
        {
            Dictionary<ListNode, bool> dic = new Dictionary<ListNode, bool>();
            while(pHead != null){
                if(dic.ContainsKey(pHead)){
                    return pHead;
                }else{
                    dic[pHead] = true;
                }
                pHead = pHead.next;
            }
            return null;
        }

        /// <summary>
        /// 解法2，断链法
        /// 基本思路：
        /// 首先判断链表是否包含环
        /// 如果一个链表包含环，则该链表可以无限遍历下去。
        /// 此时每遍历到一个节点，便将该节点的前驱节点的next置为空（断链，断开前驱节点与当前节点的连接）
        /// 当某个节点的next为空时，说明此前已经被破坏过，该节点即为环的入口节点
        /// 注意，这种解法会破坏原链表的结构
        /// </summary>

        public ListNode EntryNodeOfLoop2(ListNode pHead)
        {
            ListNode slow = pHead, fast = pHead;
            bool hasRing = false;
            while(fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast){
                    hasRing = true;
                    break;
                }
            }
            if(hasRing){
                slow = pHead;
                fast = pHead.next;
                while(fast != null){
                    slow.next = null;
                    slow = fast;
                    fast = fast.next;
                }
                return slow;
            }
            return null;
        }

        public void Test() {
            
            ListNode pHead = new ListNode(1);
            // pHead = null;
            pHead.next = new ListNode(2);
            pHead.next.next = new ListNode(3);
            pHead.next.next.next = new ListNode(4);
            pHead.next.next.next = pHead.next;

            
            ListNode node = EntryNodeOfLoop(pHead);
            // ListNode node = EntryNodeOfLoop2(pHead);

            if(node == null){
                Console.WriteLine("null");
            }else{
                Console.WriteLine(node.val);
            }
        }
    }
}
