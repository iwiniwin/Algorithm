/*
题目名称：
对称的二叉树

题目描述：
请实现一个函数，用来判断一颗二叉树是不是对称的。
注意，如果一个二叉树同此二叉树的镜像是同样的，定义其为对称的。

代码结构：
class Solution
{
    public bool isSymmetrical(TreeNode pRoot)
    {
        // write code here
    }
}
*/
using System;
namespace IsSymmetrical {

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

        public bool IsSymmetrical(TreeNode pRoot)
        {
            return true;
        }

        public void Test() {
            TreeNode pRoot = new TreeNode(0);

            Console.WriteLine(IsSymmetrical(pRoot));
        }
    }
}
