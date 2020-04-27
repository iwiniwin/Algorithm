/*
题目名称：
从上往下打印二叉树

题目描述：
从上往下打印出二叉树的每个节点，同层节点从左至右打印。

代码结构：
class Solution
{
    public List<int> PrintFromTopToBottom(TreeNode root)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace PrintFromTopToBottom {

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
        /// 解法1
        /// 基本思路：
        /// 层次遍历，利用一个辅助队列，队列中依次保存二叉树的根节点，左节点，右节点
        /// 当出列一个节点的同时，入列该节点的左右子节点，根据队列的先进先出特性，实现从上到下，从左到右的顺序
        /// </summary>

        public List<int> PrintFromTopToBottom(TreeNode root)
        {
            List<int> list = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0){
                TreeNode node = queue.Dequeue();
                if(node != null){
                    list.Add(node.val);
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
            return list;
        }

        public void Print(List<int> list){
            if(list == null){
                Console.WriteLine("null");
                return;
            }
            foreach(int item in list)
                Console.WriteLine(item);
        }

        public void Test() {
            
            TreeNode root = new TreeNode(1);
            // root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(4);
            root.right.left.right = new TreeNode(4);

            Print(PrintFromTopToBottom(root));
        }
    }
}
