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

        /// <summary>
        /// 解法，递归
        /// 基本思路：
        /// IsSubTree方法，判断仅从两棵二叉树的根节点开始，树2是否是树1的子结构
        /// HasSubtree通过IsSubTree方法判断从两棵二叉树的根节点开始，树2是否是树1的子结构。
        /// 如果是的话直接返回true，如果不是则递归判断树2是否是树1左子节点的子结构或树2是否是树1右子节点的子结构
        /// </summary>

        public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
        {
            if(pRoot1 == null || pRoot2 == null) return false;
            if(IsSubTree(pRoot1, pRoot2))
                return true;
            return HasSubtree(pRoot1.left, pRoot2) || HasSubtree(pRoot1.right, pRoot2);
        }

        public bool IsSubTree(TreeNode pRoot1, TreeNode pRoot2){
            if(pRoot2 == null) return true;
            if(pRoot1 == null) return false;
            if(pRoot1.val == pRoot2.val)
                return IsSubTree(pRoot1.left, pRoot2.left) && IsSubTree(pRoot1.right, pRoot2.right);
            return false;
        }

        public void Test() {

            TreeNode pRoot1 = new TreeNode(1);
            // pRoot1.left = new TreeNode(2);
            pRoot1.right = new TreeNode(1);
            pRoot1.right.left = new TreeNode(1);
            pRoot1.right.left.left = new TreeNode(2);

            TreeNode pRoot2 = new TreeNode(1);
            pRoot2.left = new TreeNode(2);
           
            Console.WriteLine(HasSubtree(pRoot1, pRoot2));
        }
    }
}
