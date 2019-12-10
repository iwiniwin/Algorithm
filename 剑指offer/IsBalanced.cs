/*
题目名称：
平衡二叉树

题目描述：
输入一棵二叉树，判断该二叉树是否是平衡二叉树。

代码结构：
class Solution
{
    public bool IsBalanced_Solution(TreeNode pRoot)
    {
        // write code here
    }
}
*/
using System;
namespace IsBalanced {

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

        public bool IsBalanced_Solution(TreeNode pRoot)
        {
            return false;
        }

        public void Test() {
            TreeNode node = new TreeNode(1);

            Console.WriteLine(IsBalanced_Solution(node));
        }
    }
}
