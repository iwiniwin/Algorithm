/*
题目名称：
重建二叉树

题目描述：
输入某二叉树的前序遍历和中序遍历的结果，请重建出该二叉树。
假设输入的前序遍历和中序遍历的结果中都不含重复的数字。
例如输入前序遍历序列{1,2,4,7,3,5,6,8}和中序遍历序列{4,7,2,1,5,3,8,6}，则重建二叉树并返回。

代码结构：
class Solution
{
    public TreeNode ReConstructBinaryTree(int[] pre, int[] tin)
    {
        // write code here
    }
}
*/
using System;
namespace ReConstructBinaryTree {

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

        public TreeNode ReConstructBinaryTree(int[] pre, int[] tin)
        {
            return null;
        }

        public void Test() {

            int[] pre = new int[]{};
            int[] tin = new int[]{};

            TreeNode node = ReConstructBinaryTree(pre, tin);
        }
    }
}
