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
        /// 首先判断链表是否包含环。
        /// 定义快慢指针，快指针走两步，慢指针走一步，如果有环，快慢指针一定会相遇（快指针会追上慢指针）。
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

        /// <summary>
        /// 解法3
        /// 基本思路：
        /// 定义一个快指针，一个慢指针，都指向链表的头部
        /// 如果链表包含环，假设环长度为n。
        /// 让快指针先走n步，然后再让快慢指针一起走（都是每次走一步），则它们一定相遇于环的入口节点
        /// 问题在于如何计算环的长度
        /// 上面在判断是否包含环时，会找到使两个指针相遇的节点，这个相遇点一定在环内。
        /// 从这个相遇点继续遍历，再次回到相遇点时经过的长度就是环长
        /// </summary>

        public ListNode EntryNodeOfLoop3(ListNode pHead)
        {
            ListNode p = pHead, q = pHead;
            bool hasRing = false;
            while(q != null && q.next != null){
                p = p.next;
                q = q.next.next;
                if (p == q){
                    hasRing = true;
                    break;
                }
            }
            if(hasRing){
                ListNode r = pHead;
                do{
                    r = r.next;
                    p = p.next;
                }while(p != q);
                p = pHead;
                while(r != p){
                    r = r.next;
                    p = p.next;
                }
                return p;
            }
            return null;
        }

        public void Test() {
            
            ListNode pHead = new ListNode(1);
            // pHead = null;
            pHead.next = new ListNode(2);
            pHead.next.next = new ListNode(3);
            pHead.next.next.next = new ListNode(4);
            // pHead.next.next.next = pHead.next.next;

            
            // ListNode node = EntryNodeOfLoop(pHead);
            // ListNode node = EntryNodeOfLoop2(pHead);
            ListNode node = EntryNodeOfLoop3(pHead);

            if(node == null){
                Console.WriteLine("null");
            }else{
                Console.WriteLine(node.val);
            }
        }
    }
}
