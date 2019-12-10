/*
题目名称：
二叉树的深度

题目描述：
输入一棵二叉树，求该树的深度。
从根结点到叶结点依次经过的结点（含根、叶结点）形成树的一条路径，最长路径的长度为树的深度。

代码结构：
class Solution
{
    public int TreeDepth(TreeNode pRoot)
    {
        // write code here
    }
}
*/
using System;
namespace TreeDepth {

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

        public int TreeDepth(TreeNode pRoot)
        {
            return 0;
        }

        public void Test() {
            TreeNode node = new TreeNode(1);

            Console.WriteLine(TreeDepth(node));
        }
    }
}
