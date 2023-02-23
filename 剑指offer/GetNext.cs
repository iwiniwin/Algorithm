/*
题目名称：
二叉树的下一个结点

题目描述：
给定一个二叉树其中的一个结点，请找出中序遍历顺序的下一个结点并且返回。
注意，树中的结点不仅包含左右子结点，同时包含指向父结点的指针。

代码结构：
class Solution
{
    public TreeLinkNode GetNext(TreeLinkNode pNode)
    {
        // write code here
    }
}


*/
using System;
namespace GetNext {

    public class TreeLinkNode
    {
        public int val;
        public TreeLinkNode left;
        public TreeLinkNode right;
        public TreeLinkNode next;
        public TreeLinkNode (int x)
        {
            val = x;
        }
    }

    class Solution {

        /// <summary>
        /// 解法
        /// 基本思路：
        /// 中序遍历的顺序是先左节点，再根节点，再右节点
        /// 1. 节点为空，返回空
        /// 2. 如果节点有右节点，则一直向下寻找该右节点的左节点，直到叶子节点为止，即为下一个节点
        /// 3. 如果节点有父节点，且是父节点的左节点，则返回父节点。否则继续判断其父节点是否满足条件，直到父节点为空。
        /// 可以理解为中序遍历到一个子节点后，下一个节点一定是这个子节点所在左子树的父节点
        /// 前中后续遍历介绍 https://blog.csdn.net/FightLei/article/details/89281600
        /// </summary>

        public TreeLinkNode GetNext(TreeLinkNode pNode)
        {
            if(pNode == null){
                return null;
            }

            if(pNode.right != null){
                pNode = pNode.right;
                while(pNode.left != null){
                    pNode = pNode.left;
                }
                return pNode;
            }

            while(pNode.next != null){
                if(pNode == pNode.next.left){
                    return pNode.next;
                }
                pNode = pNode.next;
            }

            return null;
        }

        public void Test() {
            TreeLinkNode pNode = null;
            pNode = new TreeLinkNode(0);
            pNode.left = new TreeLinkNode(1);
            pNode.left.next = pNode;

            pNode.left.right = new TreeLinkNode(3);
            pNode.left.right.next = pNode.left;


            pNode.right = new TreeLinkNode(2);
            pNode.right.next = pNode;

            pNode.right.left = new TreeLinkNode(4);
            pNode.right.left.next = pNode.right;
            
            TreeLinkNode node = GetNext(pNode);

            if (node == null){
                Console.WriteLine("null");
            }else{
                Console.WriteLine(node.val);
            }
        }
    }
}
