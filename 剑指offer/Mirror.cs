/*
题目名称：
二叉树的镜像

题目描述：
操作给定的二叉树，将其变换为源二叉树的镜像。

输入描述：
二叉树的镜像定义：源二叉树 
    	    8
    	   /  \
    	  6   10
    	 / \  / \
    	5  7 9 11
    	镜像二叉树
    	    8
    	   /  \
    	  10   6
    	 / \  / \
    	11 9 7   5

代码结构：
class Solution
{
    public TreeNode Mirror(TreeNode root)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace Mirror {

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode (int x)
        {
            val = x;
        }
    }

    class Solution {

        /// <summary>
        /// 解法，递归
        /// 基本思路：
        /// 先翻转根节点的左右子节点，然后通过递归再分别翻转左右子节点的子节点
        /// </summary>

        public TreeNode Mirror(TreeNode root)
        {
            if(root != null){
                TreeNode node = root.left;
                root.left = root.right;
                root.right = node;
                Mirror(root.left);
                Mirror(root.right);
            }
            return root;
        }

        public void Print(TreeNode root){
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0){
                TreeNode node = queue.Dequeue();
                if(node == null){
                    Console.Write("# ");
                } else{
                    Console.Write(node.val + " ");
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
        }

        public void Test() {

            TreeNode root = new TreeNode(8);
            root.left = new TreeNode(6);
            root.right = new TreeNode(10);
            // root.left.left = new TreeNode(5);
            // root.left.right = new TreeNode(7);
            root.right.left = new TreeNode(9);
            // root.right.right = new TreeNode(11);
            // root = null;
           
            Print(Mirror(root));
        }
    }
}
