/*
题目名称：
二叉树的下一个结点

题目描述：
给定一个二叉树和其中的一个结点，请找出中序遍历顺序的下一个结点并且返回。
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

        public TreeLinkNode GetNext(TreeLinkNode pNode)
        {
            return pNode;
        }

        public void Test() {
            TreeLinkNode pNode = new TreeLinkNode(0);

            TreeLinkNode node = GetNext(pNode);
            if (node == null){
                Console.WriteLine("null");
            }else{
                Console.WriteLine(node.val);
            }
        }
    }
}
