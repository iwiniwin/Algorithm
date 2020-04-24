/*
题目名称：
树的子结构

题目描述：
输入两棵二叉树A，B，判断B是不是A的子结构。（ps：我们约定空树不是任意一个树的子结构）

代码结构：
class Solution
{
    public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
    {
        // write code here
    }
}
*/
using System;
namespace HasSubtree {

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

        public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
        {
            return false;
        }

        public void Test() {

            TreeNode pRoot1 = new TreeNode(1);

            TreeNode pRoot2 = new TreeNode(2);
           
            Console.WriteLine(HasSubtree(pRoot1, pRoot2));
        }
    }
}
