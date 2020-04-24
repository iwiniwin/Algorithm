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

        public TreeNode Mirror(TreeNode root)
        {
            return root;
        }

        public void Print(TreeNode root){
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0){
                TreeNode node = queue.Dequeue();
                if(node == null){
                    Console.Write("#");
                } else{
                    Console.Write(node.val);
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
        }

        public void Test() {

            TreeNode root = new TreeNode(2);
            root.right = new TreeNode(3);
            root.right.right = new TreeNode(4);
            // root = null;
           
            Print(Mirror(root));
        }
    }
}
