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

        /// <summary>
        /// 解法1，递归
        /// 基本思路：
        /// 递归遍历二叉树的左右子节点，树的深度等于其左右子树深度中的最大值加1
        /// </summary>

        public int TreeDepth(TreeNode pRoot)
        {
            if(pRoot == null){
                return 0;
            }
            int left = TreeDepth(pRoot.left) + 1;
            int right = TreeDepth(pRoot.right) + 1;
            return left > right ? left : right;
        }

        public void Test() {
            TreeNode node = new TreeNode(1);
            // node = null;
            node.left = new TreeNode(2);
            node.left.left = new TreeNode(3);
            node.right = new TreeNode(4);
            node.right.right = new TreeNode(5);
            node.right.right.right = new TreeNode(6);

            Console.WriteLine(TreeDepth(node));
        }
    }
}
